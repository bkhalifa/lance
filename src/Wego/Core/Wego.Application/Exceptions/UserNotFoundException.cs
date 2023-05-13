using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.UserNotFound;
        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
