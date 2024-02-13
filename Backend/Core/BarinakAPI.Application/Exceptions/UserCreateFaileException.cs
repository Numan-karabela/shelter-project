using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Exceptions
{
    public class UserCreateFaileException : Exception
    {
        public UserCreateFaileException() : base("Kullanıcı oluşturulurken beklenmeyen bir hata ile kayşilaştırıldı")
        {

        }

        public UserCreateFaileException(string? message) : base(message)
        {
        }

        public UserCreateFaileException(string? message, Exception? innerException) : base(message, innerException)
        {


        }
    }
}
