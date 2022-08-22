namespace Throwing.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Route("/user")]
public class UserRequesterController : ControllerBase
{
    [HttpPost("getUser")]
    public async Task<IActionResult> Post([FromServices] IUserRequester userRequester, [FromBody] InputUser inputUser)
    {
        return await userRequester.MakeRequest(inputUser)
            ? Ok()
            : NotFound();
    }
}