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
    public class ProductpackageController : Controller
    {
        // GET: Productpackage
        public ActionResult Productpackages(int? id, int? Success, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            List<ProductProductPackage> ProductPackage = null;


            ViewBag.ProductPackage = DB.tblProductPackages.Where(x => x.isActive == true).ToList();
            if (Success > 0)
            {
                ViewBag.Update = "Productpackage has been update successfully.";
            }
            else if (Success == -1)
            {
                ViewBag.Success = "Productpackage has been add successfully.";
            }
            ViewBag.Delete = Delete;

            ViewBag.Products = DB.tblProducts.Where(x => x.isActive == true).ToList();
            if (id != null && id != 0)
            {

                ProductPackage = (from PP in DB.tblProductPackages
                                  join PPP in DB.tblProductPackageProducts on PP.ProductPackageId equals PPP.ProductPackageId
                                  join P in DB.tblProducts on PPP.ProductId equals P.ProductId
                                  where PP.ProductPackageId == id
                                  select new ProductProductPackage
                                  {
                                      ProductPackage = PP,
                                      ProductPackageProduct = PPP,
                                      Product = P


                                  }).ToList();



                //ProductPackage = DB.tblProductPackages.Where(x => x.ProductPackageId == id).FirstOrDefault();

                //ViewBag.ProductPackageProduct = DB.tblProductPackageProducts.Where(x => x.ProductPackageId == id).ToList();
                //return View(ProductPackage);
            }


            return View(ProductPackage);
        }

        public ActionResult CreateProductPackage(int? id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            //tblProductPackage ProductPackage = null;  
            List<ProductProductPackage> ProductPackage = null;

            ViewBag.Products = DB.tblProducts.Where(x => x.isActive == true).ToList();
            if (id != null && id != 0)
            {

                ProductPackage = (from PP in DB.tblProductPackages
                                  join PPP in DB.tblProductPackageProducts on PP.ProductPackageId equals PPP.ProductPackageId
                                  join P in DB.tblProducts on PPP.ProductId equals P.ProductId
                                  where PP.ProductPackageId == id
                                  select new ProductProductPackage
                                  {
                                      ProductPackage = PP,
                                      ProductPackageProduct = PPP,
                                      Product = P


                                  }).ToList();



                //ProductPackage = DB.tblProductPackages.Where(x => x.ProductPackageId == id).FirstOrDefault();

                //ViewBag.ProductPackageProduct = DB.tblProductPackageProducts.Where(x => x.ProductPackageId == id).ToList();
                return View(ProductPackage);
            }
            else
            {
                return View(ProductPackage);
            }
        }


        [HttpPost]
        public ActionResult CreateProductPackage(List<tblProduct> TailData, List<tblProductPackage> HeadData)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblProductPackage Data = new tblProductPackage();
            tblProductPackage Check = new tblProductPackage();
            List<tblProductPackageProduct> Data2 = new List<tblProductPackageProduct>();

            var CheckName = HeadData[0].Name;
            var CheckProductPackageId = HeadData[0].ProductPackageId;

            Check = DB.tblProductPackages.Select(r => r).Where(x => x.Name == CheckName).FirstOrDefault();
            int Succ = 0;
            try
            {
                if (HeadData[0].ProductPackageId != 0)
                {
                    if (Check == null || Check.ProductPackageId == HeadData[0].ProductPackageId)
                    {
                        Data = DB.tblProductPackages.Where(x => x.ProductPackageId == CheckProductPackageId).FirstOrDefault();
                        Data.Code = HeadData[0].Code;
                        Data.Name = HeadData[0].Name;
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.Entry(Data);
                        DB.SaveChanges();
                        Succ = 1;
                    }
                    else
                    {
                        ViewBag.Error = "Package Already Exist!!!";
                        var redirectUrl1 = new UrlHelper(Request.RequestContext).Action("ProductPackages", "ProductPackage", new { Delete = ViewBag.Error });
                        return Json(new { Url = redirectUrl1 });
                    }

                    Data2 = DB.tblProductPackageProducts.Select(r => r).Where(x => x.ProductPackageId == CheckProductPackageId).ToList();
                    foreach (var item in Data2)
                    {
                        DB.Entry(item).State = EntityState.Deleted; ;
                    }
                    DB.SaveChanges();

                    if (TailData == null)
                    {
                        TailData = new List<tblProduct>();
                    }


                    //Loop and insert records.

                    int count = 0;
                    foreach (tblProduct Item in TailData)
                    {
                        tblProductPackageProduct Data1 = new tblProductPackageProduct();
                        if (count != TailData.Count)
                        {
                            Data1.ProductPackageId = DB.tblProductPackages.Where(x => x.Name == CheckName).Select(r => r.ProductPackageId).FirstOrDefault();
                            Data1.ProductId = Item.ProductId;
                            DB.tblProductPackageProducts.Add(Data1);
                        }


                        count++;


                    }
                    DB.SaveChanges();
                    var RedirectUrl = new UrlHelper(Request.RequestContext).Action("ProductPackages", "ProductPackage", new { Success = Succ });
                    return Json(new { Url = RedirectUrl });
                }
                else
                {
                    if (Check == null)
                    {
                        Data.Code = HeadData[0].Code;
                        Data.Name = HeadData[0].Name;
                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblProductPackages.Add(Data);
                        DB.SaveChanges();
                        Succ = -1;
                    }
                    else
                    {
                        ViewBag.Error = "Package Already Exist!!!";
                        var redirectUrl1 = new UrlHelper(Request.RequestContext).Action("ProductPackages", "ProductPackage", new { Delete = ViewBag.Error });
                        return Json(new { Url = redirectUrl1 });
                    }



                    if (TailData == null)
                    {
                        TailData = new List<tblProduct>();
                    }


                    //Loop and insert records.

                    int count = 0;
                    foreach (tblProduct Item in TailData)
                    {
                        tblProductPackageProduct Data1 = new tblProductPackageProduct();
                        if (count != TailData.Count)
                        {
                            Data1.ProductPackageId = DB.tblProductPackages.Where(x => x.Name == CheckName).Select(r => r.ProductPackageId).FirstOrDefault();
                            Data1.ProductId = Item.ProductId;
                            DB.tblProductPackageProducts.Add(Data1);
                        }
                        count++;
                    }
                    DB.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error" + ex.Message);
            }

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("ProductPackages", "ProductPackage", new { Success = Succ });
            return Json(new { Url = redirectUrl });
        }



        [HttpPost]
        public ActionResult DeleteProductPackage(tblProductPackage ProductPackage)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblProductPackage Data = new tblProductPackage();
            List<tblProductPackageProduct> Data1 = new List<tblProductPackageProduct>();

            try
            {


                Data1 = DB.tblProductPackageProducts.Select(r => r).Where(x => x.ProductPackageId == ProductPackage.ProductPackageId).ToList();
                foreach (var item in Data1)
                {
                    DB.Entry(item).State = EntityState.Deleted; ;
                }
                DB.SaveChanges();

                Data = DB.tblProductPackages.Select(r => r).Where(x => x.ProductPackageId == ProductPackage.ProductPackageId).FirstOrDefault();
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

        [HttpGet]
        public ActionResult GetAllProductsss(int id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ////Searching records from list using LINQ query  
            DB.Configuration.ProxyCreationEnabled = false;
            ViewBag.ProductList = DB.tblProducts.Where(q => q.ProductId == id).ToList();
            return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
        }
    }
}