using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}