using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.Configuration
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<ActionDto> ActionDto { get; set; } = new();
    }
}
