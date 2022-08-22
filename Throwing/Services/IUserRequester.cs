namespace Throwing.Services;

using FluentValidation;
using Models;
using Octokit;
using Throwing.Middleware;
using Validators;

public interface IUserRequester
{
    Task<bool> MakeRequest(InputUser user);
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
    
    public async Task<bool> MakeRequest(InputUser user)
    {
        var validationResult = await _validator.ValidateAsync(user);

        if (!validationResult.IsValid)
        {
            throw new ValidationDataException(validationResult.Errors);
        }
        
        var userRes = await _gitHubClient.User.Get(user.GithubUsername);
        return userRes is null;
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