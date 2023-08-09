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
