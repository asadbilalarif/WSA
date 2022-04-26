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
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        public ActionResult ProductTypes(string Success, string Update, string Delete, string FError)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblProductTypes.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            @ViewBag.FError = FError;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateProductType(tblProductType ProductType)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblProductType Data = new tblProductType();
            tblProductType check = new tblProductType();

            try
            {
                if (ProductType.ProductTypeId != 0)
                {

                    check = DB.tblProductTypes.Select(r => r).Where(x => x.Code == ProductType.Code).FirstOrDefault();
                    if (check == null || check.ProductTypeId == ProductType.ProductTypeId)
                    {
                        Data = DB.tblProductTypes.Select(r => r).Where(x => x.ProductTypeId == ProductType.ProductTypeId).FirstOrDefault();

                        Data.Name = ProductType.Name;
                        Data.Code = ProductType.Code;
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

                    if (DB.tblProductTypes.Select(r => r).Where(x => x.Code == ProductType.Code).FirstOrDefault() == null)
                    {
                        Data = ProductType;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblProductTypes.Add(Data);
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
        public ActionResult DeleteProductType(tblProductType ProductType)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblProductType Data = new tblProductType();

            try
            {
                if (DB.tblProducts.Where(x => x.ProductTypeId == ProductType.ProductTypeId).FirstOrDefault() == null)
                {
                    Data = DB.tblProductTypes.Select(r => r).Where(x => x.ProductTypeId == ProductType.ProductTypeId).FirstOrDefault();
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