using Microsoft.AspNetCore.Mvc;

namespace NotThrowing.Controllers;

using Models;
using Services;
using Validators;

[Route("/user")]
public class UserRequesterController : ControllerBase
{
    [HttpPost("getUser")]
    public async Task<IActionResult> Post(
        [FromServices] IUserRequester userRequester,
        [FromBody] InputUser inputUser)
    {
        var makeRequest = await userRequester.MakeRequest(inputUser);

        return makeRequest.Match<IActionResult>(e => e ? Ok() : NotFound(),
            ex => new ObjectResult(((ValidationDataException)ex).Failures.Select(m => m.ErrorMessage))
        {
            StatusCode = 418
        });
    }
}