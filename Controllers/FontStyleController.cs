using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    [NoDirectAccess]
    [AuthorizeAction1FilterAttribute]
    [Authorize]
    public class FontStyleController : Controller
    {
        // GET: FontStyle
        public ActionResult FontStyles(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblFontStyles.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.FError = FError;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateFontStyle(tblFontStyle FontStyle)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblFontStyle Data = new tblFontStyle();
            tblFontStyle check = new tblFontStyle();

            try
            {
                ViewBag.User = Session["User"];
                if (FontStyle.FontStyleId != 0)
                {

                    check = DB.tblFontStyles.Select(r => r).Where(x => x.Code == FontStyle.Code).FirstOrDefault();
                    if (check == null || check.FontStyleId == FontStyle.FontStyleId)
                    {
                        Data = DB.tblFontStyles.Select(r => r).Where(x => x.FontStyleId == FontStyle.FontStyleId).FirstOrDefault();

                        Data.Name = FontStyle.Name;
                        Data.Code = FontStyle.Code;
                        Data.isActive = true;
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.EditBy=  ViewBag.User.UserId;
                        DB.Entry(Data);
                        DB.SaveChanges();

                    }
                    else
                    {
                        return Json(1);
                    }

                }
                else
                {

                    if (DB.tblFontStyles.Select(r => r).Where(x => x.Code == FontStyle.Code).FirstOrDefault() == null)
                    {
                        Data = FontStyle;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.CreatedBy= ViewBag.User.UserId;
                        Data.isActive = true;
                        DB.tblFontStyles.Add(Data);
                        DB.SaveChanges();

                    }
                    else
                    {
                        return Json(1);
                    }
                }

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }




            return Json(0);
        }


        [HttpPost]
        public ActionResult DeleteFontStyle(tblFontStyle FontStyle)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblFontStyle Data = new tblFontStyle();

            try
            {
                Data = DB.tblFontStyles.Select(r => r).Where(x => x.FontStyleId == FontStyle.FontStyleId).FirstOrDefault();
                DB.Entry(Data).State = EntityState.Deleted;
                DB.SaveChanges();
                //if (DB.tblSettings.Where(x => x.FontStyle== FontStyle.FontStyleId).FirstOrDefault() == null)
                //{
                   
                //}
                //else
                //{
                //    return Json(2);
                //}

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return Json(0);
        }
    }
}