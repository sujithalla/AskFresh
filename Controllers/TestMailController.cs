using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MailKit.Net.Smtp;
using MimeKit;

namespace AskFresh.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestMailController : ControllerBase
    {
        [HttpPost]
        public ActionResult SendEmail()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("TheCodeBuzz", "sriram.sakinala@gmail.com"));
                message.To.Add(new MailboxAddress("TheCodeBuzz", "sriram.sakinala@outlook.com"));
                message.Subject = "My First Email";
                message.Body = new TextPart("plain")
                {
                    Text = "Email is Working Fine"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect("smtp.gmail.com", 587, false);

                    client.Authenticate("emailaddress@gmail.com", "password");
                    //SMTP server authentication if needed
                    // client.Authenticate("xxxx@gmail.com", "xxxxx");

                    client.Send(message);

                    client.Disconnect(true);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Error occured");
            }

            return Ok(true);
        }
    }
}
