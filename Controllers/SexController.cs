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
    public class SexController : Controller
    {
        // GET: Sex
        public ActionResult Sex(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblSex.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.FError = FError;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateSex(tblSex Sex)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblSex Data = new tblSex();
            tblSex check = new tblSex();

            try
            {
                if (Sex.SexId != 0)
                {

                    check = DB.tblSex.Select(r => r).Where(x => x.Code == Sex.Code).FirstOrDefault();
                    if (check == null || check.SexId == Sex.SexId)
                    {
                        Data = DB.tblSex.Select(r => r).Where(x => x.SexId == Sex.SexId).FirstOrDefault();

                        Data.Name = Sex.Name;
                        Data.Code = Sex.Code;
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

                    if (DB.tblSex.Select(r => r).Where(x => x.Code == Sex.Code).FirstOrDefault() == null)
                    {
                        Data = Sex;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblSex.Add(Data);
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
        public ActionResult DeleteSex(tblSex Sex)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblSex Data = new tblSex();

            try
            {
                if (DB.tblPersons.Where(x => x.Sex == Sex.SexId).FirstOrDefault() == null)
                {
                    Data = DB.tblSex.Select(r => r).Where(x => x.SexId == Sex.SexId).FirstOrDefault();
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