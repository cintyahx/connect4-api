using Microsoft.AspNetCore.Mvc;

namespace Connect4.API.WebAPI.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected string ActionName(string methodName)
        => methodName.Replace("Async", string.Empty);

    protected string ControllerName(string methodName)
        => methodName.Replace("Controller", string.Empty);
}