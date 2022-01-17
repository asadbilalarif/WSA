using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            string pass = null;
            

            try
            {
                if (Password != null)
                {
                    byte[] EncDataBtye = new byte[Password.Length];
                    EncDataBtye = System.Text.Encoding.UTF8.GetBytes(Password);
                    pass = Convert.ToBase64String(EncDataBtye);
                }

                if (DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.PIN== pass && x.isActive != false).FirstOrDefault() != null)
                {
                    var User = DB.tblUsers.Select(r => r).Where(x => x.Email == Email).FirstOrDefault();
                    
                    Session["User"] = DB.tblUsers.Select(r => r).Where(x => x.Email == Email).FirstOrDefault();
                    Session["Access"] = DB.tblAccessLevels.Select(r => r).Where(x => x.RoleId == User.RoleId).ToList();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var UserCheck = DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.PIN== pass).FirstOrDefault();
                    if (UserCheck != null && UserCheck.isActive == false)
                    {
                        ViewBag.Error = "User is in-active";
                    }
                    else
                    {
                        ViewBag.Error = "Invalid Email or Password";
                    }

                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string Email)
        {
            try
            {
                string SenderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string SenderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
                Client.EnableSsl = true;
                Client.Timeout = 100000;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.UseDefaultCredentials = false;
                Client.Credentials = new System.Net.NetworkCredential(SenderEmail, SenderPassword);
               
                string link = Request.Url.ToString();
                link = link.Replace("ForgetPassword", "ChangeForgetPassword");

                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(Email);
                string encrypted = Convert.ToBase64String(b);


                string body1 = "";
                body1 += "Welcome to World Service Organization!";
                body1 += "<br />To Change your password, please click on the button below: ";
                body1 += "<br /> <button style='padding: 10px 28px 11px 28px;color: #fff;background:rgba(40, 58, 90, 0.9);'><a style='color:white !important' href = '" + link + "?Email=" +encrypted+ "'>Change Account Password</a></button>";
                body1 += "<br /><br />Yours,<br />The WSO Team";

                string body = "";
                body += "<body  style='background-color:white !important'>";
                body += " <div>";
                //body += "<h3>Hello " + sa.ReceiveName + ",</h3>";
                body += " <table style='background-color: #f2f3f8; max-width:670px;' width='100%' border='0'  cellpadding='0' cellspacing='0'>";
                body += " <tbody> <tr style='background-color:rgba(40, 58, 90, 0.9);'><td style='padding: 0 35px; background-color:rgba(40, 58, 90, 0.9);'><a><h1 style ='color:white' > World Service Organization </h1>   </a></td> </tr>";
                body += "<tr style='color:#455056; font-size:15px;line-height:35px;text-align: center;'><td style='padding:6px;text-align: center;'></td></tr><tr style='color:#455056; font-size:15px;line-height:35px;text-align: center;'><td style='padding:6px;text-align: center;'>" + body1 + "</td></tr>";
                body += "  </tbody></table>";
                body += "</body>";


                MailMessage mailMessage = new MailMessage(SenderEmail, Email, "Forget Password Email", body);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.UTF8Encoding.UTF8;

                Client.Send(mailMessage);

                //mailMessage = new MailMessage(SenderEmail, Email, "Thank You Email", "Thank You for Contacting Us!!!");
                //mailMessage.IsBodyHtml = true;
                //mailMessage.BodyEncoding = System.Text.UTF8Encoding.UTF8;

                //Client.Send(mailMessage);

                return Redirect("ForgetPassword");
            }
            catch (Exception ex)
            {
                throw ex;
                // View();
            }
        }

        public ActionResult ChangePassword()
        {
            try
            {

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();
        }


        

        [HttpPost]
        public ActionResult ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword, string Email)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            string pass = null;
            try
            {
                

                byte[] EncDataBtye = new byte[OldPassword.Length];
                EncDataBtye = System.Text.Encoding.UTF8.GetBytes(OldPassword);
                pass = Convert.ToBase64String(EncDataBtye);
                tblUser Data = new tblUser();
                Data = DB.tblUsers.Select(r => r).Where(x => x.Email == Email && x.PIN == pass).FirstOrDefault();
                if (Data != null)
                {

                    if (NewPassword == ConfirmPassword)
                    {
                        EncDataBtye = new byte[NewPassword.Length];
                        EncDataBtye = System.Text.Encoding.UTF8.GetBytes(NewPassword);
                        pass = Convert.ToBase64String(EncDataBtye);
                    }
                    else
                    {
                        ViewBag.PError = "New Password and Confirm Password not Matched!!!";
                        return View();
                    }

                    Data.PIN = pass;
                    Data.EditDate = DateTime.Now;
                    DB.Entry(Data);
                    DB.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Old password is not Correct!!!";
                    return View();
                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View();
        }



        public ActionResult ChangeForgetPassword(string Email)
        {
            try
            {
                byte[] b = Convert.FromBase64String(Email);
                string decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);

                ViewBag.Email = decrypted;
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();
        }


        [HttpPost]
        public ActionResult ChangeForgetPassword(string NewPassword, string ConfirmPassword, string Email)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            string pass = null;
            try
            {


                byte[] EncDataBtye = null;
                tblUser Data = new tblUser();
                Data = DB.tblUsers.Select(r => r).Where(x => x.Email == Email).FirstOrDefault();
                if (Data != null)
                {

                    if (NewPassword == ConfirmPassword)
                    {
                        EncDataBtye = new byte[NewPassword.Length];
                        EncDataBtye = System.Text.Encoding.UTF8.GetBytes(NewPassword);
                        pass = Convert.ToBase64String(EncDataBtye);
                    }
                    else
                    {
                        ViewBag.PError = "New Password and Confirm Password not Matched!!!";
                        return View();
                    }

                    Data.PIN = pass;
                    Data.EditDate = DateTime.Now;
                    DB.Entry(Data);
                    DB.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.Error = "Old password is not Correct!!!";
                    return View();
                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View();
        }


    }
}