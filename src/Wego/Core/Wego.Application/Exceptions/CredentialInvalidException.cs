using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CredentialInvalidException : ApplicationException
    {
        public CredentialInvalidException(string message) : base(message)
        {

        }
    }
}
