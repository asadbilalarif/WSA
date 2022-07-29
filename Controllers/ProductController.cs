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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Products(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ViewBag.ProductType = DB.tblProductTypes.Where(x => x.isActive == true).ToList();
            var Data = DB.tblProducts.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateProduct(tblProduct Product)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblProduct Data = new tblProduct();
            tblProduct check = new tblProduct();

            try
            {
                if (Product.ProductId != 0)
                {

                    check = DB.tblProducts.Select(r => r).Where(x => x.Code == Product.Code).FirstOrDefault();
                    if (check == null || check.ProductId == Product.ProductId)
                    {
                        Data = DB.tblProducts.Select(r => r).Where(x => x.ProductId == Product.ProductId).FirstOrDefault();

                        Data.Name = Product.Name;
                        Data.ProductTypeId = Product.ProductTypeId;
                        Data.Code = Product.Code;
                        Data.Price = Product.Price;
                        Data.ValidFor = Product.ValidFor;
                        Data.ProductSerialNum = Product.ProductSerialNum;
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

                    if (DB.tblProducts.Select(r => r).Where(x => x.Code == Product.Code).FirstOrDefault() == null)
                    {
                        Data = Product;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblProducts.Add(Data);
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
        public ActionResult DeleteProduct(tblProduct Product)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblProduct Data = new tblProduct();

            try
            {
                Data = DB.tblProducts.Select(r => r).Where(x => x.ProductId == Product.ProductId).FirstOrDefault();
                DB.Entry(Data).State = EntityState.Deleted;
                DB.SaveChanges();
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