using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Features.Locations.Queries
{
    public class GetLocationsByQueryListQueryValidator : AbstractValidator<GetLocationsByQueryListQuery>
    {
        public GetLocationsByQueryListQueryValidator()
        {
            RuleFor(x => x.Query).NotNull().NotEmpty();
            RuleFor(x => x.Query).MinimumLength(2);
        }
    
    }
}
