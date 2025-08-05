using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Abstractions.Hubs
{
    public interface IDepartmentHubService
    {
        Task DepartmentAddedMessageAsync(string message);
    }
}
