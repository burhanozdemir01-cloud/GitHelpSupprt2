using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Exceptions
{
    public class UserNotLoginException : Exception
    {
        public UserNotLoginException():base("Kullanıcı Girişi Yapınız.")
        {
        }

        public UserNotLoginException(string message) : base(message)
        {
        }
        public UserNotLoginException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
