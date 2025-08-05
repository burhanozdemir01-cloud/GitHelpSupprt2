using Destek.Application.Consts;
using Destek.Application.CustomAttributes;
using Destek.Application.Enums;
using Destek.Application.Features.Commands.Department.CreateDepartment;
using Destek.Application.Features.Commands.Department.DeleteDepartment;
using Destek.Application.Features.Commands.Department.UpdateDepartment;
using Destek.Application.Features.Commands.DepartmentFile.ChangeShowcaseImage;
using Destek.Application.Features.Commands.DepartmentFile.RemoveDepartmentFile;
using Destek.Application.Features.Commands.DepartmentFile.UploadDepartmentFile;
using Destek.Application.Features.Queries.Department.GetAllDepartment;
using Destek.Application.Features.Queries.Department.GetAllDepartmentDropDown;
using Destek.Application.Features.Queries.Department.GetByIdDepartment;
using Destek.Application.Features.Queries.DepartmentFile.GetDepartmentFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Destek.API.Controllers
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
   
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
       // [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Reading, Definition ="Get Department All")]
        public async Task<IActionResult> Get([FromQuery] GetAllDepartmentQueryRequest getAllDepartmentQueryRequest)
        {
            GetAllDepartmentQueryResponse response = await _mediator.Send(getAllDepartmentQueryRequest);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdDepartmentQueryRequest getByIdDepartmentQueryRequest)
        {
            GetByIdDepartmentQueryResponse response = await _mediator.Send(getByIdDepartmentQueryRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        // [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Reading, Definition ="Get Department All")]
        public async Task<IActionResult> GetDropDown([FromQuery] GetAllDepartmentDropDownQueryRequest getAllDepartmentDropDownQueryRequest)
        {
            GetAllDepartmentDropDownQueryResponse response = await _mediator.Send(getAllDepartmentDropDownQueryRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
     //   [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Writing, Definition = "İnsert department")]
        public async Task<IActionResult> Post(CreateDepartmentCommandRequest request)
        {

            CreateDepartmentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("[action]")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Updating, Definition = "update department")]
        public async Task<IActionResult> Put([FromBody] UpdateDepartmentCommandRequest request)
        {  
            UpdateDepartmentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Departments, ActionType = ActionType.Deleting, Definition = "delete department")]
        public async Task<IActionResult> Delete([FromRoute] RemoveDepartmentCommandRequest request)
        {
            RemoveDepartmentCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadDepartmentFileCommandRequest request)
        {

           
            //var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            //_productImageFileWriteRepository.AddRangeAsync(datas.Select(d=>new ProductImageFile()
            //{
            //    FileName=d.fileName,
            //    Path=d.path
            //}).ToList());
            //await _productImageFileWriteRepository.SaveAsync();

            //var datas = await _storageService.UploadAsync("files", Request.Form.Files);//LocalStorage:"resource/product-images"
            //_productImageFileWriteRepository.AddRangeAsync(datas.Select(d=>new ProductImageFile()
            //{
            //    FileName=d.fileName,
            //    Path=d.pathOrContainerName,
            //    Storage=_storageService.StorageName
            //}).ToList());
            //await _productImageFileWriteRepository.SaveAsync();



            //List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", Request.Form.Files);

            //Product product = await _productReadRepository.GetByIdAsync(request.Id);
            //await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImageFile
            //{
            //    FileName = r.fileName,
            //    Path = r.pathOrContainerName,
            //    Storage = _storageService.StorageName,
            //    Products = new List<Product>() { product }
            //}).ToList());

            //await _productImageFileWriteRepository.SaveAsync();

            request.Files = Request.Form.Files;
            UploadDepartmentFileCommandResponse response = await _mediator.Send(request);
            return Ok();

        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetDepartmentImages([FromRoute] GetDepartmentFileQueryRequest request)
        {
            List<GetDepartmentFileQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteDepartmentFile([FromRoute] RemoveDepartmentFileCommandRequest request, [FromQuery] string imageId)
        {
            request.ImageId = imageId;
            RemoveDepartmentFileCommandResponse response = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Change Showcase Image")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {
            ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
            return Ok(response);
        }
    }
}
