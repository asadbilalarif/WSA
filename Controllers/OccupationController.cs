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
    public class OccupationController : Controller
    {
        // GET: Occupation
        public ActionResult Occupations(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblOccupations.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.FError = FError;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateOccupation(tblOccupation Occupation)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblOccupation Data = new tblOccupation();
            tblOccupation check = new tblOccupation();

            try
            {
                if (Occupation.OccupationId != 0)
                {

                    check = DB.tblOccupations.Select(r => r).Where(x => x.Code == Occupation.Code).FirstOrDefault();
                    if (check == null || check.OccupationId == Occupation.OccupationId)
                    {
                        Data = DB.tblOccupations.Select(r => r).Where(x => x.OccupationId == Occupation.OccupationId).FirstOrDefault();

                        Data.Name = Occupation.Name;
                        Data.Code = Occupation.Code;
                        Data.Abbreviation = Occupation.Abbreviation;
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

                    if (DB.tblOccupations.Select(r => r).Where(x => x.Code == Occupation.Code).FirstOrDefault() == null)
                    {
                        Data = Occupation;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblOccupations.Add(Data);
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
        public ActionResult DeleteOccupation(tblOccupation Occupation)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblOccupation Data = new tblOccupation();

            try
            {

                if (DB.tblPersons.Where(x => x.OccupationCode == Occupation.OccupationId).FirstOrDefault() == null)
                {
                    Data = DB.tblOccupations.Select(r => r).Where(x => x.OccupationId == Occupation.OccupationId).FirstOrDefault();
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