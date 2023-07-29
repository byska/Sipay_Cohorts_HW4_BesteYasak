using FluentValidation;
using Sipay_Cohorts_HW4.Api.BookOperations;

namespace Sipay_Cohorts_HW4.Api.Validator
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
