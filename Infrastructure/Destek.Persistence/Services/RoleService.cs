﻿using Destek.Application.Abstractions.Services;
using Destek.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Destek.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Id = Guid.NewGuid(), Name = name });

            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            AppRole appRole = await _roleManager.FindByIdAsync(id.ToString());
            IdentityResult result = await _roleManager.DeleteAsync(appRole);
            return result.Succeeded;
        }

        public (object, int) GetAllRoles(int page, int size)
        {
            var query = _roleManager.Roles;

            IQueryable<AppRole> rolesQuery = null;

            if (page != -1 && size != -1)
                rolesQuery = query.Skip(page * size).Take(size);
            else
                rolesQuery = query;

            return (rolesQuery.Select(r => new { r.Id, r.Name }), query.Count());
        }

        public async Task<(string id, string name)> GetRoleById(Guid id)
        {
            string role = await _roleManager.GetRoleIdAsync(new() { Id = id });
            return (id.ToString(), role);
        }

        public async Task<bool> UpdateRole(Guid id, string name)
        {
            AppRole role = await _roleManager.FindByIdAsync(id.ToString());
            role.Name = name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }
    }
}
