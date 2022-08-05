using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    public class EyeController : Controller
    {
        // GET: Eye
        public ActionResult Eyes(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblEyes.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.FError = FError;
            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateEye(tblEye Eye)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblEye Data = new tblEye();
            tblEye check = new tblEye();

            try
            {
                if (Eye.EyeId != 0)
                {

                    check = DB.tblEyes.Select(r => r).Where(x => x.Code == Eye.Code).FirstOrDefault();
                    if (check == null || check.EyeId == Eye.EyeId)
                    {
                        Data = DB.tblEyes.Select(r => r).Where(x => x.EyeId == Eye.EyeId).FirstOrDefault();

                        Data.Name = Eye.Name;
                        Data.Code = Eye.Code;
                        Data.Abbreviation = Eye.Abbreviation;
                        Data.isActive = true;
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
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

                    if (DB.tblEyes.Select(r => r).Where(x => x.Code == Eye.Code).FirstOrDefault() == null)
                    {
                        Data = Eye;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblEyes.Add(Data);
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
        public ActionResult DeleteEye(tblEye Eye)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblEye Data = new tblEye();

            try
            {
                if (DB.tblPersons.Where(x => x.Eyes == Eye.EyeId).FirstOrDefault() == null)
                {
                    Data = DB.tblEyes.Select(r => r).Where(x => x.EyeId == Eye.EyeId).FirstOrDefault();
                    DB.Entry(Data).State = EntityState.Deleted;
                    DB.SaveChanges();
                }
                else
                {
                    return Json(2);
                }

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