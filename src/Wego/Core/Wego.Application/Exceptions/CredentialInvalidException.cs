using System.Diagnostics.CodeAnalysis;

namespace Wego.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CredentialInvalidException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.CredentialInvalid;
        public CredentialInvalidException(string message) : base(message)
        {

        }
    }
}
