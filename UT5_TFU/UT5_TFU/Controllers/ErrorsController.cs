using Microsoft.AspNetCore.Mvc;

namespace UT5_TFU.Controllers;

public class ErrorsControllers : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}