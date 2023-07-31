namespace Wego.Application.Exceptions
{
    public class LockedOutException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.LockoutUser;
        public LockedOutException(string message) : base(message)
        {

        }
    }
}

