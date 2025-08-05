using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Helpers
{
    public static class IsImageHelper
    {
        public static bool FileIsImage(string extension)
        {
            var validExtensions = new[] { ".png", ".jpg", ".jpeg" };
            return validExtensions.Contains(extension.ToLower());
        }
    }
}
