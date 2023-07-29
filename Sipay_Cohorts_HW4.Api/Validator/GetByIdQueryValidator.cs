using FluentValidation;
using Sipay_Cohorts_HW4.Api.BookOperations;

namespace Sipay_Cohorts_HW4.Api.Validator
{
    public class GetByIdQueryValidator :AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
