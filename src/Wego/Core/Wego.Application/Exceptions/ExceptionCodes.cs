using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Exceptions
{
    public static class ExceptionCodes
    {
        public const string InternalError = "internal_error";
        public const string ValidationError = "validation_error";


        public const string CredentialInvalid = "credential_invalid";
        public const string EmailNotFound = "email_not_found";
        public const string PasswordsEquals = "passwords_equals";
        public const string UserAlreadyExists = "user_already_exists";
        public const string UserNotAuthentificated = "user_not_authentificated";
        public const string UserNotFound = "user_not_found";
        public const string TokenInvalid = "token_invalid";
    }
}
