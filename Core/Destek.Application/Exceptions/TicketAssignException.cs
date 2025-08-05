using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Exceptions
{
    public class TicketAssignException : Exception
    {
        public TicketAssignException() : base("Bu destek bu kullanıcıya zaten atanmış.")
        {
        }

        public TicketAssignException(string? message) : base(message)
        {
        }

        public TicketAssignException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
