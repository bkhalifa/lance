using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wego.Application.Features.Locations.Queries
{
    public class GetLocationsByCodeListQueryValidator : AbstractValidator<GetLocationsByCodeListQuery>
    {
        public GetLocationsByCodeListQueryValidator()
        {
            RuleFor(x => x.Codes).NotNull().NotEmpty();
        } 
    }
}
