using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.WebUI.Controllers
{
    public class ExtrasController : Controller
    {
        // GET: Extras
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Invoice()
        {
            return View();
        }
        public ActionResult Mailbox()
        {
            return View();
        }
        public ActionResult MailboxCompose()
        {
            return View();
        }
        public ActionResult MailboxInbox()
        {
            return View();
        }
        public ActionResult MailboxView()
        {
            return View();
        }
        //public ActionResult Profile()
        //{
        //    return View();
        //}
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Timeline()
        {
            return View();
        }
        public ActionResult Todo()
        {
            return View();
        }
        public ActionResult CodeEditor()
        {
            return View();
        }
    }
}