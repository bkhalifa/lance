namespace Wego.Application.Exceptions;

public class CaptchaException : BaseException
{
    public override string ErrorCode => ExceptionCodes.CaptchaException;
    public CaptchaException(string message) : base(message)
    {

    }
}

