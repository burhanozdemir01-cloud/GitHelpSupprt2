using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Destek.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<ControllerEndpoint> ControllerEndpoints { get; set; }
    }
}
