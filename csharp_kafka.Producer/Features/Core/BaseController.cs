﻿namespace csharp_kafka.Producer.Features.Core;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Content(object model)
    {
        return Content(model.ToJson(), "application/json");
    }
}
