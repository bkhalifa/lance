using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public class UserAlreadyExistsException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.UserAlreadyExists;
        public UserAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
