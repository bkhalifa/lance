namespace Wego.Application.Exceptions;

public class GoogleCaptchaException: BaseException
{
    public override string ErrorCode => ExceptionCodes.CaptchaException;
    public GoogleCaptchaException(string message) : base(message)
    {

    }
}
