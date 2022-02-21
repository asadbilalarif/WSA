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
    public class ReportController : Controller
    {
        WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        // GET: Report
        public ActionResult List()
        {
            ViewBag.State = 0;
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
            ViewBag.BDate = DateTime.Now;
            ViewBag.EDate = DateTime.Now;
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
            ViewBag.FieldtoSearch = "p.LastName";
            ViewBag.SearchValue = "";
            //var PL= DB.tblPersons.Where(x => x.isActive == true).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CustomSearch(string FieldtoSearch,string SearchValue)
        {
            ViewBag.FieldtoSearch = FieldtoSearch;
            ViewBag.SearchValue = SearchValue;

            List<CustomSearchLeftJoin_Result> PL = DB.CustomSearchLeftJoin(FieldtoSearch, SearchValue).ToList();
            //ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            return View(PL);
        }

        public ActionResult CountrySummary()
        {
            ViewBag.SelectReport = 0;
            ViewBag.SearchbyCountry = 0;
            ViewBag.BDate = DateTime.Now;
            ViewBag.EDate = DateTime.Now;
            var PL = DB.tblPersons.Where(x => x.isActive == true).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
            return View();
        }


        [HttpPost]
        public ActionResult CountrySummary( DateTime BDate, DateTime EDate,int SearchbyCountry= 0, int SelectReport = 0, int SearchByDate = 0)
        {
            List<tblPerson> PL = new List<tblPerson>();
            try
            {

                //ViewBag.CountryApplication = DB.tblCountries.Where(x => x.isActive == true&&x.CountryId== SearchbyCountry).ToLicst();
                ViewBag.SelectReport = SelectReport;
                ViewBag.SearchbyCountry = SearchbyCountry;
                ViewBag.SearchByDate = SearchByDate;
                ViewBag.BDate = BDate;
                ViewBag.EDate = EDate;
                ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
                if (SelectReport == 1)
                {
                    if(SearchByDate==1)
                    {
                        PL = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfApplication == SearchbyCountry && x.EntryDate >= BDate && x.EntryDate <= EDate).ToList();
                        ViewBag.Count= DB.tblPersons.Where(x => x.isActive == true && x.CountryOfApplication == SearchbyCountry && x.EntryDate >= BDate && x.EntryDate <= EDate).Count();
                    }
                    else
                    {
                        PL = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfApplication == SearchbyCountry && x.LastModifiedDate >= BDate && x.LastModifiedDate <= EDate).ToList();
                        ViewBag.Count = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfApplication == SearchbyCountry && x.LastModifiedDate >= BDate && x.LastModifiedDate <= EDate).Count();
                    }
                }
                else if(SelectReport==2)
                {
                    PL = null;
                    ViewBag.Count = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfApplication == SearchbyCountry).Count();
                }
                else if (SelectReport == 3)
                {
                    if(SearchByDate == 1)
                    {
                        PL = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfBirth == SearchbyCountry && x.EntryDate >= BDate && x.EntryDate <= EDate).ToList();
                        ViewBag.Count = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfBirth == SearchbyCountry && x.EntryDate >= BDate && x.EntryDate <= EDate).Count();
                    }
                    else
                    {
                        PL = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfBirth == SearchbyCountry && x.LastModifiedDate >= BDate && x.LastModifiedDate <= EDate).ToList();
                        ViewBag.Count = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfBirth == SearchbyCountry && x.LastModifiedDate >= BDate && x.LastModifiedDate <= EDate).Count();
                    }
                }
                else
                {
                    PL = null;
                    ViewBag.Count = DB.tblPersons.Where(x => x.isActive == true && x.CountryOfBirth == SearchbyCountry).Count();
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

        public ActionResult TransactionSummary()
        {
            ViewBag.SelectReport = 0;
            ViewBag.BDate = DateTime.Now;
            ViewBag.EDate = DateTime.Now;
            List<tblTransaction> PL = null;
            //var PL = DB.tblPersons.Where(x => x.isActive == true).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
            return View(PL);
        }

        [HttpPost]
        public ActionResult TransactionSummary(int SelectReport, int SearchByDate, DateTime BDate, DateTime EDate)
        {
            List<tblTransaction> PL = new List<tblTransaction>();
            try
            {

                ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
                ViewBag.SelectReport = SelectReport;
                ViewBag.SearchByDate = SearchByDate;
                ViewBag.BDate = BDate;
                ViewBag.EDate = EDate;
                if (SelectReport == 1)
                {
                    PL = DB.tblTransactions.Where(x => x.isActive == true && x.EditDate == DateTime.Now).ToList();
                }
                else
                {
                    if (SearchByDate == 1)
                    {
                        PL = DB.tblTransactions.Where(x => x.isActive == true && x.CreatedDate >= BDate && x.CreatedDate <= EDate).ToList();
                    }
                    else if(SearchByDate==2)
                    {
                        PL = DB.tblTransactions.Where(x => x.isActive == true && x.EditDate >= BDate && x.EditDate <= EDate).ToList();
                    }
                    else
                    {
                        PL = DB.tblTransactions.Where(x => x.isActive == true && x.IssueDate >= BDate && x.IssueDate <= EDate).ToList();
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
    }
}