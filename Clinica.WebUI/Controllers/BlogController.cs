﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.WebUI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogArticles()
        {
            return View();
        }
        public ActionResult BlogArticleView()
        {
            return View();
        }
        public ActionResult BlogPost()
        {
            return View();
        }
    }
}