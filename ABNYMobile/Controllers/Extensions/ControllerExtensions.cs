using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABNYMobile.Models;

namespace ABNYMobile.Controllers
{
    public static class ControllerExtensions
    {
        public static MockRepository GetRepoFromSession(this Controller ctrl)
        {
            var repo = ctrl.Session["repo"] as MockRepository;
            Debug.Assert(repo != null);
            return repo;   
        }
    }
}