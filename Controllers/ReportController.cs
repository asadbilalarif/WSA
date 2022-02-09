using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    public class ReportController : Controller
    {
        WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        // GET: Report
        public ActionResult List()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult List(int ReportList)
        {
            List<ReportList> RL = new List<ReportList>();
            try
            {
                ViewBag.State = ReportList;
                if (ReportList == 1)
                {
                    RL = (from o in DB.tblOccupations
                              where o.isActive== true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                else if (ReportList == 2)
                {
                    RL = (from o in DB.tblCountries
                          where o.isActive == true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                else if (ReportList == 3)
                {
                    RL = (from o in DB.tblProducts
                          where o.isActive == true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                else if (ReportList == 4)
                {
                    RL = (from o in DB.tblProductTypes
                          where o.isActive == true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                else if (ReportList == 5)
                {
                    RL = (from o in DB.tblEyes
                          where o.isActive == true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                else if (ReportList == 6)
                {
                    RL = (from o in DB.tblStatus
                          where o.isActive == true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                else
                {
                    RL = (from o in DB.tblSex
                          where o.isActive == true
                          select new ReportList
                          {
                              Code = o.Code,
                              Name = o.Name,

                          }).ToList();
                }
                return View(RL);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            
            return View(RL);
        }

        public ActionResult ProductList()
        {
            ViewBag.SelectReport = 0;
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ProductList(int SelectReport,int SelectStatus,int SearchByDate,DateTime BDate,DateTime EDate)
        {
            List<tblPerson> PL = new List<tblPerson>();
            try
            {

                ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
                ViewBag.SelectReport = SelectReport;
                ViewBag.SelectStatus = SelectStatus;
                ViewBag.SearchByDate = SearchByDate;
                ViewBag.BDate = BDate;
                ViewBag.EDate = EDate;
                if(SelectReport==1)
                {
                    PL = DB.tblPersons.Where(x => x.isActive == true && x.LastModifiedDate == DateTime.Now &&x.Status==SelectStatus).ToList();
                }
                else
                {
                    if(SearchByDate==1)
                    {
                        PL = DB.tblPersons.Where(x => x.isActive == true && x.EntryDate >= BDate &&x.EntryDate<=EDate && x.Status == SelectStatus).ToList();
                    }
                    else
                    {
                        PL = DB.tblPersons.Where(x => x.isActive == true && x.LastModifiedDate >= BDate && x.LastModifiedDate <= EDate && x.Status == SelectStatus).ToList();
                    }
                }
                return View(PL);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View(PL);
        }

        public ActionResult CustomSearch()
        {
            var PL= DB.tblPersons.Where(x => x.isActive == true).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            return View(PL);
        }
    }
}