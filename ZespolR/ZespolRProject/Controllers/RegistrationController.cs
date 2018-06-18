using ZespolRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ZespolRProject.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "user_id,email,password,isEditor")] Users user)
        {
            bool Status = false;
            string message = "";

            if (ModelState.IsValid)
            {

                using (ZespolREntities dc = new ZespolREntities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                }
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return RedirectToAction("Registered", "Home");
        }



        [HttpGet]
        public ActionResult Login()
        {

            return View();
            //return PartialView("~/Views/Registration/Login.cshtml");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (ZespolREntities dc = new ZespolREntities())
            {
                var v = dc.Users.Where(a => a.email == login.Email).FirstOrDefault();
                if (v != null)
                {
                //    if (!v.IsEmailVeryfied)
                //    {
                //        ViewBag.Message = "Zweryfikuj najpierw swoj email";
                //        return View();
                //    }
                    if (string.Compare(login.Password, v.password) == 0)
                    {

                        int timeout = false ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.Email, false, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {

                     
                            return RedirectToAction("Logged", "Home");
                        }
                    }
                    else
                    {
                        message = "Zle haslo";
                    }
                }
                else
                {
                    message = "Zla nazwa uzytkownika";
                }
            }
            ViewBag.Message = message;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Registration");
        }

    }
}