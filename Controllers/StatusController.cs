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
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Status(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblStatus.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.FError = FError;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateStatus(tblStatus Status)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblStatus Data = new tblStatus();
            tblStatus check = new tblStatus();

            try
            {
                if (Status.StatusId != 0)
                {

                    check = DB.tblStatus.Select(r => r).Where(x => x.Code == Status.Code).FirstOrDefault();
                    if (check == null || check.StatusId == Status.StatusId)
                    {
                        Data = DB.tblStatus.Select(r => r).Where(x => x.StatusId == Status.StatusId).FirstOrDefault();

                        Data.Name = Status.Name;
                        Data.Code = Status.Code;
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

                    if (DB.tblStatus.Select(r => r).Where(x => x.Code == Status.Code).FirstOrDefault() == null)
                    {
                        Data = Status;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblStatus.Add(Data);
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
        public ActionResult DeleteStatus(tblStatus Status)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblStatus Data = new tblStatus();

            try
            {
                if (DB.tblPersons.Where(x => x.Status == Status.StatusId).FirstOrDefault() == null)
                {
                    Data = DB.tblStatus.Select(r => r).Where(x => x.StatusId == Status.StatusId).FirstOrDefault();
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