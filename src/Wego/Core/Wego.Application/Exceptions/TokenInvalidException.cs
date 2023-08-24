using System.Diagnostics.CodeAnalysis;

namespace Wego.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class TokenInvalidException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.TokenInvalid;
        public TokenInvalidException(string message) : base(message)
        {

        }
    }
}
