using Destek.Application.DTOs.Ticket;
using Destek.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.AppUser.GetAllUserDropDown
{
    public class GetAllUserDropDownQueryResponse
    {

        public List<UserListDropDown> Users { get; set; }
    }
}
