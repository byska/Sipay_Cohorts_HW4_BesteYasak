using FluentValidation;
using Sipay_Cohorts_HW4.Api.BookOperations;
using Sipay_Cohorts_HW4.Entities.Enums;
using System.Data;

namespace Sipay_Cohorts_HW4.Api.Validator
{
    public class UpdateBookCommandValidator :AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0).LessThan(Count());
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);


        }
        private int Count()
        {
            int enumELementCount = Enum.GetValues(typeof(Genre)).Length;
            return enumELementCount;
        }
    }
}
