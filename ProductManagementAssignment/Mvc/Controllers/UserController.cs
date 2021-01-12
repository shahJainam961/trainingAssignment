using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc.Models;
using WebApi.Models;

namespace Mvc.Controllers
{
    public class UserController : Controller
    {
        dataEntities db = new dataEntities();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // POST: User

        [HttpPost]
        public ActionResult Index(MvcDataModels user)
        {
            if (ModelState.IsValid)
            {
                var searchdata = db.user_tbl.FirstOrDefault(m => m.Email == user.Email);
                if (searchdata != null)
                {
                    ViewBag.alert = ("You are Already Registered.");
                    return View();
                }
                HttpResponseMessage response = MvcGlobalVariables.webapiclient.PostAsJsonAsync("User", user).Result;
                TempData["success"] = "You are Registered.";
                return RedirectToAction("Login");
            }
            
            return View();
        }

        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //Post: Login

        [HttpPost]
        public ActionResult Login(MvcDataModels mvcData)
        {

            var searchdata = db.user_tbl.FirstOrDefault(m => m.Email == mvcData.Email && m.Password == mvcData.Password);
            if(searchdata!=null)
            {
                Session["Name"] = mvcData.Email.ToString();
                FormsAuthentication.SetAuthCookie(mvcData.Email, false);
                return RedirectToAction("dashboard");
            }
            ViewBag.alert = ("Please Enter Valid Username & Password.");
            return View();
        }

        //GET: Dashboard

        [Authorize]
        public ActionResult dashboard()
        {
            return View();
        }

        // LogOut
        public ActionResult LogOut()
        {
            Session.Abandon();
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}