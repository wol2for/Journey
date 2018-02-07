using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace Journey.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region -- SendMail --

        [HttpPost]
        public async Task<EmptyResult> SendMail(string name, string email, string subject, string messages)
        {

            StringBuilder body = BodyMessage(name, email, subject, messages);
            MailMessage message = MailMessage(name, email, body);
            using (var smtp = new SmtpClient())
            {
                //////!!!!!!!!!!!!!!!!!
                await smtp.SendMailAsync(message);
            }

            return new EmptyResult();
        }

        [NonAction]
        private static MailMessage MailMessage(string name,string email,StringBuilder messages)
        {
            var message = new MailMessage();
            message.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings.Get("Email")));
            message.IsBodyHtml = true;
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("Email"));
            message.Subject = name + " прислал сообщение! " + email;
            message.Body = string.Format(messages.ToString());
            message.IsBodyHtml = true;
            return message;
        }
        [NonAction]
        private StringBuilder BodyMessage(string name, string email, string subject, string messages)
        {
            StringBuilder body = new StringBuilder();
            body.AppendFormat("<p><h3>Name: {0}</h3><br/> <h3>email: {1}</h3><br/> <h3>тема: {2}</h3><br/> <h3>сообщение: {3}</h3></p>", name, email, subject, messages);
            return body;
        }

        #endregion
    }
}