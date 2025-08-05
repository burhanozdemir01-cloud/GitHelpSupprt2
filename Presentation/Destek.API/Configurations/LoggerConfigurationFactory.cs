using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using System.Data;
using Serilog.Core;

namespace Destek.API.Configurations
{
    public static class LoggerConfigurationFactory
    {
        public static Logger CreateLogger(IConfiguration configuration)
        {
            try
            {
                var customColumnOptions = CreateCustomColumnOptions();
                //var anyColumnOptions = CreateAnyColumnOptions();

                var columnOptions = new ColumnOptions
                {
                    Level = { ColumnName = "Level", DataType = SqlDbType.NVarChar, AllowNull = false },
                    TimeStamp = { ColumnName = "TimeStamp", DataType = SqlDbType.DateTimeOffset, AllowNull = false },
                    LogEvent = { ColumnName = "LogEvent", DataType = SqlDbType.NVarChar, AllowNull = true },
                    Message = { ColumnName = "Message", DataType = SqlDbType.NVarChar, AllowNull = true },
                    Exception = { ColumnName = "Exception", DataType = SqlDbType.NVarChar, AllowNull = true },
                    MessageTemplate = { ColumnName = "MessageTemplate", DataType = SqlDbType.NVarChar, AllowNull = true },
                    AdditionalColumns = customColumnOptions.AdditionalColumns
                    // AddionalColumns sadece bir kez kullanılabilir. Bu yüzden birleştiriyoruz.
                    //AdditionalColumns = customColumnOptions.AdditionalColumns.Concat(anyColumnOptions.AdditionalColumns).ToList()
                };

                // Burada istemediğimiz oto eklenenler olursa kaldırabiliriz.
                columnOptions.Store.Remove(StandardColumn.Properties);
                // Eklenmeyen oto tablo olursa manuel ekleme yapabiliriz.
                columnOptions.Store.Add(StandardColumn.LogEvent);

                return new LoggerConfiguration()
                 //   .WriteTo.File("logs/log.txt")
                    .WriteTo.MSSqlServer(configuration.GetConnectionString("SqlServer"), sinkOptions: new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = true,
                        TableName = "Logs"
                    },
                    columnOptions: columnOptions)
                    .Enrich.FromLogContext()
                    .WriteTo.Seq(configuration["Seq:ServerURL"])
                    .MinimumLevel.Information()
                    .CreateLogger();
            }
            catch (Exception)
            {
                Console.WriteLine("Hata");
                throw;
            }
        }

        private static ColumnOptions CreateCustomColumnOptions()
        {
            var customColumnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
     {
         new SqlColumn
         {
             ColumnName = "Username",
             DataType = SqlDbType.NVarChar,
             DataLength = 255,
             AllowNull = true,
         }
     }
            };

            return customColumnOptions;
        }



    }
}
