﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OefeningNamedOptions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailConfigurationsController : ControllerBase
    {
        private readonly IOptionsSnapshot<EmailOptions> _options;

        public EmailConfigurationsController(IOptionsSnapshot<EmailOptions> options)
        {
            _options = options;
        }

        [HttpGet]
        public IActionResult GetEmailConfigurations()
        {
            var gmailOptions = _options.Get(EmailOptions.GmailSectionName);
            var outlookOptions = _options.Get(EmailOptions.OutlookSectionName);

            return Ok(new
            {
                GmailConfiguration = gmailOptions,
                OutlookConfiguration = outlookOptions
            });
        }
    }
}
