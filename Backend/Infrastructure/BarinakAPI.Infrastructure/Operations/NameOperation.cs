using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Infrastructure.Oparations
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)
         => name.Replace("\"","")
             .Replace("!", "")
             .Replace("'", "")
             .Replace("^", "")
             .Replace("+", "")
             .Replace("%", "")
             .Replace("&", "")
             .Replace("/", "")
             .Replace("(", "")
             .Replace(")", "")
             .Replace("=", "")
             .Replace("*", "")
             .Replace("?", "")
             .Replace("_", "")
             .Replace("-", "")
             .Replace("@", "")
             .Replace(":", "")
             .Replace(";", "")
             .Replace(",", "")
             .Replace("~", "")
             .Replace("#", "")
             .Replace(",", "")
             .Replace("é", "")
             .Replace("Ö", "o")
             .Replace("ö", "o")
             .Replace("Ü", "u")
             .Replace("ü", "u")
             .Replace("ı", "i")
             .Replace("İ", "i")
             .Replace("Ğ", "g")
             .Replace("ğ", "g")
             .Replace("ş", "s")
             .Replace("Ş", "s")
             .Replace("Ç", "c") 
             .Replace("<", "")
             .Replace(">", "");


    }  
}
