using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
namespace OefeningConfiguration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Rechtstreeks lezen uit de appsettings.json
        [HttpGet]
        [Route("direct-from-appsettings")]
        public ActionResult GetSettingsDirectly()
        {
            var appName = _configuration["ApplicationSettings:AppName"];
            var version = _configuration["ApplicationSettings:Version"];
            var maxUsers = _configuration["ApplicationSettings:MaxUsers"];

            return Ok(new
            {
                AppName = appName,
                Version = version,
                MaxUsers = maxUsers
            });
        }

        //Gebruiken van Configuration Binder.Bind()
        [HttpGet]
        [Route("using-binder")]
        public ActionResult GetSettingsUsingBinder()
        {
            var appSettings = new ApplicationSettings();
            _configuration.GetSection("ApplicationSettings").Bind(appSettings);

            return Ok(new
            {
                appSettings.AppName,
                appSettings.Version,
                appSettings.MaxUsers
            });
        }
    }
}
