namespace NotThrowing.Services;

using FluentValidation;
using Models;
using Validators;

public interface IUserRequester
{
    Task<bool> MakeRequest(InputUser user);
}

class UserRequester : IUserRequester
{
    private readonly IValidator<InputUser> _validator;

    public UserRequester(IValidator<InputUser> validator)
    {
        _validator = validator;
    }
    
    public async Task<bool> MakeRequest(InputUser user)
    {
        throw new NotImplementedException();
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