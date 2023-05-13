using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public class UserNotAuthentificatedException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.UserNotAuthentificated;
        public UserNotAuthentificatedException(string message) : base(message)
        {

        }
    }
}
