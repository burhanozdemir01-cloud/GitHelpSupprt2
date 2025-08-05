using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Exceptions
{
    public class CommonException:Exception
    {
        public CommonException() : base("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin")
        {
        }

        public CommonException(string? message) : base(message)
        {
        }

        public CommonException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
