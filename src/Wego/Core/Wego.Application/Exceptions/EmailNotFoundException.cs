using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public class EmailNotFoundException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.EmailNotFound;
        public EmailNotFoundException(string message) : base(message)
        {

        }
    }
}
