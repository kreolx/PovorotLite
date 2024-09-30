using Microsoft.AspNetCore.Mvc;
using PL.Engine.Storage.DbContexts;

namespace PL.Api.Controllers;

[Route("graphql")]
[ApiController]
public class RequestController : Controller
{
    private readonly ApplicationDbContext _db;

    public RequestController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Post()
    {
        return Ok();
    }
}