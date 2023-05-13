using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public class BaseException : Exception
    {      
        public virtual string ErrorCode => ExceptionCodes.InternalError;
        public BaseException()
        {
            
        }
        public BaseException(string message) : base(message)
        {

        }
    }
}
