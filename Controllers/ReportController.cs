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
            ViewBag.BDate = DateTime.Now.ToString("MM-dd-yyyy");
            ViewBag.EDate = DateTime.Now.ToString("MM-dd-yyyy");
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ProductList(int SelectReport,int SelectStatus,int SearchByDate,string BDate, string EDate)
        {
            List<PersonList_Result1> PL = new List<PersonList_Result1>();
            try
            {

                ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
                ViewBag.SelectReport = SelectReport;
                ViewBag.SelectStatus = SelectStatus;
                ViewBag.SearchByDate = SearchByDate;
                ViewBag.BDate = BDate;
                ViewBag.EDate = EDate;
                //DateTime BDate1 = Convert.ToDateTime(BDate.ToString("yyyy-MM-dd"));
                //DateTime EDate1 = Convert.ToDateTime(EDate.ToString("yyyy-MM-dd"));
                string Query = "";
                if (SelectReport==1)
                {
                    Query = "where P.isActive = 1 and Cast(LastModifiedDate as date)=cast('" + DateTime.Now.ToString("MM-dd-yyyy") + "' as date ) and Status="+SelectStatus+"";
                    PL = DB.PersonList(Query).ToList();
                }
                else
                {
                    if(SearchByDate==1)
                    {
                        Query = "where P.isActive = 1 and Cast(EntryDate as date)>=cast('" + BDate + "' as date ) and Cast(EntryDate as date)<=cast('" + EDate + "' as date ) and Status=" + SelectStatus + "";
                        PL = DB.PersonList(Query).ToList();
                    }
                    else
                    {
                        Query = "where P.isActive = 1 and Cast(LastModifiedDate as date)>=cast('" + BDate + "' as date ) and Cast(LastModifiedDate as date)<=cast('" +EDate + "' as date ) and Status=" + SelectStatus + "";
                        PL = DB.PersonList(Query).ToList();
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
            ViewBag.SearchFields = DB.SearchFields.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CustomSearch(string FieldtoSearch,string SearchValue)
        {
            ViewBag.FieldtoSearch = FieldtoSearch;
            ViewBag.SearchValue = SearchValue;
            ViewBag.SearchFields = DB.SearchFields.ToList();
            List<CustomSearchLeftJoin_Result> PL = DB.CustomSearchLeftJoin(FieldtoSearch, SearchValue).ToList();
            //ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            return View(PL);
        }

        public ActionResult CountrySummary()
        {
            ViewBag.SelectReport = 0;
            ViewBag.SearchbyCountry = 0;
            ViewBag.BDate = DateTime.Now.ToString("MM-dd-yyyy");
            ViewBag.EDate = DateTime.Now.ToString("MM-dd-yyyy");
            string Query = "where P.isActive = 1 ";
            var PL = DB.CountrySummaryList(Query).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
            
            return View();
        }


        [HttpPost]
        public ActionResult CountrySummary( string BDate, string EDate,int SearchbyCountry= 0, int SelectReport = 0, int SearchByDate = 0)
        {
            List<CountrySummaryList_Result> PL = new List<CountrySummaryList_Result>();
            try
            {

                //ViewBag.CountryApplication = DB.tblCountries.Where(x => x.isActive == true&&x.CountryId== SearchbyCountry).ToLicst();
                ViewBag.SelectReport = SelectReport;
                ViewBag.SearchbyCountry = SearchbyCountry;
                ViewBag.SearchByDate = SearchByDate;
                ViewBag.BDate = BDate;
                ViewBag.EDate = EDate;
                ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
                string Query = "";
                if (SelectReport == 1)
                {
                    if(SearchByDate==1)
                    {
                        Query = "where P.isActive = 1 and CountryOfApplication = "+SearchbyCountry+" and Cast(EntryDate as date)>=cast('" + BDate + "' as date ) and Cast(EntryDate as date)<=cast('" + EDate + "' as date ) ";
                        PL = DB.CountrySummaryList(Query).ToList();
                        ViewBag.Count= PL.Count();
                    }
                    else
                    {
                        Query = "where P.isActive = 1 and CountryOfApplication = " + SearchbyCountry + " and Cast(LastModifiedDate as date)>=cast('" + BDate + "' as date ) and Cast(LastModifiedDate as date)<=cast('" + EDate + "' as date ) ";
                        PL = DB.CountrySummaryList(Query).ToList();
                        ViewBag.Count = PL.Count();
                    }
                }
                else if(SelectReport==2)
                {
                    Query = "where P.isActive = 1 and  CountryOfApplication = " + SearchbyCountry + " ";
                    PL = null;
                    ViewBag.Count = DB.CountrySummaryList(Query).Count();
                }
                else if (SelectReport == 3)
                {
                    if(SearchByDate == 1)
                    {
                        Query = "where P.isActive = 1 and CountryOfBirth = " + SearchbyCountry + " and Cast(EntryDate as date)>=cast('" + BDate + "' as date ) and Cast(EntryDate as date)<=cast('" + EDate + "' as date ) ";
                        PL = DB.CountrySummaryList(Query).ToList();
                        ViewBag.Count = PL.Count();
                    }
                    else
                    {
                        Query = "where P.isActive = 1 and CountryOfBirth = " + SearchbyCountry + " and Cast(LastModifiedDate as date)>=cast('" + BDate + "' as date ) and Cast(LastModifiedDate as date)<=cast('" +EDate + "' as date ) ";
                        PL = DB.CountrySummaryList(Query).ToList();
                        ViewBag.Count = PL.Count();
                    }
                }
                else
                {
                    Query = "where P.isActive = 1 and CountryOfBirth = " + SearchbyCountry + "  ";
                    PL = null;
                    ViewBag.Count = DB.CountrySummaryList(Query).Count();
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
            ViewBag.BDate = DateTime.Now.ToString("MM-dd-yyyy");
            ViewBag.EDate = DateTime.Now.ToString("MM-dd-yyyy");
            List<TransactionSummaryList_Result2> PL = null;
            //var PL = DB.tblPersons.Where(x => x.isActive == true).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
            return View(PL);
        }

        [HttpPost]
        public ActionResult TransactionSummary(int SelectReport, int SearchByDate, string BDate, string EDate)
        {
            List<TransactionSummaryList_Result2> PL = new List<TransactionSummaryList_Result2>();
            try
            {

                ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
                ViewBag.SelectReport = SelectReport;
                ViewBag.SearchByDate = SearchByDate;
                ViewBag.BDate = BDate;
                ViewBag.EDate = EDate;
                string Query = "";
                if (SelectReport == 1)
                {
                    Query = "where T.isActive = 1 and Cast(T.EditDate as date)=cast('" + DateTime.Now.ToString("MM-dd-yyyy") + "' as date ) ";
                    PL = DB.TransactionSummaryList(Query).ToList();
                }
                else
                {
                    if (SearchByDate == 1)
                    {
                        Query = "where T.isActive = 1 and Cast(T.CreatedDate as date)>=cast('" + BDate + "' as date ) and Cast(T.CreatedDate as date)<=cast('" + EDate + "' as date ) ";
                        PL = DB.TransactionSummaryList(Query).ToList();
                    }
                    else if(SearchByDate==2)
                    {
                        Query = "where T.isActive = 1 and Cast(T.EditDate as date)>=cast('" + BDate + "' as date ) and Cast(T.EditDate as date)<=cast('" + EDate + "' as date ) ";
                        PL = DB.TransactionSummaryList(Query).ToList();
                    }
                    else
                    {
                        Query = "where T.isActive = 1 and Cast(IssueDate as date)>=cast('" + BDate + "' as date ) and Cast(IssueDate as date)<=cast('" + EDate + "' as date ) ";
                        PL = DB.TransactionSummaryList(Query).ToList();
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