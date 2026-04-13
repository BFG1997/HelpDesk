using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress().MaximumLength(100);

            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(6).MaximumLength(50);

            RuleFor(x => x.DisplayName)
                .NotEmpty().MaximumLength(100);
        }
    }
}
