﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.Ticket
{
    public class TicketFileModelDto
    {
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public bool IsImage { get; set; }
    }
}
