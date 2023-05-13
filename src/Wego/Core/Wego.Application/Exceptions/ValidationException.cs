using FluentValidation.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wego.Application.Exceptions
{
    public class ValidationException : BaseException
    {
        public override string ErrorCode => ExceptionCodes.ValidationError;
        public Dictionary<string, string> ValdationErrors { get; set; }
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            ValdationErrors = new Dictionary<string, string>();
        }


        public ValidationException(IEnumerable<ValidationFailure> validationResult) : this()
        {
            ValdationErrors = new Dictionary<string, string>();

            foreach (var validationError in validationResult)
            {
                ValdationErrors.Add(validationError.ErrorCode,validationError.ErrorMessage);
            }
        }

        public ValidationException(Dictionary<string, string> errors)
        {
            ValdationErrors = errors ?? new Dictionary<string, string>();
        }
    }
}
