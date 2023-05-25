using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.OrderFeatures.Commands.CreateOrderCommand;
using FluentValidation;

namespace WebUI.Validators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.Weight)
            .NotEmpty()
            .InclusiveBetween(1, 1000000);

        RuleFor(x => x.DateTime)
            .NotEmpty()
            .LessThanOrEqualTo(date => DateTime.Now);

        RuleFor(x => x.Sender)
            .SetValidator(new ContactInfoValidator());
	
        RuleFor(x => x.Receiver)
            .SetValidator(new ContactInfoValidator());
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateOrderRequest>.CreateWithOptions((CreateOrderRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}