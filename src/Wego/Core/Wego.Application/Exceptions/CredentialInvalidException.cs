using Microsoft.AspNetCore.Connections.Features;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
