namespace NotThrowing.Services;

using FluentValidation;
using LanguageExt.Common;
using Models;
using Octokit;
using Validators;

public interface IUserRequester
{
    Task<Result<bool>> MakeRequest(InputUser user);
}

class UserRequester : IUserRequester
{
    private readonly IValidator<InputUser> _validator;
    private readonly GitHubClient _gitHubClient;

    public UserRequester(IValidator<InputUser> validator)
    {
        _validator = validator;
        _gitHubClient = new GitHubClient(new ProductHeaderValue("test"));
    }
    
    public async Task<Result<bool>> MakeRequest(InputUser user)
    {
        var validationResult = await _validator.ValidateAsync(user);

        if (!validationResult.IsValid)
        {
            var validationException = new ValidationDataException(validationResult.Errors);
            return new Result<bool>(validationException);
        }
        
        var userRes = await _gitHubClient.User.Get(user.GithubUsername);
        return new Result<bool>(false);
    }
}

public static class AddServices
{
    public static IServiceCollection RegisterUserRequest(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRequester, UserRequester>();
        serviceCollection.AddScoped<IValidator<InputUser>, InputUserValidator>();
        return serviceCollection;
    }
}