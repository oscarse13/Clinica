﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.WebUI.Controllers
{
    public class EcommerceController : Controller
    {
        // GET: Ecommerce
        public ActionResult EcommerceOrders()
        {
            return View();
        }
        public ActionResult EcommerceOrderView()
        {
            return View();
        }
        public ActionResult EcommerceProducts()
        {
            return View();
        }
        public ActionResult EcommerceProductView()
        {
            return View();
        }
    }
}