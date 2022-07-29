using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    [NoDirectAccess]
    [AuthorizeAction1FilterAttribute]
    [Authorize]
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Settings(int? isSuccess)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            var Data = DB.tblSettings.Where(x => x.isActive == true).FirstOrDefault();
            ViewBag.FontStyle = DB.tblFontStyles.Where(x => x.isActive == true).ToList();
            if (isSuccess == 1)
            {
                ViewBag.Error = "Record Successfully Updated!!!";
            }



            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateSetting(tblSetting Setting)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblSetting Data = new tblSetting();
            tblRole Foreign = new tblRole();
            try
            {
                ViewBag.FontStyle = DB.tblFontStyles.Where(x => x.isActive == true).ToList();
                if (Setting.IsActive1 == null)
                {
                    Setting.IsActive1 = false;
                }
                //Foreign = DB.tblRoles.Where(x => x.RoleId == Setting.RoleId).FirstOrDefault();
                //Data.tblRole = Foreign;
                Data = DB.tblSettings.Select(r => r).Where(x => x.SettingId == Setting.SettingId).FirstOrDefault();
                Data.SettingId = Setting.SettingId;
                Data.DateFormat = Setting.DateFormat;
                Data.ReportsDateFormat = Setting.ReportsDateFormat;
                Data.NextWSA = Setting.NextWSA;
                Data.NextPassport = Setting.NextPassport;
                Data.NumberOfRetrieves = Setting.NumberOfRetrieves;
                Data.LetterCase = Setting.LetterCase;
                Data.FontStyle = Setting.FontStyle;
                Data.FontSize = Setting.FontSize;
                Data.Email = Setting.Email;
                Data.Password = Setting.Password;
                Data.SMTP = Setting.SMTP;
                Data.Port = Setting.Port;
                Data.NextCC = Setting.NextCC;
                Data.NextBC = Setting.NextBC;
                Data.NextMC = Setting.NextMC;
                Data.IsActive1 = Setting.IsActive1;
                DB.Entry(Data);
                DB.SaveChanges();

                HttpCookie cookie = new HttpCookie("Settings");

                cookie["DateFormat"] = DB.tblSettings.Select(r => r.DateFormat).FirstOrDefault();
                cookie["ReportsDateFormat"] = DB.tblSettings.Select(r => r.ReportsDateFormat).FirstOrDefault();
                cookie["WSA"] = DB.tblSettings.Select(r => r.NextWSA).FirstOrDefault();
                cookie["Retrieves"] = DB.tblSettings.Select(r => r.NumberOfRetrieves).FirstOrDefault();
                cookie["FontStyle"] = DB.tblSettings.Select(r => r.FontStyle).FirstOrDefault();
                cookie["FontSize"] = DB.tblSettings.Select(r => r.FontSize).FirstOrDefault();
                // This cookie will remain  for one month.
                cookie.Expires = DateTime.Now.AddMonths(1);

                // Add it to the current web response.
                Response.Cookies.Add(cookie);

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("Settings", new { isSuccess = 1 });
        }
    }
}