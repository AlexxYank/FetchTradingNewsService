using System;
using Microsoft.AspNetCore.Mvc;

namespace AVATrade.API.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
    [HttpGet]
    [Route("/api/news")]
    public async Task<IActionResult> GetNews(int bankStatementId, [FromQuery] string email)
    {
        string temp = string.Empty;

        return null;
    }
}

