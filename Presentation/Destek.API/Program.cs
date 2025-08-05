
using Destek.API.Configurations;
using Destek.Application;
using Destek.SignalR;
using Destek.Application.Validatiors.Departments;
using Destek.Infrastructure;
using Destek.Infrastructure.Filters;
using Destek.Infrastructure.Services.Storage.Local;
using Destek.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;
using System.Security.Claims;
using System.Text;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddSignalRServices();
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));//CORS Politikalarýný ayarlayan servis

var log = LoggerConfigurationFactory.CreateLogger(builder.Configuration);
builder.Host.UseSerilog(log);

//builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateDepartmentValidator>());//Oluþturualn Validator tanýmla;

builder.Services.AddControllers(options 
    => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateDepartmentValidator>())//Oluþturualn Validator tanýmla
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);// ASPNETCOre default filteri devre dýþý býrak

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//   // o.UseSecurityTokenValidators=true;
//    o.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = builder.Configuration["Token:Issuer"],
//        ValidAudience = builder.Configuration["Token:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };
//});

//builder.Services.AddAuthorization();

builder.Services.AddAuthentication(cfg =>
{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    options.RequireHttpsMetadata = false;
    options.SaveToken = false;
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,//Oluþturulacak token deðerinin kim hangi originlerin/sitelerin kullanýcý belirlediðimiz deðerdir.->www.ggg.com 
        ValidateIssuer = true,// Oluþturulacak token deðerini kimin daðýttýðýný ifade edeceðimiz alandýr ->www.myapi.com
        ValidateLifetime = true,//oluþturulan token deðerinin süresini kontrol edecek doðrulamadýr.
        ValidateIssuerSigningKey = true,//Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifde eden security key verisinin doðrulamasýdýr.
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        NameClaimType = ClaimTypes.Name //JWT üzerinde Name claimne karþýlýk gelen deðeri User.Identity.Name propertysinden elde edebiliriz.

    };
});
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseStaticFiles();
app.UseCors();//CORS Middleware i çaðýr
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated !=null || true ? context.User.Identity.Name :null;
    //    var getValue = propertyFactory.CreateProperty(username, value);
    //    logEvent.AddPropertyIfAbsent(getValue);
    LogContext.PushProperty("Username", userName);
    await next();
});
app.MapControllers();
app.MapHubs();
app.Run();
