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
