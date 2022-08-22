using Microsoft.AspNetCore.Mvc;

namespace NotThrowing.Controllers;

using Models;
using Services;

public class UserRequesterController : ControllerBase
{
    public async Task<IActionResult> Get([FromServices] IUserRequester userRequester, [FromBody] InputUser inputUser)
    {
        return await userRequester.MakeRequest(inputUser)
            ? Ok()
            : NotFound();
    }
}