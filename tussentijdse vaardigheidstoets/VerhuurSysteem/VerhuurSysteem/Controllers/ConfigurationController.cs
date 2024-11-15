using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    [Route("environment-message")]
    public ActionResult GetDatabaseConfiguration()
    {
        var type = configuration["environment:Type"];
        var connectionString = configuration["Environment:ConnectionString"];
        return Ok(new { Type = type, ConnectionString = connectionString });
    }
}
