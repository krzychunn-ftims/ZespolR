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
        //// GET: Registration
        //public ActionResult Registration()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] UserTable user)
        //{
        //    bool Status = false;
        //    string message = "";
        //    //
        //    // Model Validation 
        //    if (ModelState.IsValid)
        //    {

        //        #region //Email is already Exist 
        //        var isExist = IsEmailExist(user.Email);
        //        if (isExist)
        //        {
        //            ModelState.AddModelError("EmailExist", "Email already exist");
        //            return View(user);
        //        }
        //        #endregion

        //        #region Generate Activation Code 
        //        user.ActivationCode = Guid.NewGuid();
        //        #endregion

        //        #region  Password Hashing 
        //        user.Password = Crypto.Hash(user.Password);

        //        #endregion
        //        user.IsEmailVeryfied = false;

        //        #region Save to Database
        //        using (ZespolREntities dc = new ZespolREntities())
        //        {
        //            dc.UserTable.Add(user);
        //            dc.SaveChanges();

        //            //Send Email to User
        //            SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
        //            message = "Rejestracja powiodla sie. Link aktywacyjny do konta " +
        //                " zostal wyslany na email " + user.Email;
        //            Status = true;
        //        }
        //        #endregion
        //    }
        //    else
        //    {
        //        message = "Invalid Request";
        //    }

        //    ViewBag.Message = message;
        //    ViewBag.Status = Status;
        //    return View(user);
        //}

        //[HttpGet]
        //public ActionResult VerifyAccount(string id)
        //{
        //    bool Status = false;
        //    using (InzEntities dc = new InzEntities())
        //    {
        //        dc.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
        //                                                        // Confirm password does not match issue on save changes
        //        var v = dc.UserTable.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
        //        if (v != null)
        //        {
        //            v.IsEmailVeryfied = true;
        //            dc.SaveChanges();
        //            Status = true;
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Invalid Request";
        //        }
        //    }
        //    ViewBag.Status = Status;
        //    return View();
        //}




        [HttpGet]
        public ActionResult Login()
        {

            return View();
            //return PartialView("~/Views/Registration/Login.cshtml");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Moderator login, string ReturnUrl = "")
        {
            string message = "";
            using (ZespolREntities dc = new ZespolREntities())
            {
                var v = dc.Moderator.Where(a => a.mod_name == login.mod_name).FirstOrDefault();
                var x = dc.Editor.Where(a => a.ed_name == login.mod_name).FirstOrDefault();
                if (v != null)
                {
                    //if (!v.IsEmailVeryfied)
                    //{
                    //    ViewBag.Message = "Zweryfikuj najpierw swoj email";
                    //    return View();
                    //}
                    if (string.Compare(login.mod_password, v.mod_password) == 0)
                    {

                        int timeout = true ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.mod_name, true, timeout);
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
                            return RedirectToAction("Index", "Home");
                        }
                    }



                    else
                    {
                        message = "Zle haslo";
                    }
                }
                else if (x != null)
                {
                    if (string.Compare(login.mod_password, x.ed_password) == 0)
                    {

                        int timeout = true ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.mod_name, true, timeout);
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
                            return RedirectToAction("Index", "Home");
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

        //[NonAction]
        //public bool IsEmailExist(string Email)
        //{
        //    using (ZespolREntities dc = new ZespolREntities())
        //    {
        //        var v = dc.UserTable.Where(a => a.Email == Email).FirstOrDefault();
        //        return v != null;
        //    }
        //}

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/Registration/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("krzysztofjanmajewski@gmail.com", "Klub muzyczny");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "ge4fkt33"; // Replace with actual password
            string subject = "Twoje konto zostalo utworzone!";

            string body = "<br/><br/>Konto zostalo" +
                " utworzone. Kliknij w ponizszy link, aby je aktywowac" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}