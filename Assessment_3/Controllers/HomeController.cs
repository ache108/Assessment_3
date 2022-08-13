using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Assessment3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Welcome to the contacts page.";

            return View();
        }

        public ActionResult Listing()
        {
            ViewBag.Message = "Welcome to the listings page.";

            return View();
        }





        static async Task Main()
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("test@gmail.com", "DX Team"),
                Subject = "Sending with Twilio SendGrid is Fun",
                PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            msg.AddTo(new EmailAddress("test@example.com", "Test User"));


            msg.AddAttachment("balance_001.pdf",
                                  "TG9yZW0gaXBzdW0gZG9sb3Igc2l0IGFtZXQsIGNvbnNlY3RldHVyIGFkaXBpc2NpbmcgZWxpdC4gQ3JhcyBwdW12",
                                  "application/pdf",
                                  "attachment",
                                  "Balance Sheet");
            var attachments = new List<Attachment>();
            var attachment = new Attachment()
            {
                Content = "BwdW",
                Type = "image/png",
                Filename = "banner.png",
                Disposition = "inline",
                ContentId = "Banner"
            };
            attachments.Add(attachment);
            attachment = new Attachment()
            {
                Content = "BwdW2",
                Type = "image/png",
                Filename = "banner2.png",
                Disposition = "inline",
                ContentId = "Banner 2"
            };
            attachments.Add(attachment);
            msg.AddAttachments(attachments);


            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }


}