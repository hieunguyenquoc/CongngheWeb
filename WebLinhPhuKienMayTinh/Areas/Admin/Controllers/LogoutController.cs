﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebLinhPhuKienMayTinh.Common;
namespace WebLinhPhuKienMayTinh.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Logout
        public ActionResult Logout()
        { 
            Session[CommonConstants.USER_SESSION]=null;
            
            return Redirect("/Admin/Login");
            
        }
    }
}