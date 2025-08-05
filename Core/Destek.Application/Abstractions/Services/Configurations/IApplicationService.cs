using Destek.Application.DTOs.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Abstractions.Services.Configurations
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
