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
