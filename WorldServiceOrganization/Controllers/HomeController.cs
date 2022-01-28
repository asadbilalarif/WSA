﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Countries(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            
            var Data = DB.tblCountries.Where(x => x.isActive == true).ToList() ;

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

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
                        Data.Code = Country.Code;
                        Data.isActive = true;
                        Data.EditDate = DateTime.Now;
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
                    
                    if (DB.tblCountries.Select(r => r).Where(x => x.Code== Country.Code).FirstOrDefault() == null)
                    {
                        Data= Country;
                        Data.CreatedDate = DateTime.Now;
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
        public ActionResult DeleteCountry( tblCountry Country)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblCountry Data = new tblCountry();

            try
            {
                Data = DB.tblCountries.Select(r => r).Where(x => x.CountryId == Country.CountryId).FirstOrDefault();
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


        public ActionResult Eyes(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblEyes.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateEye(tblEye Eye)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblEye Data = new tblEye();
            tblEye check = new tblEye();

            try
            {
                if (Eye.EyeId != 0)
                {

                    check = DB.tblEyes.Select(r => r).Where(x => x.Code == Eye.Code).FirstOrDefault();
                    if (check == null || check.EyeId == Eye.EyeId)
                    {
                        Data = DB.tblEyes.Select(r => r).Where(x => x.EyeId == Eye.EyeId).FirstOrDefault();

                        Data.Name = Eye.Name;
                        Data.Code = Eye.Code;
                        Data.isActive = true;
                        Data.EditDate = DateTime.Now;
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

                    if (DB.tblEyes.Select(r => r).Where(x => x.Code == Eye.Code).FirstOrDefault() == null)
                    {
                        Data = Eye;
                        Data.CreatedDate = DateTime.Now;
                        Data.isActive = true;
                        DB.tblEyes.Add(Data);
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
        public ActionResult DeleteEye(tblEye Eye)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblEye Data = new tblEye();

            try
            {
                Data = DB.tblEyes.Select(r => r).Where(x => x.EyeId == Eye.EyeId).FirstOrDefault();
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


        public ActionResult Occupations(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblOccupations.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

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
                        Data.isActive = true;
                        Data.EditDate = DateTime.Now;
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
                        Data.CreatedDate = DateTime.Now;
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
                Data = DB.tblOccupations.Select(r => r).Where(x => x.OccupationId == Occupation.OccupationId).FirstOrDefault();
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


        public ActionResult Products(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ViewBag.ProductType= DB.tblProductTypes.Where(x => x.isActive == true).ToList();
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
                        Data.isActive = true;
                        Data.EditDate = DateTime.Now;
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
                        Data.CreatedDate = DateTime.Now;
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


        public ActionResult ProductTypes(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblProductTypes.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

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
                        Data.EditDate = DateTime.Now;
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
                        Data.CreatedDate = DateTime.Now;
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
                Data = DB.tblProductTypes.Select(r => r).Where(x => x.ProductTypeId == ProductType.ProductTypeId).FirstOrDefault();
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


        public ActionResult Status(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblStatus.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

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
                        Data.EditDate = DateTime.Now;
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
                        Data.CreatedDate = DateTime.Now;
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
                Data = DB.tblStatus.Select(r => r).Where(x => x.StatusId == Status.StatusId).FirstOrDefault();
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


        public ActionResult Sex(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            var Data = DB.tblSex.Where(x => x.isActive == true).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

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
                        Data.EditDate = DateTime.Now;
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
                        Data.CreatedDate = DateTime.Now;
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
                Data = DB.tblSex.Select(r => r).Where(x => x.SexId == Sex.SexId).FirstOrDefault();
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


        public ActionResult Productpackages(int? id,int? Success, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            List<ProductProductPackage> ProductPackage = null;

            
            ViewBag.ProductPackage = DB.tblProductPackages.Where(x => x.isActive == true).ToList();
            if(Success > 0)
            {
                ViewBag.Update = "Productpackage has been update successfully.";
            }
            else if(Success==-1)
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
            List<ProductProductPackage> ProductPackage = null ;
            
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
                                                  ProductPackageProduct=PPP,
                                                  Product=P


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

            var CheckCode = HeadData[0].Code;
            var CheckProductPackageId = HeadData[0].ProductPackageId;

            Check = DB.tblProductPackages.Select(r => r).Where(x => x.Code == CheckCode).FirstOrDefault();
                int Succ = 0;
            try
            {
                if(HeadData[0].ProductPackageId!=0)
                {
                    if (Check == null ||Check.ProductPackageId== HeadData[0].ProductPackageId)
                    {
                        Data = DB.tblProductPackages.Where(x => x.ProductPackageId == CheckProductPackageId).FirstOrDefault();
                        Data.Code = HeadData[0].Code;
                        Data.Name = HeadData[0].Name;
                        Data.EditDate = DateTime.Now;
                        Data.isActive = true;
                        DB.Entry(Data);
                        DB.SaveChanges();
                        Succ = 1;
                    }
                    else
                    {
                        ViewBag.Error = "Package Already Exist!!!";
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
                            Data1.ProductPackageId = DB.tblProductPackages.Where(x => x.Code == CheckCode).Select(r => r.ProductPackageId).FirstOrDefault();
                            Data1.ProductId = Item.ProductId;
                            DB.tblProductPackageProducts.Add(Data1);
                        }


                        count++;


                    }
                    DB.SaveChanges();
                    var RedirectUrl = new UrlHelper(Request.RequestContext).Action("ProductPackages", "Home", new { Success = Succ });
                    return Json(new { Url = RedirectUrl });
                }
                else
                {
                    if (Check == null)
                    {
                        Data.Code = HeadData[0].Code;
                        Data.Name = HeadData[0].Name;
                        Data.CreatedDate = DateTime.Now;
                        Data.isActive = true;
                        DB.tblProductPackages.Add(Data);
                        DB.SaveChanges();
                        Succ = -1;
                    }
                    else
                    {
                        ViewBag.Error = "Package Already Exist!!!";
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
                            Data1.ProductPackageId = DB.tblProductPackages.Where(x => x.Code == CheckCode).Select(r => r.ProductPackageId).FirstOrDefault();
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

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("ProductPackages", "Home",new { Success= Succ });
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



        public ActionResult Settings(int? isSuccess)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            var Data = DB.tblSettings.Where(x => x.isActive==true).FirstOrDefault();
            if(isSuccess==1)
            {
                ViewBag.Error = "Record Successfully Updated!!!";
            }

            

            return View(Data);
        }

        [HttpPost]
        public ActionResult CreateSetting(tblSetting Setting)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblSetting Data = new tblSetting();
            tblRole Foreign = new tblRole();
            try
            {
                //Foreign = DB.tblRoles.Where(x => x.RoleId == Setting.RoleId).FirstOrDefault();
                //Data.tblRole = Foreign;
                Data = DB.tblSettings.Select(r => r).Where(x => x.SettingId == Setting.SettingId).FirstOrDefault();
                Data.SettingId = Setting.SettingId;
                Data.DateFormat = Setting.DateFormat;
                Data.NextWSA = Setting.NextWSA;
                Data.NextPassport = Setting.NextPassport;
                Data.NumberOfRetrieves = Setting.NumberOfRetrieves;
                Data.LetterCase = Setting.LetterCase;
                Data.FontStyle = Setting.FontStyle;
                Data.FontSize = Setting.FontSize;
                DB.Entry(Data);
                DB.SaveChanges();

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("Settings", new { isSuccess = 1 });
        }


        

        public ActionResult Persons(string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            var PersonList = DB.tblPersons.Where(x => x.isActive == true).ToList();
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            return View(PersonList);
        }

        public ActionResult CreatePerson(int? id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Person = null;
            ViewBag.Country= DB.tblCountries.Where(x => x.isActive == true).ToList();
            ViewBag.Eye= DB.tblEyes.Where(x => x.isActive == true).ToList();
            ViewBag.Occupation= DB.tblOccupations.Where(x => x.isActive == true).ToList();
            ViewBag.Sex= DB.tblSex.Where(x => x.isActive == true).ToList();
            ViewBag.Status= DB.tblStatus.Where(x => x.isActive == true).ToList();

            if (id != null && id != 0)
            {

                Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
                
                return View(Person);
            }
            else
            {
                return View(Person);
            }
        }

        [HttpPost]
        public ActionResult CreatePerson(tblPerson Person, HttpPostedFileBase Image, HttpPostedFileBase SigImage, HttpPostedFileBase CertificationFile)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Data = new tblPerson();

            try
            {
                if (Person.PersonIDNumber == 0)
                {
                    if (DB.tblPersons.Select(r => r).Where(x => x.EMail==Person.EMail).FirstOrDefault() == null)
                    {
                        Data = Person;
                        string folder = Server.MapPath(string.Format("~/{0}/", "Uploading"));
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }

                        string path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(Image.FileName));
                        Image.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(Image.FileName));
                        Data.Photo = path;

                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(SigImage.FileName));
                        SigImage.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(SigImage.FileName));Data.SignaturePath = path;

                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(CertificationFile.FileName));
                        CertificationFile.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(CertificationFile.FileName));
                        Data.Certification = path;


                        Data.EntryDate = DateTime.Now;
                        Data.isActive = true;
                        DB.tblPersons.Add(Data);
                        DB.SaveChanges();
                        return RedirectToAction("Persons", new { Success = "Person has been add successfully." });
                    }
                    else
                    {
                        ViewBag.Error = "Person Already Exsist!!!";
                    }
                }
                else
                {
                    var check = DB.tblPersons.Select(r => r).Where(x => x.EMail == Person.EMail).FirstOrDefault();
                    if (check == null || check.PersonIDNumber == Person.PersonIDNumber)
                    {

                        Data = DB.tblPersons.Select(r => r).Where(x => x.PersonIDNumber == Person.PersonIDNumber).FirstOrDefault();
                        Data.FirstName = Person.FirstName;
                        Data.LastName = Person.LastName;
                        Data.CityOfBirth = Person.CityOfBirth;
                        Data.Phone = Person.CityOfBirth;
                        Data.Fax = Person.Fax;
                        Data.EMail= Person.EMail;
                        Data.Website= Person.Website;
                        Data.DateOfBirth= Person.DateOfBirth;
                        Data.BirthDay= Person.BirthDay;
                        Data.BirthMonth= Person.BirthMonth;
                        Data.BirthYear= Person.BirthYear;
                        Data.Marks= Person.Marks;
                        Data.FatherName= Person.FatherName;
                        Data.MotherName= Person.MotherName;
                        Data.WSANumber= Person.WSANumber;
                        Data.Comments= Person.Comments;
                        Data.Height= Person.Height;
                        Data.CountryOfApplication= Person.CountryOfApplication;
                        Data.CountryOfBirth= Person.CountryOfBirth;
                        Data.Sex= Person.Sex;
                        Data.Status= Person.Status;
                        Data.Eyes= Person.Eyes;
                        Data.OccupationCode= Person.OccupationCode;
                        Data.TransactionCount= Person.TransactionCount;


                        string path = null;
                        if (SigImage != null)
                        {
                            path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(SigImage.FileName));

                            SigImage.SaveAs(path);
                            path = Path.Combine("\\Uploading", Path.GetFileName(SigImage.FileName));

                            Data.SignaturePath = path;
                        }

                        if (Image != null)
                        {
                            path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(Image.FileName));

                            Image.SaveAs(path);
                            path = Path.Combine("\\Uploading", Path.GetFileName(Image.FileName));

                            Data.Photo = path;
                        }

                        if (CertificationFile != null)
                        {
                            path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(CertificationFile.FileName));
                            CertificationFile.SaveAs(path);
                            path = Path.Combine("\\Uploading", Path.GetFileName(CertificationFile.FileName));
                            Data.Certification = path;
                        }

                        Data.LastModifiedDate = DateTime.Now;
                        DB.Entry(Data);
                        DB.SaveChanges();
                        return RedirectToAction("Persons", new { Update = "Person has been Update successfully." });
                    }
                    else
                    {
                        ViewBag.Error = "Person Already Exsist!!!";
                    }

                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            
            return View(Person);
        }

        [HttpPost]
        public ActionResult DeletePerson(int PersonId)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Data = new tblPerson();
            try
            {
                Data = DB.tblPersons.Select(r => r).Where(x => x.PersonIDNumber == PersonId).FirstOrDefault();
                DB.Entry(Data).State = EntityState.Deleted;
                DB.SaveChanges();
                return Json(1);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return Json(0);
        }


        public ActionResult CreateChild(int? id, string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Person = null;
            ViewBag.Child = DB.tblChilds.Where(x => x.isActive == true && x.PersonIDNumber==id).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

            ViewBag.Sex= DB.tblSex.Where(x => x.isActive == true).ToList();
            if (id != null && id != 0)
            {

                Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
                return View(Person);
            }
            else
            {
                return View(Person);
            }
        }


        [HttpPost]
        public ActionResult CreateChild(tblChild Child)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblChild Data = new tblChild();
            try
            {
                if (Child.ChildId == 0)
                {
                    if (DB.tblChilds.Select(r => r).Where(x => x.Name == Child.Name&&x.PersonIDNumber==Child.PersonIDNumber).FirstOrDefault() == null)
                    {
                        Data = Child;
                        
                        Data.CreatedDate = DateTime.Now;
                        Data.isActive = true;
                        DB.tblChilds.Add(Data);
                        DB.SaveChanges();
                        return RedirectToAction("CreateChild", new { Success = "Child has been add successfully." });
                    }
                    else
                    {
                        ViewBag.Error = "Child Already Exsist!!!";
                    }
                }
                else
                {
                    var check = DB.tblChilds.Select(r => r).Where(x => x.Name == Child.Name && x.PersonIDNumber == Child.PersonIDNumber).FirstOrDefault();
                    if (check == null || check.ChildId == Child.ChildId)
                    {
                        
                        Data = DB.tblChilds.Select(r => r).Where(x => x.ChildId == Child.ChildId).FirstOrDefault();
                        Data.PersonIDNumber = Child.PersonIDNumber;
                        Data.Name = Child.Name;
                        Data.SexId = Child.SexId;
                        Data.BirthDate = Child.BirthDate;
                        Data.EditDate = DateTime.Now;
                        DB.Entry(Data);
                        DB.SaveChanges();
                        return RedirectToAction("CreateChild", new { Update = "Child has been Update successfully." });
                    }
                    else
                    {
                        ViewBag.Error = "Child Already Exsist!!!";
                    }

                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("CreateChild");
        }

        [HttpPost]
        public ActionResult DeleteChild(int ChildId)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblChild Data = new tblChild();

            try
            {
                Data = DB.tblChilds.Select(r => r).Where(x => x.ChildId == ChildId).FirstOrDefault();
                DB.Entry(Data).State = EntityState.Deleted;
                DB.SaveChanges();
                return Json(1);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return Json(0);
        }


        public ActionResult CreateAddress(int? id, string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Person = null;
            ViewBag.Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

            ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
            if (id != null && id != 0)
            {

                Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
                return View(Person);
            }
            else
            {
                return View(Person);
            }
        }


        [HttpPost]
        public ActionResult CreateAddress(tblAddress Address)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblAddress Data = new tblAddress();
            try
            {
                if (Address.AddressIDNumber == 0)
                {
                        Data = Address;

                        Data.CreatedDate = DateTime.Now;
                        Data.isActive = true;
                        DB.tblAddresses.Add(Data);
                        DB.SaveChanges();
                        return RedirectToAction("CreateAddress", new { Success = "Address has been add successfully." });
                   
                }
                else
                {

                        Data = DB.tblAddresses.Select(r => r).Where(x => x.AddressIDNumber == Address.AddressIDNumber).FirstOrDefault();
                        Data.PersonIDNumber = Address.PersonIDNumber;
                        Data.Address1 = Address.Address1;
                        Data.CareOf = Address.CareOf;
                        Data.City = Address.City;
                        Data.State = Address.State;
                        Data.PostalCode = Address.PostalCode;
                        Data.Country = Address.Country;
                        Data.Label = Address.Label;
                        Data.EditDate = DateTime.Now;
                        DB.Entry(Data);
                        DB.SaveChanges();
                        return RedirectToAction("CreateAddress", new { Update = "Address has been Update successfully." });
                   

                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("CreateAddress");
        }

        [HttpPost]
        public ActionResult DeleteAddress(int AddressId)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblAddress Data = new tblAddress();

            try
            {
                Data = DB.tblAddresses.Select(r => r).Where(x => x.AddressIDNumber == AddressId).FirstOrDefault();
                DB.Entry(Data).State = EntityState.Deleted;
                DB.SaveChanges();
                return Json(1);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return Json(0);
        }

        public ActionResult CreateTransaction(int? id, string Success, string Update, string Delete)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Person = null;
            ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

            //ViewBag.Product = DB.ProductUnionPackage().ToList();
            ViewBag.Product = DB.tblProducts.Where(x => x.isActive == true).ToList();
            
            if (id != null && id != 0)
            {

                Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
                return View(Person);
            }
            else
            {
                return View(Person);
            }
        }


        [HttpPost]
        public ActionResult CreateTransaction(tblTransaction Transaction)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblTransaction Data = new tblTransaction();
            try
            {
                if (Transaction.TransactionIDNumber == 0)
                {
                    Data = Transaction;

                    Data.CreatedDate = DateTime.Now;
                    Data.EditDate = DateTime.Now;
                    Data.isActive = true;
                    DB.tblTransactions.Add(Data);
                    DB.SaveChanges();
                    return RedirectToAction("CreateTransaction", new { Success = "Transaction has been add successfully." });

                }
                else
                {

                    Data = DB.tblTransactions.Select(r => r).Where(x => x.TransactionIDNumber == Transaction.TransactionIDNumber).FirstOrDefault();
                    Data.PersonIDNumber = Transaction.PersonIDNumber;
                    Data.ProductIDNumber = Transaction.ProductIDNumber;
                    Data.IDCode = Transaction.IDCode;
                    Data.Cost = Transaction.Cost;
                    Data.Quantity = Transaction.Quantity;
                    Data.Problems = Transaction.Problems;
                    Data.ApplicationDate = Transaction.ApplicationDate;
                    Data.IssueDate = Transaction.IssueDate;
                    Data.SentDate = Transaction.SentDate;
                    Data.ReturnDate = Transaction.ReturnDate;
                    Data.EditDate = DateTime.Now;
                    DB.Entry(Data);
                    DB.SaveChanges();
                    return RedirectToAction("CreateTransaction", new { Update = "Transaction has been Update successfully." });


                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("CreateTransaction");
        }


        [HttpPost]
        public ActionResult DeleteTransaction(int TransactionId)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblTransaction Data = new tblTransaction();

            try
            {
                Data = DB.tblTransactions.Select(r => r).Where(x => x.TransactionIDNumber == TransactionId).FirstOrDefault();
                DB.Entry(Data).State = EntityState.Deleted;
                DB.SaveChanges();
                return Json(1);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return Json(0);
        }

        [HttpPost]
        public JsonResult GetProduct(int id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ////Searching records from list using LINQ query  

            var ProductList = DB.tblProducts.Where(q => q.ProductId==id).Select(s => s.Price).FirstOrDefault();
            return Json(ProductList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllProduct(int id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ////Searching records from list using LINQ query  

            ViewBag.ProductList = DB.tblProducts.Where(q => q.ProductId == id).ToList();
            return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
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


        [HttpPost]
        public JsonResult GetEyeCode(string Prefix)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            //Searching records from list using LINQ query  

            var CountryList = DB.tblEyes.Where(q => q.Code.StartsWith(Prefix)).Select(s => s.Code + "," + s.Name + "," + s.EyeId).ToList();

            return Json(CountryList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}