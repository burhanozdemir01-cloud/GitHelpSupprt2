using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Destek.Infrastructure.Operations
{
    public static class NameOperations
    {
        public static string CharacterRegulatory(string name)
        {

            if (string.IsNullOrEmpty(name)) return "";
            name = name.ToLower();
            name = name.Trim();
            if (name.Length > 100)
            {
                name = name.Substring(0, 100);
            }
            name = name.Replace("İ", "I");
            name = name.Replace("ı", "i");
            name = name.Replace("ğ", "g");
            name = name.Replace("Ğ", "G");
            name = name.Replace("ç", "c");
            name = name.Replace("Ç", "C");
            name = name.Replace("ö", "o");
            name = name.Replace("Ö", "O");
            name = name.Replace("ş", "s");
            name = name.Replace("Ş", "S");
            name = name.Replace("ü", "u");
            name = name.Replace("Ü", "U");
            name = name.Replace("'", "");
            name = name.Replace("\"", "");
            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (name.Contains(strChr))
                {
                    name = name.Replace(strChr, string.Empty);
                }
            }
            Regex regex = new Regex("[^a-zA-Z0-9_-]");
            name = regex.Replace(name, "-");
            while (name.IndexOf("--", StringComparison.Ordinal) > -1)
                name = name.Replace("--", "-");
            return name;
        }

    }
}
