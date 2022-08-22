namespace NotThrowing.Validators;

using System.Text.RegularExpressions;
using FluentValidation;
using Models;

public class InputUserValidator : AbstractValidator<InputUser>
{
    public InputUserValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(e => e.FullName)
            .NotEmpty()
            .Matches("^[a-z0-9 ,.'-]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        RuleFor(e => e.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(e => e.GithubUsername).NotEmpty();
    }
}