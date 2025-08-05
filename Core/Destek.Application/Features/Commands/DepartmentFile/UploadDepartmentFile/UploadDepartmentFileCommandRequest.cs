﻿using Destek.Application.Features.Commands.Department.UpdateDepartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.DepartmentFile.UploadDepartmentFile
{
    public class UploadDepartmentFileCommandRequest : IRequest<UploadDepartmentFileCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
