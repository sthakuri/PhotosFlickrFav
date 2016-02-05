using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Photos.ePaila.com.Models;
using Photos.ePaila.com.Models.Channel;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Photos.ePaila.com.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.AddChannel(new Flickr());
            return View(model);
        }

        public async Task SendEmail(string name, string email, string message)
        {
            //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            //var msg = new MailMessage();
            //msg.To.Add(new MailAddress(""));  // replace with valid value 
            //msg.From = new MailAddress(email);  // replace with valid value
            //msg.Subject = "New Message from ePaila";
            //msg.Body = string.Format(body, name, email, message);
            //msg.IsBodyHtml = true;
            //using (var smtp = new SmtpClient())
            //{
            //    var credential = new NetworkCredential
            //        {
            //            UserName = "", // replace with valid value
            //            Password = "" // replace with valid value
            //        };
            //    smtp.Credentials = credential;
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.EnableSsl = true;
            //    await smtp.SendMailAsync(msg);
            //}
        }
    }
}
