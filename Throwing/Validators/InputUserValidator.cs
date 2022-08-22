namespace Throwing.Validators;

using FluentValidation;
using Models;

public class InputUserValidator : AbstractValidator<InputUser>
{
    public InputUserValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(e => e.FullName)
            .NotEmpty();
        RuleFor(e => e.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(e => e.GithubUsername).NotEmpty();
    }
}