using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wanderlust04.Models;
using Wanderlust04.Utils;

namespace Wanderlust04.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            EmailSender es = new EmailSender();
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult SendEmail()
        {
            return View(new SendEmailViewModel());
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> SendEmail(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    await es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }

    }
