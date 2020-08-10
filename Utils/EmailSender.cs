using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Wanderlust04.Utils
{
    public class EmailSender
    {

        private const string API_KEY = "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";


        public async Task Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
