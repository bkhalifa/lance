using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public class PasswordsEqualsException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.PasswordsEquals;
        public PasswordsEqualsException(string message) : base(message)
        {

        }
    }
}
