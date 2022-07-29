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
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Countries(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblCountries.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            ViewBag.FError = FError;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateCountry(tblCountry Country)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblCountry Data = new tblCountry();
            tblCountry check = new tblCountry();

            try
            {
                if (Country.CountryId != 0)
                {

                    check = DB.tblCountries.Select(r => r).Where(x => x.Code == Country.Code).FirstOrDefault();
                    if (check == null || check.CountryId == Country.CountryId)
                    {
                        Data = DB.tblCountries.Select(r => r).Where(x => x.CountryId == Country.CountryId).FirstOrDefault();

                        Data.Name = Country.Name;
                        Data.Abbreviation = Country.Abbreviation;
                        Data.Code = Country.Code;
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

                    if (DB.tblCountries.Select(r => r).Where(x => x.Code == Country.Code).FirstOrDefault() == null)
                    {
                        Data = Country;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblCountries.Add(Data);
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
        public ActionResult DeleteCountry(tblCountry Country)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblCountry Data = new tblCountry();

            try
            {

                if (DB.tblPersons.Where(x => x.CountryOfApplication == Country.CountryId || x.CountryOfBirth == Country.CountryId || x.CountryOfBirthStatistical == Country.CountryId).FirstOrDefault() == null && DB.tblAddresses.Where(x => x.Country == Country.CountryId).FirstOrDefault() == null)
                {
                    Data = DB.tblCountries.Select(r => r).Where(x => x.CountryId == Country.CountryId).FirstOrDefault();
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