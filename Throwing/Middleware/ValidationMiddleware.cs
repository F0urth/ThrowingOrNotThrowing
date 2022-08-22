namespace Throwing.Middleware;

public class ValidationMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationDataException ex)
        {
            context.Response.StatusCode = 418;
            await context.Response.WriteAsJsonAsync(ex.Failures.Select(e => e.ErrorMessage));
        }
    }
}