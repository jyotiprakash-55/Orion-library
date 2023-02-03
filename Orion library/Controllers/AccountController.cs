using Orion_library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orion_library.Controllers
{
    public class AccountController : Controller
    {
        MyDbContext MyDbObj = new MyDbContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUserRecord UserObj)
        {

            var user = MyDbObj.AppUserRecords.Where(m => m.UserName == UserObj.UserName).FirstOrDefault();
            if (user != null )
            {
                byte[] b = Convert.FromBase64String(user.Password);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                if (decrypted == UserObj.Password)
                {
                    Session["UserName"] = UserObj.UserName;
                    return RedirectToAction("DashBoard", "DashboardDisplay");
                }
                else
                {
                    ViewBag.ErrorMessage = "Error:Invalid Password";
                    return View("Login");
                }
            }
            ViewBag.ErrorMessage = "Error:Invalid Email and  Password";
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
   
}




