using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;
using ZXing;

namespace WorldServiceOrganization.Controllers
{
    [NoDirectAccess]
    [AuthorizeAction1FilterAttribute]
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Countries(string Success, string Update, string Delete, string FError)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            
        //    var Data = DB.tblCountries.Where(x => x.isActive == true).ToList() ;

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    ViewBag.FError = FError;

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateCountry(tblCountry Country)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblCountry Data = new tblCountry();
        //    tblCountry check = new tblCountry();

        //    try
        //    {
        //        if (Country.CountryId != 0)
        //        {

        //            check = DB.tblCountries.Select(r => r).Where(x => x.Code == Country.Code).FirstOrDefault();
        //            if (check == null || check.CountryId == Country.CountryId)
        //            {
        //                Data = DB.tblCountries.Select(r => r).Where(x => x.CountryId == Country.CountryId).FirstOrDefault();
                        
        //                Data.Name = Country.Name;
        //                Data.Code = Country.Code;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {
                    
        //            if (DB.tblCountries.Select(r => r).Where(x => x.Code== Country.Code).FirstOrDefault() == null)
        //            {
        //                Data= Country;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblCountries.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }




        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteCountry( tblCountry Country)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblCountry Data = new tblCountry();

        //    try
        //    {

        //        if (DB.tblPersons.Where(x => x.CountryOfApplication == Country.CountryId||x.CountryOfBirth == Country.CountryId||x.CountryOfBirthStatistical == Country.CountryId).FirstOrDefault() == null && DB.tblAddresses.Where(x => x.Country== Country.CountryId ).FirstOrDefault() == null)
        //        {
        //            Data = DB.tblCountries.Select(r => r).Where(x => x.CountryId == Country.CountryId).FirstOrDefault();
        //            DB.Entry(Data).State = EntityState.Deleted;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            return Json(2);
        //        }

                
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult Eyes(string Success, string Update, string Delete, string FError)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    var Data = DB.tblEyes.Where(x => x.isActive == true).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    ViewBag.FError = FError;
        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateEye(tblEye Eye)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblEye Data = new tblEye();
        //    tblEye check = new tblEye();

        //    try
        //    {
        //        if (Eye.EyeId != 0)
        //        {

        //            check = DB.tblEyes.Select(r => r).Where(x => x.Code == Eye.Code).FirstOrDefault();
        //            if (check == null || check.EyeId == Eye.EyeId)
        //            {
        //                Data = DB.tblEyes.Select(r => r).Where(x => x.EyeId == Eye.EyeId).FirstOrDefault();

        //                Data.Name = Eye.Name;
        //                Data.Code = Eye.Code;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {

        //            if (DB.tblEyes.Select(r => r).Where(x => x.Code == Eye.Code).FirstOrDefault() == null)
        //            {
        //                Data = Eye;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblEyes.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }




        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteEye(tblEye Eye)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblEye Data = new tblEye();

        //    try
        //    {
        //        if (DB.tblPersons.Where(x => x.Eyes == Eye.EyeId).FirstOrDefault() == null )
        //        {
        //            Data = DB.tblEyes.Select(r => r).Where(x => x.EyeId == Eye.EyeId).FirstOrDefault();
        //            DB.Entry(Data).State = EntityState.Deleted;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            return Json(2);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult Occupations(string Success, string Update, string Delete, string FError)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    var Data = DB.tblOccupations.Where(x => x.isActive == true).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    ViewBag.FError = FError;

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateOccupation(tblOccupation Occupation)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblOccupation Data = new tblOccupation();
        //    tblOccupation check = new tblOccupation();

        //    try
        //    {
        //        if (Occupation.OccupationId != 0)
        //        {

        //            check = DB.tblOccupations.Select(r => r).Where(x => x.Code == Occupation.Code).FirstOrDefault();
        //            if (check == null || check.OccupationId == Occupation.OccupationId)
        //            {
        //                Data = DB.tblOccupations.Select(r => r).Where(x => x.OccupationId == Occupation.OccupationId).FirstOrDefault();

        //                Data.Name = Occupation.Name;
        //                Data.Code = Occupation.Code;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {

        //            if (DB.tblOccupations.Select(r => r).Where(x => x.Code == Occupation.Code).FirstOrDefault() == null)
        //            {
        //                Data = Occupation;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblOccupations.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }




        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteOccupation(tblOccupation Occupation)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblOccupation Data = new tblOccupation();

        //    try
        //    {

        //        if (DB.tblPersons.Where(x => x.OccupationCode == Occupation.OccupationId).FirstOrDefault() == null)
        //        {
        //            Data = DB.tblOccupations.Select(r => r).Where(x => x.OccupationId == Occupation.OccupationId).FirstOrDefault();
        //            DB.Entry(Data).State = EntityState.Deleted;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            return Json(2);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult Products(string Success, string Update, string Delete)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    ViewBag.ProductType= DB.tblProductTypes.Where(x => x.isActive == true).ToList();
        //    var Data = DB.tblProducts.Where(x => x.isActive == true).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateProduct(tblProduct Product)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblProduct Data = new tblProduct();
        //    tblProduct check = new tblProduct();

        //    try
        //    {
        //        if (Product.ProductId != 0)
        //        {

        //            check = DB.tblProducts.Select(r => r).Where(x => x.Code == Product.Code).FirstOrDefault();
        //            if (check == null || check.ProductId == Product.ProductId)
        //            {
        //                Data = DB.tblProducts.Select(r => r).Where(x => x.ProductId == Product.ProductId).FirstOrDefault();

        //                Data.Name = Product.Name;
        //                Data.ProductTypeId = Product.ProductTypeId;
        //                Data.Code = Product.Code;
        //                Data.Price = Product.Price;
        //                Data.ValidFor = Product.ValidFor;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {

        //            if (DB.tblProducts.Select(r => r).Where(x => x.Code == Product.Code).FirstOrDefault() == null)
        //            {
        //                Data = Product;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblProducts.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteProduct(tblProduct Product)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblProduct Data = new tblProduct();

        //    try
        //    {
        //        Data = DB.tblProducts.Select(r => r).Where(x => x.ProductId == Product.ProductId).FirstOrDefault();
        //        DB.Entry(Data).State = EntityState.Deleted;
        //        DB.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult ProductTypes(string Success, string Update, string Delete, string FError)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    var Data = DB.tblProductTypes.Where(x => x.isActive == true).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    @ViewBag.FError = FError;

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateProductType(tblProductType ProductType)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblProductType Data = new tblProductType();
        //    tblProductType check = new tblProductType();

        //    try
        //    {
        //        if (ProductType.ProductTypeId != 0)
        //        {

        //            check = DB.tblProductTypes.Select(r => r).Where(x => x.Code == ProductType.Code).FirstOrDefault();
        //            if (check == null || check.ProductTypeId == ProductType.ProductTypeId)
        //            {
        //                Data = DB.tblProductTypes.Select(r => r).Where(x => x.ProductTypeId == ProductType.ProductTypeId).FirstOrDefault();

        //                Data.Name = ProductType.Name;
        //                Data.Code = ProductType.Code;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {

        //            if (DB.tblProductTypes.Select(r => r).Where(x => x.Code == ProductType.Code).FirstOrDefault() == null)
        //            {
        //                Data = ProductType;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblProductTypes.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }




        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteProductType(tblProductType ProductType)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblProductType Data = new tblProductType();

        //    try
        //    {
        //        if(DB.tblProducts.Where(x=>x.ProductTypeId==ProductType.ProductTypeId).FirstOrDefault()==null)
        //        {
        //            Data = DB.tblProductTypes.Select(r => r).Where(x => x.ProductTypeId == ProductType.ProductTypeId).FirstOrDefault();
        //            DB.Entry(Data).State = EntityState.Deleted;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            return Json(2);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult Status(string Success, string Update, string Delete, string FError)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    var Data = DB.tblStatus.Where(x => x.isActive == true).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    ViewBag.FError = FError;

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateStatus(tblStatus Status)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblStatus Data = new tblStatus();
        //    tblStatus check = new tblStatus();

        //    try
        //    {
        //        if (Status.StatusId != 0)
        //        {

        //            check = DB.tblStatus.Select(r => r).Where(x => x.Code == Status.Code).FirstOrDefault();
        //            if (check == null || check.StatusId == Status.StatusId)
        //            {
        //                Data = DB.tblStatus.Select(r => r).Where(x => x.StatusId == Status.StatusId).FirstOrDefault();

        //                Data.Name = Status.Name;
        //                Data.Code = Status.Code;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {

        //            if (DB.tblStatus.Select(r => r).Where(x => x.Code == Status.Code).FirstOrDefault() == null)
        //            {
        //                Data = Status;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblStatus.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }




        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteStatus(tblStatus Status)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblStatus Data = new tblStatus();

        //    try
        //    {
        //        if (DB.tblPersons.Where(x => x.Status == Status.StatusId).FirstOrDefault() == null)
        //        {
        //            Data = DB.tblStatus.Select(r => r).Where(x => x.StatusId == Status.StatusId).FirstOrDefault();
        //            DB.Entry(Data).State = EntityState.Deleted;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            return Json(2);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult Sex(string Success, string Update, string Delete, string FError)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    var Data = DB.tblSex.Where(x => x.isActive == true).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    ViewBag.FError = FError;

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateSex(tblSex Sex)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblSex Data = new tblSex();
        //    tblSex check = new tblSex();

        //    try
        //    {
        //        if (Sex.SexId != 0)
        //        {

        //            check = DB.tblSex.Select(r => r).Where(x => x.Code == Sex.Code).FirstOrDefault();
        //            if (check == null || check.SexId == Sex.SexId)
        //            {
        //                Data = DB.tblSex.Select(r => r).Where(x => x.SexId == Sex.SexId).FirstOrDefault();

        //                Data.Name = Sex.Name;
        //                Data.Code = Sex.Code;
        //                Data.isActive = true;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }

        //        }
        //        else
        //        {

        //            if (DB.tblSex.Select(r => r).Where(x => x.Code == Sex.Code).FirstOrDefault() == null)
        //            {
        //                Data = Sex;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblSex.Add(Data);
        //                DB.SaveChanges();

        //            }
        //            else
        //            {
        //                return Json(1);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }




        //    return Json(0);
        //}


        //[HttpPost]
        //public ActionResult DeleteSex(tblSex Sex)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblSex Data = new tblSex();

        //    try
        //    {
        //        if (DB.tblPersons.Where(x => x.Sex == Sex.SexId).FirstOrDefault() == null)
        //        {
        //            Data = DB.tblSex.Select(r => r).Where(x => x.SexId == Sex.SexId).FirstOrDefault();
        //            DB.Entry(Data).State = EntityState.Deleted;
        //            DB.SaveChanges();
        //        }
        //        else
        //        {
        //            return Json(2);
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult Productpackages(int? id,int? Success, string Delete)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    List<ProductProductPackage> ProductPackage = null;

            
        //    ViewBag.ProductPackage = DB.tblProductPackages.Where(x => x.isActive == true).ToList();
        //    if(Success > 0)
        //    {
        //        ViewBag.Update = "Productpackage has been update successfully.";
        //    }
        //    else if(Success==-1)
        //    {
        //        ViewBag.Success = "Productpackage has been add successfully.";
        //    }
        //    ViewBag.Delete = Delete;

        //    ViewBag.Products = DB.tblProducts.Where(x => x.isActive == true).ToList();
        //    if (id != null && id != 0)
        //    {

        //        ProductPackage = (from PP in DB.tblProductPackages
        //                          join PPP in DB.tblProductPackageProducts on PP.ProductPackageId equals PPP.ProductPackageId
        //                          join P in DB.tblProducts on PPP.ProductId equals P.ProductId
        //                          where PP.ProductPackageId == id
        //                          select new ProductProductPackage
        //                          {
        //                              ProductPackage = PP,
        //                              ProductPackageProduct = PPP,
        //                              Product = P


        //                          }).ToList();



        //        //ProductPackage = DB.tblProductPackages.Where(x => x.ProductPackageId == id).FirstOrDefault();

        //        //ViewBag.ProductPackageProduct = DB.tblProductPackageProducts.Where(x => x.ProductPackageId == id).ToList();
        //        //return View(ProductPackage);
        //    }


        //    return View(ProductPackage);
        //}

        //public ActionResult CreateProductPackage(int? id)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    //tblProductPackage ProductPackage = null;  
        //    List<ProductProductPackage> ProductPackage = null ;
            
        //    ViewBag.Products = DB.tblProducts.Where(x => x.isActive == true).ToList();
        //    if (id != null && id != 0)
        //    {
                
        //        ProductPackage = (from PP in DB.tblProductPackages
        //                                      join PPP in DB.tblProductPackageProducts on PP.ProductPackageId equals PPP.ProductPackageId
        //                                      join P in DB.tblProducts on PPP.ProductId equals P.ProductId
        //                                      where PP.ProductPackageId == id
        //                                      select new ProductProductPackage
        //                                      {
        //                                          ProductPackage = PP,
        //                                          ProductPackageProduct=PPP,
        //                                          Product=P


        //                                      }).ToList();

                

        //        //ProductPackage = DB.tblProductPackages.Where(x => x.ProductPackageId == id).FirstOrDefault();

        //        //ViewBag.ProductPackageProduct = DB.tblProductPackageProducts.Where(x => x.ProductPackageId == id).ToList();
        //        return View(ProductPackage);
        //    }
        //    else
        //    {
        //        return View(ProductPackage);
        //    }
        //}


        //[HttpPost]
        //public ActionResult CreateProductPackage(List<tblProduct> TailData, List<tblProductPackage> HeadData)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    tblProductPackage Data = new tblProductPackage();
        //    tblProductPackage Check = new tblProductPackage();
        //    List<tblProductPackageProduct> Data2 = new List<tblProductPackageProduct>();

        //    var CheckName = HeadData[0].Name;
        //    var CheckProductPackageId = HeadData[0].ProductPackageId;

        //    Check = DB.tblProductPackages.Select(r => r).Where(x => x.Name == CheckName).FirstOrDefault();
        //        int Succ = 0;
        //    try
        //    {
        //        if(HeadData[0].ProductPackageId!=0)
        //        {
        //            if (Check == null ||Check.ProductPackageId== HeadData[0].ProductPackageId)
        //            {
        //                Data = DB.tblProductPackages.Where(x => x.ProductPackageId == CheckProductPackageId).FirstOrDefault();
        //                Data.Code = HeadData[0].Code;
        //                Data.Name = HeadData[0].Name;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.Entry(Data);
        //                DB.SaveChanges();
        //                Succ = 1;
        //            }
        //            else
        //            {
        //                ViewBag.Error = "Package Already Exist!!!";
        //                var redirectUrl1 = new UrlHelper(Request.RequestContext).Action("ProductPackages", "Home", new { Delete = ViewBag.Error });
        //                return Json(new { Url = redirectUrl1 });
        //            }

        //            Data2 = DB.tblProductPackageProducts.Select(r => r).Where(x => x.ProductPackageId == CheckProductPackageId).ToList();
        //            foreach (var item in Data2)
        //            {
        //                DB.Entry(item).State = EntityState.Deleted; ;
        //            }
        //            DB.SaveChanges();

        //            if (TailData == null)
        //            {
        //                TailData = new List<tblProduct>();
        //            }


        //            //Loop and insert records.

        //            int count = 0;
        //            foreach (tblProduct Item in TailData)
        //            {
        //                tblProductPackageProduct Data1 = new tblProductPackageProduct();
        //                if (count != TailData.Count)
        //                {
        //                    Data1.ProductPackageId = DB.tblProductPackages.Where(x => x.Name == CheckName).Select(r => r.ProductPackageId).FirstOrDefault();
        //                    Data1.ProductId = Item.ProductId;
        //                    DB.tblProductPackageProducts.Add(Data1);
        //                }


        //                count++;


        //            }
        //            DB.SaveChanges();
        //            var RedirectUrl = new UrlHelper(Request.RequestContext).Action("ProductPackages", "Home", new { Success = Succ });
        //            return Json(new { Url = RedirectUrl });
        //        }
        //        else
        //        {
        //            if (Check == null)
        //            {
        //                Data.Code = HeadData[0].Code;
        //                Data.Name = HeadData[0].Name;
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblProductPackages.Add(Data);
        //                DB.SaveChanges();
        //                Succ = -1;
        //            }
        //            else
        //            {
        //                ViewBag.Error = "Package Already Exist!!!";
        //                var redirectUrl1 = new UrlHelper(Request.RequestContext).Action("ProductPackages", "Home", new { Delete = ViewBag.Error });
        //                return Json(new { Url = redirectUrl1 });
        //            }



        //            if (TailData == null)
        //            {
        //                TailData = new List<tblProduct>();
        //            }


        //            //Loop and insert records.

        //            int count = 0;
        //            foreach (tblProduct Item in TailData)
        //            {
        //                tblProductPackageProduct Data1 = new tblProductPackageProduct();
        //                if (count != TailData.Count)
        //                {
        //                    Data1.ProductPackageId = DB.tblProductPackages.Where(x => x.Name == CheckName).Select(r => r.ProductPackageId).FirstOrDefault();
        //                    Data1.ProductId = Item.ProductId;
        //                    DB.tblProductPackageProducts.Add(Data1);
        //                }
        //                count++;
        //            }
        //            DB.SaveChanges();
        //        }
                
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    var redirectUrl = new UrlHelper(Request.RequestContext).Action("ProductPackages", "Home",new { Success= Succ });
        //    return Json(new { Url = redirectUrl });
        //}

    

        //[HttpPost]
        //public ActionResult DeleteProductPackage(tblProductPackage ProductPackage)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblProductPackage Data = new tblProductPackage();
        //    List<tblProductPackageProduct> Data1 = new List<tblProductPackageProduct>();

        //    try
        //    {

                
        //            Data1 = DB.tblProductPackageProducts.Select(r => r).Where(x => x.ProductPackageId == ProductPackage.ProductPackageId).ToList();
        //            foreach (var item in Data1)
        //            {
        //                DB.Entry(item).State = EntityState.Deleted; ;
        //            }
        //        DB.SaveChanges();

        //        Data = DB.tblProductPackages.Select(r => r).Where(x => x.ProductPackageId == ProductPackage.ProductPackageId).FirstOrDefault();
        //        DB.Entry(Data).State = EntityState.Deleted;
        //        DB.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}



        //public ActionResult Settings(int? isSuccess)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    var Data = DB.tblSettings.Where(x => x.isActive==true).FirstOrDefault();
        //    if(isSuccess==1)
        //    {
        //        ViewBag.Error = "Record Successfully Updated!!!";
        //    }

            

        //    return View(Data);
        //}

        //[HttpPost]
        //public ActionResult CreateSetting(tblSetting Setting)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    tblSetting Data = new tblSetting();
        //    tblRole Foreign = new tblRole();
        //    try
        //    {
        //        if(Setting.IsActive1==null)
        //        {
        //            Setting.IsActive1 = false;
        //        }
        //        //Foreign = DB.tblRoles.Where(x => x.RoleId == Setting.RoleId).FirstOrDefault();
        //        //Data.tblRole = Foreign;
        //        Data = DB.tblSettings.Select(r => r).Where(x => x.SettingId == Setting.SettingId).FirstOrDefault();
        //        Data.SettingId = Setting.SettingId;
        //        Data.DateFormat = Setting.DateFormat;
        //        Data.ReportsDateFormat = Setting.ReportsDateFormat;
        //        Data.NextWSA = Setting.NextWSA;
        //        Data.NextPassport = Setting.NextPassport;
        //        Data.NumberOfRetrieves = Setting.NumberOfRetrieves;
        //        Data.LetterCase = Setting.LetterCase;
        //        Data.FontStyle = Setting.FontStyle;
        //        Data.FontSize = Setting.FontSize;
        //        Data.Email = Setting.Email;
        //        Data.Password = Setting.Password;
        //        Data.SMTP = Setting.SMTP;
        //        Data.Port = Setting.Port;
        //        Data.IsActive1 = Setting.IsActive1;
        //        DB.Entry(Data);
        //        DB.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return RedirectToAction("Settings", new { isSuccess = 1 });
        //}


        

        //public ActionResult Persons(string Success, string Update, string Delete,string RecordType)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    List<tblPerson> PersonList = new List<tblPerson>();
        //    if (RecordType== "Information Only")
        //    {
                
        //        PersonList = DB.tblPersons.Where(x => x.isActive == true && x.WSANumber==0).ToList();
        //    }
        //    else if(RecordType== "WSA Only")
        //    {
        //        PersonList = DB.tblPersons.Where(x => x.isActive == true && x.WSANumber != 0).ToList();
        //    }
        //    else
        //    {
        //        PersonList = DB.tblPersons.Where(x => x.isActive == true).ToList();
        //    }
        //    ViewBag.RecordType = RecordType;
        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    return View(PersonList);
        //}

        //public ActionResult CreatePerson(int? id, string Success, string Update, string Delete,int tab=0)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblPerson Person = new tblPerson();
        //    ViewBag.Country= DB.tblCountries.Where(x => x.isActive == true).ToList();
        //    ViewBag.Eye= DB.tblEyes.Where(x => x.isActive == true).ToList();
        //    ViewBag.Occupation= DB.tblOccupations.Where(x => x.isActive == true).ToList();
        //    ViewBag.Sex= DB.tblSex.Where(x => x.isActive == true).ToList();
        //    ViewBag.Status= DB.tblStatus.Where(x => x.isActive == true).ToList();
        //    ViewBag.tab = tab;
        //    int CurrenYear = DateTime.Now.Year;
        //    List<int> Years = new List<int>();
        //    for(int i=1930;i<= CurrenYear;i++)
        //    {
        //        Years.Add(i);
        //    }
        //    ViewBag.Year = Years;
        //    ViewBag.WSA = DB.tblSettings.Select(s => s.NextWSA).FirstOrDefault();

        //    if (id != null && id != 0)
        //    {
        //        ViewBag.Child = DB.tblChilds.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

        //        ViewBag.Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

        //        ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
        //        ViewBag.DocImg = DB.tblDocumentImgs.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

        //        ViewBag.Success = Success;
        //        ViewBag.Update = Update;
        //        ViewBag.Delete = Delete;
        //        ViewBag.Product = DB.tblProducts.Where(x => x.isActive == true).ToList();
        //        ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Cost).Sum();
        //        ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();

        //        ViewBag.TransCount = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();
        //        Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
        //        if (DB.tblPersons.Max(s => s.WSANumber) != null)
        //        {
        //            ViewBag.WAS = DB.tblPersons.Max(s => s.WSANumber) + 1;
        //        }
        //        return View(Person);
        //    }
        //    else
        //    {
        //        ViewBag.WAS = null;
        //        Person.PersonIDNumber=0;
        //        if(DB.tblPersons.Max(s=>s.WSANumber)!=null)
        //        {
        //            ViewBag.WAS = DB.tblPersons.Max(s => s.WSANumber) + 1;
        //        }

        //        return View(Person);
        //    }
        //}

        //[HttpPost]
        //public ActionResult CreatePerson(tblPerson Person, HttpPostedFileBase Image, HttpPostedFileBase SigImage, HttpPostedFileBase CertificationFile)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblPerson Data = new tblPerson();
        //    try
        //    {
        //        HttpCookie cookieObj = Request.Cookies["Settings"];
        //        string DateFormat = cookieObj["DateFormat"];
        //        //string[] DateSplit = Person.DateOfBirth.Split('-');
        //        //string[] FormatCheck = DateFormat.Split('-');
        //        ViewBag.User = Session["User"];

                


        //        if (Person.PersonIDNumber == 0)
        //        {
        //            //if (DB.tblPersons.Select(r => r).Where(x => x.EMail==Person.EMail).FirstOrDefault() == null)
        //            //{
        //                Data = Person;

        //            //if (FormatCheck[0] == "yyyy")
        //            //{
        //            //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
        //            //    {
        //            //        Data.BirthYear = Convert.ToInt32(DateSplit[0]);
        //            //    }

        //            //}
        //            //else if (FormatCheck[1] == "yyyy")
        //            //{
        //            //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
        //            //    {
        //            //        Data.BirthYear = Convert.ToInt32(DateSplit[1]);
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
        //            //    {
        //            //        Data.BirthYear = Convert.ToInt32(DateSplit[2]);
        //            //    }
        //            //}
        //            //if (FormatCheck[0] == "MM")
        //            //{
        //            //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
        //            //    {
        //            //        Data.BirthMonth = Convert.ToInt32(DateSplit[0]);
        //            //    }
        //            //}
        //            //else if (FormatCheck[1] == "MM")
        //            //{
        //            //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
        //            //    {
        //            //        Data.BirthMonth = Convert.ToInt32(DateSplit[1]);
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
        //            //    {
        //            //        Data.BirthMonth = Convert.ToInt32(DateSplit[2]);
        //            //    }
        //            //}
        //            //if (FormatCheck[0] == "dd")
        //            //{
        //            //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
        //            //    {
        //            //        Data.BirthDay = Convert.ToInt32(DateSplit[0]);
        //            //    }
        //            //}
        //            //else if (FormatCheck[1] == "dd")
        //            //{
        //            //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
        //            //    {
        //            //        Data.BirthDay = Convert.ToInt32(DateSplit[1]);
        //            //    }

        //            //}
        //            //else
        //            //{
        //            //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
        //            //    {
        //            //        Data.BirthDay = Convert.ToInt32(DateSplit[2]);
        //            //    }
        //            //}


        //            Data.OccupationId = Person.OccupationCode;
        //                string folder = Server.MapPath(string.Format("~/{0}/", "Uploading"));
        //                if (!Directory.Exists(folder))
        //                {
        //                    Directory.CreateDirectory(folder);
        //                }
        //                string path = null;
        //                if (Image!=null)
        //                {
        //                    path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(Image.FileName));
        //                    Image.SaveAs(path);
        //                    path = Path.Combine("\\Uploading", Path.GetFileName(Image.FileName));
        //                    Data.Photo = path;
        //                }
        //                else
        //                {
        //                    Data.Photo = "\\Uploading\\user-image.png";
        //                }
        //                if (SigImage != null)
        //                {
        //                    path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(SigImage.FileName));
        //                    SigImage.SaveAs(path);
        //                    path = Path.Combine("\\Uploading", Path.GetFileName(SigImage.FileName)); Data.SignaturePath = path;
        //                    Data.SignaturePath = path;
        //                }
        //                else
        //                {
        //                    Data.SignaturePath = "\\Uploading\\sig.png";
        //                }
        //                if (CertificationFile != null)
        //                {
        //                    path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(CertificationFile.FileName));
        //                    CertificationFile.SaveAs(path);
        //                    path = Path.Combine("\\Uploading", Path.GetFileName(CertificationFile.FileName));
        //                    Data.Certification = path;
        //                }
        //                else
        //                {
        //                    Data.Certification = "\\Uploading\\file.png";
        //                }
                        

                       


        //                Data.EntryDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.LastModifiedDate= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.CreatedBy = ViewBag.User.UserId;
        //                Data.LastEditedBy = ViewBag.User.UserId;
        //                Data.isActive = true;
        //            int? WSANum = 0;
        //            if (Person.WSANumber!=null)
        //            {
        //                var nextWSA = DB.tblPersons.Max(s => s.WSANumber);
        //                if (nextWSA != null)
        //                {
        //                    Person.WSANumber = DB.tblPersons.Max(s => s.WSANumber) + 1;
        //                    WSANum = DB.tblPersons.Max(s => s.WSANumber) + 2;
        //                }
        //                else
        //                {
        //                    Person.WSANumber = Person.WSANumber;
        //                    WSANum = Person.WSANumber + 1;
        //                }

        //                var Data1 = DB.tblSettings.FirstOrDefault();
        //                Data1.NextWSA = WSANum.ToString();
        //                DB.Entry(Data1);
        //                DB.SaveChanges();
        //            }
        //            DB.tblPersons.Add(Data);
        //            DB.SaveChanges();
        //            var ID = Data.PersonIDNumber;
        //            Data = DB.tblPersons.Where(x => x.PersonIDNumber == ID).FirstOrDefault();
        //            string vCardText = "BEGIN:VCARD\r\nN:";
        //            vCardText += "" + Person.FirstName + " " + Person.LastName + "\r\n";
        //            //vCardText += "TITLE:" + Data.tblOccupation.Name + "\r\n";
        //            vCardText += "TEL:" + Person.Phone + "\r\n";
        //            vCardText += "END:VCARD";
        //            string QRCodeImagePath = GenerateQRCode(vCardText, ID);

        //            Data.QRCode = QRCodeImagePath;
        //            DB.Entry(Data);
        //            DB.SaveChanges();

                    
                    
        //            return RedirectToAction("Persons", new { Success = "Person has been add successfully." });
        //            //}
        //            //else
        //            //{
        //            //    ViewBag.Error = "Person Already Exsist!!!";
        //            //}
        //        }
        //        else
        //        {
        //            var check = DB.tblPersons.Select(r => r).Where(x => x.EMail == Person.EMail).FirstOrDefault();
        //            //if (check == null || check.PersonIDNumber == Person.PersonIDNumber)
        //            //{
        //                Data = DB.tblPersons.Select(r => r).Where(x => x.PersonIDNumber == Person.PersonIDNumber).FirstOrDefault();
        //                bool SCheck = false;
        //                if (Data.Status == Person.Status)
        //                {
        //                    SCheck = true;
        //                }
        //            //if (FormatCheck[0] == "yyyy")
        //            //{
        //            //    if(DateSplit[0] != "xx" && DateSplit[0] != "xxx")
        //            //    {
        //            //        Data.BirthYear = Convert.ToInt32(DateSplit[0]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthYear = null;
        //            //    }

        //            //}
        //            //else if (FormatCheck[1] == "yyyy")
        //            //{
        //            //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
        //            //    {
        //            //        Data.BirthYear = Convert.ToInt32(DateSplit[1]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthYear = null;
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
        //            //    {
        //            //        Data.BirthYear = Convert.ToInt32(DateSplit[2]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthYear = null;
        //            //    }
        //            //}
        //            //if (FormatCheck[0] == "MM")
        //            //{
        //            //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
        //            //    {
        //            //        Data.BirthMonth = Convert.ToInt32(DateSplit[0]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthMonth = null;
        //            //    }
        //            //}
        //            //else if (FormatCheck[1] == "MM")
        //            //{
        //            //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
        //            //    {
        //            //        Data.BirthMonth = Convert.ToInt32(DateSplit[1]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthMonth = null;
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
        //            //    {
        //            //        Data.BirthMonth = Convert.ToInt32(DateSplit[2]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthMonth = null;
        //            //    }
        //            //}
        //            //if (FormatCheck[0] == "dd")
        //            //{
        //            //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
        //            //    {
        //            //        Data.BirthDay = Convert.ToInt32(DateSplit[0]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthDay = null;
        //            //    }
        //            //}
        //            //else if (FormatCheck[1] == "dd")
        //            //{
        //            //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
        //            //    {
        //            //        Data.BirthDay = Convert.ToInt32(DateSplit[1]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthDay = null;
        //            //    }

        //            //}
        //            //else
        //            //{
        //            //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
        //            //    {
        //            //        Data.BirthDay = Convert.ToInt32(DateSplit[2]);
        //            //    }
        //            //    else
        //            //    {
        //            //        Data.BirthDay = null;
        //            //    }
        //            //}
        //            Data.FirstName = Person.FirstName;
        //                Data.LastName = Person.LastName;
        //                Data.CityOfBirth = Person.CityOfBirth;
        //                Data.Phone = Person.Phone;
        //                Data.Fax = Person.Fax;
        //                Data.EMail= Person.EMail;
        //                Data.Website= Person.Website;
        //                //Data.DateOfBirth= Person.DateOfBirth;
        //                Data.Marks= Person.Marks;
        //                Data.FatherName= Person.FatherName;
        //                Data.MotherName= Person.MotherName;
        //                Data.WSANumber= Person.WSANumber;
        //                Data.Comments= Person.Comments;
        //                Data.Title= Person.Title;
        //                Data.Height= Person.Height;
        //                Data.HeightUnit = Person.HeightUnit;
        //                Data.CountryOfApplication= Person.CountryOfApplication;
        //                Data.CountryOfBirth= Person.CountryOfBirth;
        //                Data.CountryOfBirthStatistical= Person.CountryOfBirthStatistical;
        //                Data.Sex= Person.Sex;
        //                Data.Status= Person.Status;
        //                Data.Eyes= Person.Eyes;
        //                Data.OccupationCode= Person.OccupationCode;
        //                Data.OccupationId = Person.OccupationCode;
        //                Data.TransactionCount= Person.TransactionCount;
        //            Data.BirthDay = Person.BirthDay;
        //            Data.BirthMonth = Person.BirthMonth;
        //            Data.BirthYear = Person.BirthYear;


        //                string path = null;
        //                if (SigImage != null)
        //                {
        //                    path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(SigImage.FileName));

        //                    SigImage.SaveAs(path);
        //                    path = Path.Combine("\\Uploading", Path.GetFileName(SigImage.FileName));

        //                    Data.SignaturePath = path;
        //                }
        //                else
        //                {
        //                    Data.SignaturePath = Person.SignaturePath;
        //                }

        //                if (Image != null)
        //                {
        //                    path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(Image.FileName));

        //                    Image.SaveAs(path);
        //                    path = Path.Combine("\\Uploading", Path.GetFileName(Image.FileName));

        //                    Data.Photo = path;
        //                }
        //                else
        //                {
        //                    Data.Photo = Person.Photo;
        //                }

        //                if (CertificationFile != null)
        //                {
        //                    path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(CertificationFile.FileName));
        //                    CertificationFile.SaveAs(path);
        //                    path = Path.Combine("\\Uploading", Path.GetFileName(CertificationFile.FileName));
        //                    Data.Certification = path;
        //                }
        //                else
        //                {
        //                    Data.Certification = Person.Certification;
        //                }

        //                int? WSANum = 0;
        //                if (SCheck==false&& Person.WSANumber != null)
        //                {
        //                    var nextWSA = DB.tblPersons.Max(s => s.WSANumber);
        //                    if(nextWSA!=null)
        //                    {
        //                        Person.WSANumber = DB.tblPersons.Max(s => s.WSANumber) + 1;
        //                        WSANum = DB.tblPersons.Max(s => s.WSANumber) + 2;
        //                    }
        //                    else
        //                    {
        //                        Person.WSANumber = Person.WSANumber;
        //                        WSANum = Person.WSANumber + 1;
        //                    }

                            

        //                    var Data1 = DB.tblSettings.FirstOrDefault();
        //                    Data1.NextWSA = WSANum.ToString();
        //                    DB.Entry(Data1);
        //                    DB.SaveChanges();
        //                }

        //                Data.LastModifiedDate = DateTime.Now;
        //                Data.LastEditedBy = ViewBag.User.UserId;
        //                DB.Entry(Data);
        //                DB.SaveChanges();
        //                Data = DB.tblPersons.Where(x => x.PersonIDNumber == Person.PersonIDNumber).FirstOrDefault();
        //                string vCardText = "BEGIN:VCARD\r\nN:";
        //                vCardText += "" + Person.FirstName+" "+ Person.LastName + "\r\n";
        //                //vCardText += "TITLE:" + Data.tblOccupation.Name + "\r\n";
        //                vCardText += "TEL:" + Person.Phone + "\r\n";
        //                vCardText += "END:VCARD";
        //            string QRCodeImagePath = GenerateQRCode(vCardText, Person.PersonIDNumber);
        //            Data.QRCode = QRCodeImagePath;
        //            DB.Entry(Data);
        //                DB.SaveChanges();
                        
        //                return RedirectToAction("Persons", new { Update = "Person has been Update successfully." });
        //            //}
        //            //else
        //            //{
        //            //    ViewBag.Error = "Person Already Exsist!!!";
        //            //}

        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
            
        //    return View(Person);
        //}

        //[HttpPost]
        //public ActionResult DeletePerson(int PersonId)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblPerson Data = new tblPerson();
        //    List<tblAddress> Data1 = new List<tblAddress>();
        //    List <tblTransaction> Data2 = new List<tblTransaction>();
        //    List<tblChild> Data3 = new List<tblChild>();
        //    List<tblDocumentImg> Data4 = new List<tblDocumentImg>();
        //    try
        //    {
        //        Data1 = DB.tblAddresses.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
        //        if (Data1.Count() > 0)
        //        {
        //            DB.tblAddresses.RemoveRange(Data1);
        //            DB.SaveChanges();
        //        }

        //        Data2 = DB.tblTransactions.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
        //        if (Data2.Count() > 0)
        //        {
        //            DB.tblTransactions.RemoveRange(Data2);
        //            DB.SaveChanges();
        //        }
        //        Data3 = DB.tblChilds.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
        //        if (Data3.Count() > 0)
        //        {
        //            DB.tblChilds.RemoveRange(Data3);
        //            DB.SaveChanges();
        //        }
        //        Data4 = DB.tblDocumentImgs.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
        //        if (Data4.Count() > 0)
        //        {
        //            DB.tblDocumentImgs.RemoveRange(Data4);
        //            DB.SaveChanges();
        //        }
                
        //        Data = DB.tblPersons.Select(r => r).Where(x => x.PersonIDNumber == PersonId).FirstOrDefault();
        //        DB.Entry(Data).State = EntityState.Deleted;
        //        DB.SaveChanges();
        //        return Json(1);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult CreateChild(int? id, string Success, string Update, string Delete)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblPerson Person = null;
        //    ViewBag.Child = DB.tblChilds.Where(x => x.isActive == true && x.PersonIDNumber==id).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;

        //    ViewBag.Sex= DB.tblSex.Where(x => x.isActive == true).ToList();
        //    if (id != null && id != 0)
        //    {

        //        Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
        //        return View(Person);
        //    }
        //    else
        //    {
        //        return View(Person);
        //    }
        //}


        //[HttpPost]
        //public ActionResult CreateChild(tblChild Child)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    tblChild Data = new tblChild();
        //    try
        //    {
        //        if (Child.ChildId == 0)
        //        {
        //            if (DB.tblChilds.Select(r => r).Where(x => x.Name == Child.Name&&x.PersonIDNumber==Child.PersonIDNumber).FirstOrDefault() == null)
        //            {
        //                Data = Child;
        //                if(Data.BirthDate==null)
        //                {
        //                    Data.BirthDate = new DateTime(1000, 01, 01).ToString();
        //                }
                        
        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblChilds.Add(Data);
        //                DB.SaveChanges();
        //                return RedirectToAction("CreatePerson", new { Success = "Child has been add successfully.", id = Child.PersonIDNumber, tab = 3 });
        //            }
        //            else
        //            {
        //                ViewBag.Error = "Child Already Exsist!!!";
        //            }
        //        }
        //        else
        //        {
        //            var check = DB.tblChilds.Select(r => r).Where(x => x.Name == Child.Name && x.PersonIDNumber == Child.PersonIDNumber).FirstOrDefault();
        //            if (check == null || check.ChildId == Child.ChildId)
        //            {
                        
        //                Data = DB.tblChilds.Select(r => r).Where(x => x.ChildId == Child.ChildId).FirstOrDefault();
        //                Data.PersonIDNumber = Child.PersonIDNumber;
        //                Data.Name = Child.Name;
        //                Data.SexId = Child.SexId;
        //                //Data.BirthDate = Child.BirthDate;
        //                Data.BirthDay = Child.BirthDay;
        //                Data.BirthMonth = Child.BirthMonth;
        //                Data.BirthYear = Child.BirthYear;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();
        //                return RedirectToAction("CreatePerson", new { Update = "Child has been Update successfully.", id = Data.PersonIDNumber, tab = 3 });
        //            }
        //            else
        //            {
        //                ViewBag.Error = "Child Already Exsist!!!";
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return RedirectToAction("CreateChild");
        //}

        //[HttpPost]
        //public ActionResult DeleteChild(int ChildId)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblChild Data = new tblChild();

        //    try
        //    {
        //        Data = DB.tblChilds.Select(r => r).Where(x => x.ChildId == ChildId).FirstOrDefault();
        //        DB.Entry(Data).State = EntityState.Deleted;
        //        DB.SaveChanges();
        //        return Json(1);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}


        //public ActionResult CreateAddress(int? id, string Success, string Update, string Delete)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblPerson Person = null;
        //    ViewBag.Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;

        //    ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
        //    if (id != null && id != 0)
        //    {

        //        Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
        //        return View(Person);
        //    }
        //    else
        //    {
        //        return View(Person);
        //    }
        //}


        //[HttpPost]
        //public ActionResult CreateAddress(tblAddress Address)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    tblAddress Data = new tblAddress();
        //    try
        //    {
        //        if (Address.AddressIDNumber == 0)
        //        {
        //                Data = Address;

        //                Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                Data.isActive = true;
        //                DB.tblAddresses.Add(Data);
        //                DB.SaveChanges();
        //                return RedirectToAction("CreatePerson", new { Success = "Address has been add successfully.", id = Address.PersonIDNumber, tab = 2});
                   
        //        }
        //        else
        //        {

        //                Data = DB.tblAddresses.Select(r => r).Where(x => x.AddressIDNumber == Address.AddressIDNumber).FirstOrDefault();
        //                Data.PersonIDNumber = Address.PersonIDNumber;
        //                Data.Address1 = Address.Address1;
        //                Data.CareOf = Address.CareOf;
        //                Data.City = Address.City;
        //                Data.State = Address.State;
        //                Data.PostalCode = Address.PostalCode;
        //                Data.Country = Address.Country;
        //                Data.Label = Address.Label;
        //                Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.Entry(Data);
        //                DB.SaveChanges();
        //                return RedirectToAction("CreatePerson", new { Update = "Address has been Update successfully.", id = Address.PersonIDNumber, tab = 2 });
                   

        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return RedirectToAction("CreateAddress");
        //}

        //[HttpPost]
        //public ActionResult DeleteAddress(int AddressId)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblAddress Data = new tblAddress();

        //    try
        //    {
        //        Data = DB.tblAddresses.Select(r => r).Where(x => x.AddressIDNumber == AddressId).FirstOrDefault();
        //        DB.Entry(Data).State = EntityState.Deleted;
        //        DB.SaveChanges();
        //        return Json(1);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}

        //public ActionResult CreateTransaction(int? id, string Success, string Update, string Delete)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblPerson Person = null;
        //    ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

        //    ViewBag.Success = Success;
        //    ViewBag.Update = Update;
        //    ViewBag.Delete = Delete;
        //    //ViewBag.Product = DB.ProductUnionPackage().ToList();
        //    ViewBag.Product = DB.tblProducts.Where(x => x.isActive == true).ToList();
            
        //    if (id != null && id != 0)
        //    {

        //        ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber==id).Select(s => s.Cost).Sum();
        //        ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();
        //        Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
        //        return View(Person);
        //    }
        //    else
        //    {
        //        return View(Person);
        //    }
        //}


        //[HttpPost]
        //public ActionResult CreateTransaction(tblTransaction Transaction)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    tblTransaction Data = new tblTransaction();
        //    try
        //    {
        //        string PassportNum = "";
        //        ViewBag.User = Session["User"];
        //        if (Transaction.TransactionIDNumber == 0)
        //        {
        //            Data = Transaction;
        //            //Data.ApplicationDate =Convert.ToDateTime(Transaction.ApplicationDate);
        //            //Data.IssueDate = Convert.ToDateTime(Transaction.IssueDate);
        //            //Data.SentDate = Convert.ToDateTime(Transaction.SentDate);
        //            //Data.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate);
        //            //if (Transaction.IssueDate.Year == 0001)
        //            //{
        //            //    Transaction.IssueDate = Convert.ToDateTime(Transaction.IssueDate.ToString("yyyy-MM-dd"));
        //            //    if (Transaction.IssueDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.IssueDate.ToString() == "01/01/0001 12:00:00 AM")
        //            //    {
        //            //        Data.IssueDate = new DateTime(9999, 01, 01);
        //            //    }
        //            //}
        //            //if (Transaction.SentDate.Year == 0001)
        //            //{
        //            //    Transaction.SentDate = Convert.ToDateTime(Transaction.SentDate.ToString("yyyy-MM-dd"));
        //            //    if (Transaction.SentDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.SentDate.ToString() == "01/01/0001 12:00:00 AM")
        //            //    {
        //            //        Data.SentDate = new DateTime(9999, 01, 01);

        //            //    }
        //            //}
        //            //if (Transaction.ReturnDate.Year == 0001)
        //            //{
        //            //    Transaction.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate.ToString("yyyy-MM-dd"));
        //            //    if (Transaction.ReturnDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.ReturnDate.ToString() == "01/01/0001 12:00:00 AM")
        //            //    {
        //            //        Data.ReturnDate = new DateTime(9999, 01, 01);

        //            //    }
        //            //}
                   
        //            Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //            Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //            Data.CreatedBy = ViewBag.User.UserId;
        //            Data.EditBy = ViewBag.User.UserId;
        //            Data.isActive = true;
        //            PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
        //            var ID = DB.tblProducts.Where(x => x.ProductId == Transaction.ProductIDNumber).Select(s => s.ProductTypeId).FirstOrDefault();
        //            if (ID==1&& PassportNum != null)
        //            {
        //                //PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
        //                PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
        //                Data.IDCode = PassportNum;

        //                PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
        //                var Data1 = DB.tblSettings.FirstOrDefault();
        //                Data1.NextPassport = PassportNum.ToString();
        //                DB.Entry(Data1);
        //                DB.SaveChanges();
        //            }
        //            else if(ID == 1 && PassportNum == null)
        //            {
                      
        //                PassportNum = (Int32.Parse(Data.IDCode) + 1).ToString();
        //                var Data1 = DB.tblSettings.FirstOrDefault();
        //                Data1.NextPassport = PassportNum.ToString();
        //                DB.Entry(Data1);
        //                DB.SaveChanges();
        //            }
        //            DB.tblTransactions.Add(Data);
        //            DB.SaveChanges();

                    
        //            return RedirectToAction("CreatePerson", new { Success = "Transaction has been add successfully.",id= Transaction.PersonIDNumber, tab = 1 });

        //        }
        //        else
        //        {

        //            Data = DB.tblTransactions.Select(r => r).Where(x => x.TransactionIDNumber == Transaction.TransactionIDNumber).FirstOrDefault();
        //            Data.PersonIDNumber = Transaction.PersonIDNumber;
        //            Data.ProductIDNumber = Transaction.ProductIDNumber;
        //            Data.IDCode = Transaction.IDCode;
        //            Data.Cost = Transaction.Cost;
        //            Data.Quantity = Transaction.Quantity;
        //            Data.Problems = Transaction.Problems;
        //            Data.IssueDate = Transaction.IssueDate;
        //            Data.SentDate = Transaction.SentDate;
        //            Data.ReturnDate = Transaction.ReturnDate;
        //            //if (Transaction.IssueDate.Year == 0001)
        //            //{
        //            //    Transaction.IssueDate = Convert.ToDateTime(Transaction.IssueDate.ToString("yyyy-MM-dd"));
        //            //    if (Transaction.IssueDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.IssueDate.ToString() == "01/01/0001 12:00:00 AM")
        //            //    {
        //            //        Data.IssueDate = new DateTime(9999, 01, 01);
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    Data.IssueDate = Convert.ToDateTime(Transaction.IssueDate);
        //            //}
        //            //if (Transaction.SentDate.Year == 0001)
        //            //{
        //            //    Transaction.SentDate = Convert.ToDateTime(Transaction.SentDate.ToString("yyyy-MM-dd"));
        //            //    if (Transaction.SentDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.SentDate.ToString() == "01/01/0001 12:00:00 AM")
        //            //    {
        //            //        Data.SentDate = new DateTime(9999, 01, 01);

        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    Data.SentDate = Convert.ToDateTime(Transaction.SentDate);
        //            //}
        //            //if (Transaction.ReturnDate.Year == 0001)
        //            //{
        //            //    Transaction.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate.ToString("yyyy-MM-dd"));
        //            //    if (Transaction.ReturnDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.ReturnDate.ToString() == "01/01/0001 12:00:00 AM")
        //            //    {
        //            //        Data.ReturnDate = new DateTime(9999, 01, 01);

        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    Data.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate);
        //            //}
        //            Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //            Data.EditBy = ViewBag.User.UserId;


        //            PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
        //            var ID = DB.tblProducts.Where(x => x.ProductId == Transaction.ProductIDNumber).Select(s => s.ProductTypeId).FirstOrDefault();
        //            if (ID == 1 && PassportNum != null)
        //            {
        //                //PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
        //                PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
        //                Data.IDCode = PassportNum;

        //                PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
        //                var Data1 = DB.tblSettings.FirstOrDefault();
        //                Data1.NextPassport = PassportNum.ToString();
        //                DB.Entry(Data1);
        //                DB.SaveChanges();
        //            }
        //            else if (ID == 1 && PassportNum == null)
        //            {

        //                PassportNum = (Int32.Parse(Data.IDCode) + 1).ToString();
        //                var Data1 = DB.tblSettings.FirstOrDefault();
        //                Data1.NextPassport = PassportNum.ToString();
        //                DB.Entry(Data1);
        //                DB.SaveChanges();
        //            }


        //            DB.Entry(Data);
        //            DB.SaveChanges();
        //            return RedirectToAction("CreatePerson", new { Update = "Transaction has been Update successfully.",id= Transaction.PersonIDNumber,tab=1 });


        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return RedirectToAction("CreatePerson");
        //}


        //[HttpPost]
        //public ActionResult DeleteTransaction(int TransactionId)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    tblTransaction Data = new tblTransaction();

        //    try
        //    {
        //        Data = DB.tblTransactions.Select(r => r).Where(x => x.TransactionIDNumber == TransactionId).FirstOrDefault();
        //        DB.Entry(Data).State = EntityState.Deleted;
        //        DB.SaveChanges();
        //        return Json(1);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return Json(0);
        //}

        //[HttpPost]
        //public JsonResult GetProduct(int id)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    ////Searching records from list using LINQ query  
        //    string IdCode = "";
        //    var ProductList = DB.tblProducts.Where(q => q.ProductId==id).Select(s => s.Price).FirstOrDefault();
        //    var Product = DB.tblProducts.Where(q => q.ProductId==id).FirstOrDefault();
        //    if(Product.tblProductType.ProductTypeId==1)
        //    {
        //        IdCode = DB.tblSettings.Select(x => x.NextPassport).FirstOrDefault();
        //    }
        //    return Json(new { ProductList= ProductList, IdCode= IdCode }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult GetAllProduct(int id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ////Searching records from list using LINQ query  

            ViewBag.ProductList = DB.tblProducts.Where(q => q.ProductId == id).ToList();
            return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult GetAllProductsss(int id)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    ////Searching records from list using LINQ query  
        //    DB.Configuration.ProxyCreationEnabled = false;
        //    ViewBag.ProductList = DB.tblProducts.Where(q => q.ProductId == id).ToList();
        //    return Json(ViewBag.ProductList, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost]
        public JsonResult GetEyeCode(string Prefix)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            //Searching records from list using LINQ query  

            var CountryList = DB.tblEyes.Where(q => q.Code.StartsWith(Prefix)).Select(s => s.Code + "," + s.Name + "," + s.EyeId).ToList();

            return Json(CountryList, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult AddressLabel(int? id,int State=0,int CState=0)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    try
        //    {
        //        var Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label==true).ToList();
        //        if (Address.Count > 0)
        //        {
        //            ViewBag.WSA = Address.FirstOrDefault().tblPerson.WSANumber;
        //            ViewBag.FName = Address.FirstOrDefault().tblPerson.FirstName;
        //            ViewBag.LName = Address.FirstOrDefault().tblPerson.LastName;
        //            ViewBag.QRCode = Address.FirstOrDefault().tblPerson.QRCode;
        //        }
        //        else
        //        {
        //            ViewBag.WSA = "";
        //            ViewBag.FName = "";
        //            ViewBag.LName = "";
        //        }
        //        ViewBag.State =State ;
        //        ViewBag.CState =CState ;
        //        ViewBag.id = id;
        //         return View(Address);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
        //    return View();

        //}


        //public ActionResult OneRecord(int? id)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    try
        //    {
        //        var Persons = DB.tblPersons.Where(x => x.isActive == true && x.PersonIDNumber == id).FirstOrDefault();
        //        ViewBag.LabelAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
        //        ViewBag.AltAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == false).ToList();
        //        ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
        //        ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Cost).Sum();
        //        ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();

        //        ViewBag.MonthName = "xxx";
        //        ViewBag.CodeMonth = "xx";
        //        ViewBag.CodeDay = "xx";
        //        ViewBag.CodeYear = "xxxx";
        //        DateTime date = new DateTime();
        //        if (Persons.BirthMonth != null)
        //        {
        //            if (Persons.BirthYear != null)
        //            {
        //                date = new DateTime(Persons.BirthYear ?? 0, Persons.BirthMonth ?? 0, 1);
        //                ViewBag.CodeYear = date.ToString("yy");
        //            }
        //            else
        //            {
        //                date = new DateTime(2020, Persons.BirthMonth ?? 0,1);
                        
        //            }


        //            ViewBag.MonthName = date.ToString("MMM");
        //            ViewBag.CodeMonth = date.ToString("MM");
        //        }
        //        else if (Persons.BirthYear != null)
        //        {
        //            date = new DateTime(Persons.BirthYear ?? 0, 1, 1);
        //            ViewBag.CodeYear = date.ToString("yy");
                    
        //        }

        //        if (Persons.BirthDay != null && Persons.BirthDay < 10)
        //        {
        //            ViewBag.CodeDay = "0" + Persons.BirthDay.ToString();
        //        }
        //        else if (Persons.BirthDay != null)
        //        {
        //            ViewBag.CodeDay = Persons.BirthDay.ToString();
        //        }
              

        //        return View(Persons);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
        //    return View();

        //}

        //public ActionResult RoutingSlip(int? id)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    try
        //    {
        //        var Persons = DB.tblPersons.Where(x => x.isActive == true && x.PersonIDNumber == id).FirstOrDefault();
        //        ViewBag.LabelAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
        //        ViewBag.AltAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == false).ToList();
        //        ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
        //        ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Quantity).Sum();
        //        ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();

        //        if(Persons.BirthMonth>12)
        //        {
        //            Persons.BirthMonth = 12;
        //        }
        //        ViewBag.MonthName = "xxx";
        //        ViewBag.CodeMonth = "xx";
        //        ViewBag.CodeDay = "xx";
        //        ViewBag.CodeYear = "xxxx";
        //        DateTime date = new DateTime();
        //        if (Persons.BirthMonth != null)
        //        {
        //            if (Persons.BirthYear != null)
        //            {
        //                date = new DateTime(Persons.BirthYear ?? 0, Persons.BirthMonth ?? 0, 1);
        //                ViewBag.CodeYear = date.ToString("yy");
        //            }
        //            else
        //            {
        //                date = new DateTime(2020, Persons.BirthMonth ?? 0, 1);
                        
        //            }


        //            ViewBag.MonthName = date.ToString("MMM");
        //            ViewBag.CodeMonth = date.ToString("MM");
        //        }
        //        else if (Persons.BirthYear != null)
        //        {
        //            date = new DateTime(Persons.BirthYear ?? 0, 1, 1);
        //            ViewBag.CodeYear = date.ToString("yy");
                 
        //        }

        //        if (Persons.BirthDay!=null&&Persons.BirthDay < 10)
        //        {
        //            ViewBag.CodeDay = "0" + Persons.BirthDay.ToString();
        //        }
        //        else if(Persons.BirthDay != null)
        //        {
        //            ViewBag.CodeDay = Persons.BirthDay.ToString();
        //        }
              


        //        return View(Persons);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
        //    return View();

        //}

        //public ActionResult PassportLabel(string Success,string Update, int? id,int? tid)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    try
        //    {
        //        HttpCookie cookieObj = Request.Cookies["Settings"];
        //        string DateFormat = cookieObj["DateFormat"];
        //        var Persons = DB.tblPersons.Where(x => x.isActive == true && x.PersonIDNumber == id).FirstOrDefault();
        //        ViewBag.TL = DB.tblTransactions.Where(x => x.isActive == true && x.TransactionIDNumber == tid).FirstOrDefault();
        //        ViewBag.Settings = DB.tblPassportLabelSettings.ToList();
        //        ViewBag.Success = Success;
        //        ViewBag.Update = Update;
        //        ViewBag.PersonId = id;
        //        ViewBag.tid = tid;

        //        var data= DB.tblTransactions.Where(x => x.isActive == true && x.TransactionIDNumber == tid).FirstOrDefault();
        //        if(ViewBag.TL.IssueDate!="")
        //        {
        //            ViewBag.Exp = Convert.ToDateTime(ViewBag.TL.IssueDate).AddYears(ViewBag.TL.tblProduct.ValidFor);
        //            ViewBag.ExpAppend = ViewBag.Exp.ToString("yyMMdd");
        //        }
        //        else
        //        {
        //            ViewBag.Exp = null;
        //            ViewBag.ExpAppend = null;
        //        }
        //        string Line1 = null;
        //        string Line2 = null;
        //        int Len;
        //        if (Persons.FirstName.Contains(' '))
        //        {
        //            string[] Arr = Persons.FirstName.Split(' ');
        //            Len = Arr.Length;
        //            Line1 += "P<WSA" + Persons.LastName + "<<"+Arr[0]+"<"+ Arr[1] + "<";
        //        }
        //        else
        //        {
        //            Line1 += "P<WSA" + Persons.LastName + "<<" + Persons.FirstName + "<";
        //        }
        //        while(Line1.Length<44)
        //        {
        //            Line1 += "<";
        //        }
        //        DateTime date = new DateTime();
        //        string CodeYear = "";
        //        ViewBag.MonthName = "xxx";
        //        ViewBag.CodeMonth = "xx";
        //        ViewBag.CodeDay = "xx";
        //        ViewBag.CodeYear = "xxxx";
        //        if (Persons.BirthMonth!=null)
        //        {
        //            if(Persons.BirthYear!=null)
        //            {
        //                date = new DateTime(Persons.BirthYear ?? 0, Persons.BirthMonth ?? 0, 1);
        //                CodeYear = date.ToString("yy");
        //            }
        //            else
        //            {
        //                date = new DateTime(2020, Persons.BirthMonth ?? 0, 1);
        //            }
                    

        //            ViewBag.MonthName=date.ToString("MMM");
        //           ViewBag.CodeMonth = date.ToString("MM");
        //        }
        //        else if(Persons.BirthYear!=null)
        //        {
        //            date = new DateTime(Persons.BirthYear ?? 0, 1, 1);
        //            CodeYear = date.ToString("yy");                  
        //            ViewBag.CodeYear = Persons.BirthYear;
        //        }

        //        if (Persons.BirthDay != null && Persons.BirthDay < 10)
        //        {
        //            ViewBag.CodeDay = "0" + Persons.BirthDay.ToString();
        //        }
        //        else if (Persons.BirthDay != null)
        //        {
        //            ViewBag.CodeDay = Persons.BirthDay.ToString();
        //        }
                


               

        //        Line2 += ViewBag.TL.IDCode + "<<<0WSA" + CodeYear + ViewBag.CodeMonth + ViewBag.CodeDay + "9" + Persons.tblSex.Name + ViewBag.ExpAppend + "7";
        //        while (Line2.Length < 42)
        //        {
        //            Line2 += "<";
        //        }
        //        Line2 += "08";
        //        ViewBag.Line1 = Line1;
        //        ViewBag.Line2 = Line2;
                
        //        //data.tblProduct.tblProductType.Name
        //        //ViewBag.LabelAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
        //        //ViewBag.AltAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == false).ToList();
        //        //ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
        //        //ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Quantity).Sum();
        //        //ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();
        //        return View(Persons);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
        //    return View();

        //}

        //public ActionResult AlphaLabel(int? id, int State = 0, int CState = 0)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    try
        //    {
        //        var Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
        //        if (Address !=null)
        //        {
        //            ViewBag.WSA = Address.tblPerson.WSANumber;
        //            ViewBag.FName = Address.tblPerson.FirstName;
        //            ViewBag.LName = Address.tblPerson.LastName;
        //            ViewBag.QRCode = Address.tblPerson.QRCode;
        //        }
        //        else
        //        {
        //            ViewBag.WSA = "";
        //            ViewBag.FName = "";
        //            ViewBag.LName = "";
        //        }
        //        ViewBag.State = State;
        //        ViewBag.CState = CState;
        //        ViewBag.id = id;
        //        return View(Address);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }
        //    return View();

        //}


        //Upload Files 
        //[HttpPost]
        //public ActionResult UploadImages(int? PersonIDNumber = 0)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    if (Request.Files.Count > 0)
        //    {
        //        try
        //        {


        //            HttpFileCollectionBase files = Request.Files;
        //            for (int i = 0; i < files.Count; i++)
        //            {
        //                HttpPostedFileBase file = files[i];
        //                string fname;
        //                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
        //                {
        //                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
        //                    fname = testfiles[testfiles.Length - 1];
        //                    fname = file.FileName;
        //                }
        //                else
        //                {
        //                    fname = file.FileName;

        //                }


        //                //var FolderPath = Server.MapPath("/TemplateImages/" + PersonIDNumber);

        //                //if (!Directory.Exists(FolderPath))
        //                //{
        //                //    // Try to create the directory.
        //                //    DirectoryInfo di = Directory.CreateDirectory(FolderPath);
        //                //}
        //                //FolderPath = "/TemplateImages/" + PersonIDNumber + "/" + fname + "";

        //                string folder = Server.MapPath(string.Format("~/{0}/", "Uploading"));
        //                if (!Directory.Exists(folder))
        //                {
        //                    Directory.CreateDirectory(folder);
        //                }
        //                string path = null;
        //                path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(file.FileName));
        //                file.SaveAs(path);
        //                path = Path.Combine("\\Uploading", Path.GetFileName(file.FileName));

        //                tblDocumentImg temp = new tblDocumentImg();
        //                temp.PersonIDNumber = PersonIDNumber;
        //                temp.ImgPath = path;
        //                temp.FileName = fname;
        //                temp.isActive = true;
        //                temp.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                temp.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //                DB.tblDocumentImgs.Add(temp);
        //                DB.SaveChanges();

        //                //FolderPath = "/TemplateImages/" + PersonIDNumber + "/";

        //                //fname = Path.Combine(Server.MapPath(FolderPath), fname);
        //                //file.SaveAs(fname);

        //            }
        //            DB.Configuration.ProxyCreationEnabled = false;
        //            List<tblDocumentImg> TemporaryUploadedFiles = new List<tblDocumentImg>();

        //            TemporaryUploadedFiles = DB.tblDocumentImgs.ToList();
        //            return Json(TemporaryUploadedFiles, JsonRequestBehavior.AllowGet);

        //        }
        //        catch (Exception ex)
        //        {
        //            return Json("Error occurred.Error details: " + ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        return Json("1");
        //    }
        //}

        //public ActionResult DeleteImage(int? PersonIDNumber = 0, int? DocumentImgId = 0)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
        //    if (PersonIDNumber > 0)
        //    {
        //        DB.Database.ExecuteSqlCommand("Delete from tblDocumentImg where DocumentImgId=" + DocumentImgId);
        //        //var ProductImage = db.tblTemplatesImages.Where(a => a.ID == ImageId);
        //        //db.tblTemplatesImages.Remove(ProductImage);
        //        DB.SaveChanges();
        //        DB.Configuration.ProxyCreationEnabled = false;
        //        List<tblDocumentImg> ProductUploadedFiles = new List<tblDocumentImg>();

        //        ProductUploadedFiles = DB.tblDocumentImgs.Where(p => p.PersonIDNumber == PersonIDNumber).ToList();
        //        return Json(ProductUploadedFiles, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json("", JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public ActionResult CheckIDCode(string IDCode)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            
        //        try
        //        {
        //            if (DB.tblTransactions.Where(x=>x.IDCode== IDCode).FirstOrDefault()==null)
        //            {
        //                return Json(1);

        //            }
        //            else
        //            {
        //                return Json(0);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return Json("Error occurred.Error details: " + ex.Message);
        //        }
        //}

        //private string GenerateQRCode(string qrcodeText, int Name)
        //{
        //    string folderPath = "~/Uploading/QRCode/";
        //    string imagePath = "/Uploading/QRCode/" + Name + ".jpg";
        //    // If the directory doesn't exist then create it.
        //    if (!Directory.Exists(Server.MapPath(folderPath)))
        //    {
        //        Directory.CreateDirectory(Server.MapPath(folderPath));
        //    }
        //    bool exists1 = (System.IO.File.Exists(Server.MapPath(imagePath)));
        //    if (!exists1)
        //    {
        //        System.IO.File.Delete(Server.MapPath(imagePath));

        //    }
        //    var barcodeWriter = new BarcodeWriter();
        //    barcodeWriter.Format = BarcodeFormat.QR_CODE;
        //    var result = barcodeWriter.Write(qrcodeText);

        //    string barcodePath = Server.MapPath(imagePath);
        //    var barcodeBitmap = new Bitmap(result);
        //    using (MemoryStream memory = new MemoryStream())
        //    {
        //        using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
        //        {
        //            barcodeBitmap.Save(memory, ImageFormat.Jpeg);
        //            byte[] bytes = memory.ToArray();
        //            fs.Write(bytes, 0, bytes.Length);
        //        }
        //    }
        //    return imagePath;
        //}

        
        //[HttpPost]
        //public ActionResult CreatePassportLabelSetting(tblPassportLabelSetting PassportLabelSetting, int? id, int? tid)
        //{
        //    WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

        //    tblPassportLabelSetting Data = new tblPassportLabelSetting();
        //    try
        //    {
                
        //        ViewBag.User = Session["User"];
        //        if (PassportLabelSetting.PassportLabelSettingId== 0)
        //        {
        //            Data = PassportLabelSetting;


        //            Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //            Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //            Data.CreatedBy = ViewBag.User.UserId;
        //            Data.EditBy = ViewBag.User.UserId;
        //            DB.tblPassportLabelSettings.Add(Data);
        //            DB.SaveChanges();


        //            return RedirectToAction("PassportLabel", new { Success = "Settings has been add successfully.", id = id, tid = tid });

        //        }
        //        else
        //        {

        //            //Data = DB.tblPassportLabelSettings.Select(r => r).Where(x => x.PassportLabelSettingId == PassportLabelSetting.PassportLabelSettingId).FirstOrDefault();
        //            //Data = PassportLabelSetting;
        //            //Data.PersonIDNumber = Transaction.PersonIDNumber;
        //            //Data.ProductIDNumber = Transaction.ProductIDNumber;
        //            //Data.IDCode = Transaction.IDCode;
        //            //Data.Cost = Transaction.Cost;
        //            //Data.Quantity = Transaction.Quantity;
        //            //Data.Problems = Transaction.Problems;
        //            //Data.IssueDate = Transaction.IssueDate;
        //            //Data.SentDate = Transaction.SentDate;
        //            //Data.ReturnDate = Transaction.ReturnDate;

        //            PassportLabelSetting.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        //            PassportLabelSetting.EditBy = ViewBag.User.UserId;

        //            DB.Entry(PassportLabelSetting).State = EntityState.Modified; ;
        //            DB.SaveChanges();
        //            return RedirectToAction("PassportLabel", new { Update = "Settings has been Update successfully.", id = id, tid = tid });


        //        }


        //    }
        //    catch (Exception ex)
        //    {

        //        ViewBag.Error = ex.Message;
        //        Console.WriteLine("Error" + ex.Message);
        //    }

        //    return RedirectToAction("PassportLabel", new {  id = id, tid = tid });
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}