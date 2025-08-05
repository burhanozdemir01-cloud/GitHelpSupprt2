using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Abstractions.Services
{
    public interface IRoleService
    {
        (object, int) GetAllRoles(int page, int size);
        Task<(string id, string name)> GetRoleById(Guid id);
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(Guid id);
        Task<bool> UpdateRole(Guid id, string name);
    }
}
