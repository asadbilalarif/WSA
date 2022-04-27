using ClosedXML.Excel;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;
using ZXing;

namespace WorldServiceOrganization.Controllers
{
    [NoDirectAccess]
    [AuthorizeAction1FilterAttribute]
    [Authorize]
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Persons(string Success, string Update, string Delete, string RecordType)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            List<tblPerson> PersonList = new List<tblPerson>();
            if (RecordType == "Information Only")
            {

                PersonList = DB.tblPersons.Where(x => x.isActive == true && x.WSANumber == 0).ToList();
            }
            else if (RecordType == "WSA Only")
            {
                PersonList = DB.tblPersons.Where(x => x.isActive == true && x.WSANumber != 0).ToList();
            }
            else
            {
                PersonList = DB.tblPersons.Where(x => x.isActive == true).ToList();
            }
            ViewBag.RecordType = RecordType;
            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;
            return View(PersonList);
        }

        public ActionResult CreatePerson(int? id, string Success, string Update, string Delete, int tab = 0)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Person = new tblPerson();
            ViewBag.Country = DB.tblCountries.Where(x => x.isActive == true).ToList();
            ViewBag.Eye = DB.tblEyes.Where(x => x.isActive == true).ToList();
            ViewBag.Occupation = DB.tblOccupations.Where(x => x.isActive == true).ToList();
            ViewBag.Sex = DB.tblSex.Where(x => x.isActive == true).ToList();
            ViewBag.Status = DB.tblStatus.Where(x => x.isActive == true).ToList();
            ViewBag.tab = tab;
            int CurrenYear = DateTime.Now.Year;
            List<int> Years = new List<int>();
            for (int i = 1930; i <= CurrenYear; i++)
            {
                Years.Add(i);
            }
            ViewBag.Year = Years;
            ViewBag.WSA = DB.tblSettings.Select(s => s.NextWSA).FirstOrDefault();

            if (id != null && id != 0)
            {
                ViewBag.Child = DB.tblChilds.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

                ViewBag.Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

                ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
                ViewBag.DocImg = DB.tblDocumentImgs.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

                ViewBag.Success = Success;
                ViewBag.Update = Update;
                ViewBag.Delete = Delete;
                ViewBag.Product = DB.tblProducts.Where(x => x.isActive == true).ToList();
                ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Cost).Sum();
                ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();

                ViewBag.TransCount = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();
                Person = DB.tblPersons.Where(x => x.PersonIDNumber == id).FirstOrDefault();
                if (DB.tblPersons.Max(s => s.WSANumber) != null)
                {
                    ViewBag.WAS = DB.tblPersons.Max(s => s.WSANumber) + 1;
                }
                return View(Person);
            }
            else
            {
                ViewBag.WAS = null;
                Person.PersonIDNumber = 0;
                if (DB.tblPersons.Max(s => s.WSANumber) != null)
                {
                    ViewBag.WAS = DB.tblPersons.Max(s => s.WSANumber) + 1;
                }

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
                HttpCookie cookieObj = Request.Cookies["Settings"];
                string DateFormat = cookieObj["DateFormat"];
                //string[] DateSplit = Person.DateOfBirth.Split('-');
                //string[] FormatCheck = DateFormat.Split('-');
                ViewBag.User = Session["User"];




                if (Person.PersonIDNumber == 0)
                {
                    //if (DB.tblPersons.Select(r => r).Where(x => x.EMail==Person.EMail).FirstOrDefault() == null)
                    //{
                    Data = Person;

                    //if (FormatCheck[0] == "yyyy")
                    //{
                    //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
                    //    {
                    //        Data.BirthYear = Convert.ToInt32(DateSplit[0]);
                    //    }

                    //}
                    //else if (FormatCheck[1] == "yyyy")
                    //{
                    //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
                    //    {
                    //        Data.BirthYear = Convert.ToInt32(DateSplit[1]);
                    //    }
                    //}
                    //else
                    //{
                    //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
                    //    {
                    //        Data.BirthYear = Convert.ToInt32(DateSplit[2]);
                    //    }
                    //}
                    //if (FormatCheck[0] == "MM")
                    //{
                    //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
                    //    {
                    //        Data.BirthMonth = Convert.ToInt32(DateSplit[0]);
                    //    }
                    //}
                    //else if (FormatCheck[1] == "MM")
                    //{
                    //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
                    //    {
                    //        Data.BirthMonth = Convert.ToInt32(DateSplit[1]);
                    //    }
                    //}
                    //else
                    //{
                    //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
                    //    {
                    //        Data.BirthMonth = Convert.ToInt32(DateSplit[2]);
                    //    }
                    //}
                    //if (FormatCheck[0] == "dd")
                    //{
                    //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
                    //    {
                    //        Data.BirthDay = Convert.ToInt32(DateSplit[0]);
                    //    }
                    //}
                    //else if (FormatCheck[1] == "dd")
                    //{
                    //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
                    //    {
                    //        Data.BirthDay = Convert.ToInt32(DateSplit[1]);
                    //    }

                    //}
                    //else
                    //{
                    //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
                    //    {
                    //        Data.BirthDay = Convert.ToInt32(DateSplit[2]);
                    //    }
                    //}


                    Data.OccupationId = Person.OccupationCode;
                    string folder = Server.MapPath(string.Format("~/{0}/", "Uploading"));
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string path = null;
                    if (Image != null)
                    {
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(Image.FileName));
                        Image.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(Image.FileName));
                        Data.Photo = path;
                    }
                    else
                    {
                        Data.Photo = "\\Uploading\\user-image.png";
                    }
                    if (SigImage != null)
                    {
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(SigImage.FileName));
                        SigImage.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(SigImage.FileName)); Data.SignaturePath = path;
                        Data.SignaturePath = path;
                    }
                    else
                    {
                        Data.SignaturePath = "\\Uploading\\sig.png";
                    }
                    if (CertificationFile != null)
                    {
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(CertificationFile.FileName));
                        CertificationFile.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(CertificationFile.FileName));
                        Data.Certification = path;
                    }
                    else
                    {
                        Data.Certification = "\\Uploading\\file.png";
                    }





                    Data.EntryDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.LastModifiedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.CreatedBy = ViewBag.User.UserId;
                    Data.LastEditedBy = ViewBag.User.UserId;
                    Data.isActive = true;
                    int? WSANum = 0;
                    if (Person.WSANumber != null)
                    {
                        var nextWSA = DB.tblPersons.Max(s => s.WSANumber);
                        if (nextWSA != null)
                        {
                            Person.WSANumber = DB.tblPersons.Max(s => s.WSANumber) + 1;
                            WSANum = DB.tblPersons.Max(s => s.WSANumber) + 2;
                        }
                        else
                        {
                            Person.WSANumber = Person.WSANumber;
                            WSANum = Person.WSANumber + 1;
                        }

                        var Data1 = DB.tblSettings.FirstOrDefault();
                        Data1.NextWSA = WSANum.ToString();
                        DB.Entry(Data1);
                        DB.SaveChanges();
                    }
                    DB.tblPersons.Add(Data);
                    DB.SaveChanges();
                    var ID = Data.PersonIDNumber;
                    Data = DB.tblPersons.Where(x => x.PersonIDNumber == ID).FirstOrDefault();
                    string vCardText = "BEGIN:VCARD\r\nN:";
                    vCardText += "" + Person.FirstName + " " + Person.LastName + "\r\n";
                    //vCardText += "TITLE:" + Data.tblOccupation.Name + "\r\n";
                    vCardText += "TEL:" + Person.Phone + "\r\n";
                    vCardText += "END:VCARD";
                    string QRCodeImagePath = GenerateQRCode(vCardText, ID);

                    Data.QRCode = QRCodeImagePath;
                    DB.Entry(Data);
                    DB.SaveChanges();



                    return RedirectToAction("Persons", new { Success = "Person has been add successfully." });
                    //}
                    //else
                    //{
                    //    ViewBag.Error = "Person Already Exsist!!!";
                    //}
                }
                else
                {
                    var check = DB.tblPersons.Select(r => r).Where(x => x.EMail == Person.EMail).FirstOrDefault();
                    //if (check == null || check.PersonIDNumber == Person.PersonIDNumber)
                    //{
                    Data = DB.tblPersons.Select(r => r).Where(x => x.PersonIDNumber == Person.PersonIDNumber).FirstOrDefault();
                    bool SCheck = false;
                    if (Data.Status == Person.Status)
                    {
                        SCheck = true;
                    }
                    //if (FormatCheck[0] == "yyyy")
                    //{
                    //    if(DateSplit[0] != "xx" && DateSplit[0] != "xxx")
                    //    {
                    //        Data.BirthYear = Convert.ToInt32(DateSplit[0]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthYear = null;
                    //    }

                    //}
                    //else if (FormatCheck[1] == "yyyy")
                    //{
                    //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
                    //    {
                    //        Data.BirthYear = Convert.ToInt32(DateSplit[1]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthYear = null;
                    //    }
                    //}
                    //else
                    //{
                    //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
                    //    {
                    //        Data.BirthYear = Convert.ToInt32(DateSplit[2]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthYear = null;
                    //    }
                    //}
                    //if (FormatCheck[0] == "MM")
                    //{
                    //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
                    //    {
                    //        Data.BirthMonth = Convert.ToInt32(DateSplit[0]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthMonth = null;
                    //    }
                    //}
                    //else if (FormatCheck[1] == "MM")
                    //{
                    //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
                    //    {
                    //        Data.BirthMonth = Convert.ToInt32(DateSplit[1]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthMonth = null;
                    //    }
                    //}
                    //else
                    //{
                    //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
                    //    {
                    //        Data.BirthMonth = Convert.ToInt32(DateSplit[2]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthMonth = null;
                    //    }
                    //}
                    //if (FormatCheck[0] == "dd")
                    //{
                    //    if (DateSplit[0] != "xx" && DateSplit[0] != "xxx")
                    //    {
                    //        Data.BirthDay = Convert.ToInt32(DateSplit[0]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthDay = null;
                    //    }
                    //}
                    //else if (FormatCheck[1] == "dd")
                    //{
                    //    if (DateSplit[1] != "xx" && DateSplit[1] != "xxx")
                    //    {
                    //        Data.BirthDay = Convert.ToInt32(DateSplit[1]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthDay = null;
                    //    }

                    //}
                    //else
                    //{
                    //    if (DateSplit[2] != "xx" && DateSplit[2] != "xxx")
                    //    {
                    //        Data.BirthDay = Convert.ToInt32(DateSplit[2]);
                    //    }
                    //    else
                    //    {
                    //        Data.BirthDay = null;
                    //    }
                    //}
                    Data.FirstName = Person.FirstName;
                    Data.LastName = Person.LastName;
                    Data.CityOfBirth = Person.CityOfBirth;
                    Data.Phone = Person.Phone;
                    Data.Fax = Person.Fax;
                    Data.EMail = Person.EMail;
                    Data.Website = Person.Website;
                    //Data.DateOfBirth= Person.DateOfBirth;
                    Data.Marks = Person.Marks;
                    Data.FatherName = Person.FatherName;
                    Data.MotherName = Person.MotherName;
                    Data.WSANumber = Person.WSANumber;
                    Data.Comments = Person.Comments;
                    Data.Title = Person.Title;
                    Data.Height = Person.Height;
                    Data.HeightUnit = Person.HeightUnit;
                    Data.CountryOfApplication = Person.CountryOfApplication;
                    Data.CountryOfBirth = Person.CountryOfBirth;
                    Data.CountryOfBirthStatistical = Person.CountryOfBirthStatistical;
                    Data.Sex = Person.Sex;
                    Data.Status = Person.Status;
                    Data.Eyes = Person.Eyes;
                    Data.OccupationCode = Person.OccupationCode;
                    Data.OccupationId = Person.OccupationCode;
                    Data.TransactionCount = Person.TransactionCount;
                    Data.BirthDay = Person.BirthDay;
                    Data.BirthMonth = Person.BirthMonth;
                    Data.BirthYear = Person.BirthYear;


                    string path = null;
                    if (SigImage != null)
                    {
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(SigImage.FileName));

                        SigImage.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(SigImage.FileName));

                        Data.SignaturePath = path;
                    }
                    else
                    {
                        Data.SignaturePath = Person.SignaturePath;
                    }

                    if (Image != null)
                    {
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(Image.FileName));

                        Image.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(Image.FileName));

                        Data.Photo = path;
                    }
                    else
                    {
                        Data.Photo = Person.Photo;
                    }

                    if (CertificationFile != null)
                    {
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(CertificationFile.FileName));
                        CertificationFile.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(CertificationFile.FileName));
                        Data.Certification = path;
                    }
                    else
                    {
                        Data.Certification = Person.Certification;
                    }

                    int? WSANum = 0;
                    if (SCheck == false && Person.WSANumber != null)
                    {
                        var nextWSA = DB.tblPersons.Max(s => s.WSANumber);
                        if (nextWSA != null)
                        {
                            Person.WSANumber = DB.tblPersons.Max(s => s.WSANumber) + 1;
                            WSANum = DB.tblPersons.Max(s => s.WSANumber) + 2;
                        }
                        else
                        {
                            Person.WSANumber = Person.WSANumber;
                            WSANum = Person.WSANumber + 1;
                        }



                        var Data1 = DB.tblSettings.FirstOrDefault();
                        Data1.NextWSA = WSANum.ToString();
                        DB.Entry(Data1);
                        DB.SaveChanges();
                    }

                    Data.LastModifiedDate = DateTime.Now;
                    Data.LastEditedBy = ViewBag.User.UserId;
                    DB.Entry(Data);
                    DB.SaveChanges();
                    Data = DB.tblPersons.Where(x => x.PersonIDNumber == Person.PersonIDNumber).FirstOrDefault();
                    string vCardText = "BEGIN:VCARD\r\nN:";
                    vCardText += "" + Person.FirstName + " " + Person.LastName + "\r\n";
                    //vCardText += "TITLE:" + Data.tblOccupation.Name + "\r\n";
                    vCardText += "TEL:" + Person.Phone + "\r\n";
                    vCardText += "END:VCARD";
                    string QRCodeImagePath = GenerateQRCode(vCardText, Person.PersonIDNumber);
                    Data.QRCode = QRCodeImagePath;
                    DB.Entry(Data);
                    DB.SaveChanges();

                    return RedirectToAction("Persons", new { Update = "Person has been Update successfully." });
                    //}
                    //else
                    //{
                    //    ViewBag.Error = "Person Already Exsist!!!";
                    //}

                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return View(Person);
        }

        private string GenerateQRCode(string qrcodeText, int Name)
        {
            string folderPath = "~/Uploading/QRCode/";
            string imagePath = "/Uploading/QRCode/" + Name + ".jpg";
            // If the directory doesn't exist then create it.
            if (!Directory.Exists(Server.MapPath(folderPath)))
            {
                Directory.CreateDirectory(Server.MapPath(folderPath));
            }
            bool exists1 = (System.IO.File.Exists(Server.MapPath(imagePath)));
            if (!exists1)
            {
                System.IO.File.Delete(Server.MapPath(imagePath));

            }
            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var result = barcodeWriter.Write(qrcodeText);

            string barcodePath = Server.MapPath(imagePath);
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return imagePath;
        }

        [HttpPost]
        public ActionResult DeletePerson(int PersonId)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblPerson Data = new tblPerson();
            List<tblAddress> Data1 = new List<tblAddress>();
            List<tblTransaction> Data2 = new List<tblTransaction>();
            List<tblChild> Data3 = new List<tblChild>();
            List<tblDocumentImg> Data4 = new List<tblDocumentImg>();
            try
            {
                Data1 = DB.tblAddresses.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
                if (Data1.Count() > 0)
                {
                    DB.tblAddresses.RemoveRange(Data1);
                    DB.SaveChanges();
                }

                Data2 = DB.tblTransactions.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
                if (Data2.Count() > 0)
                {
                    DB.tblTransactions.RemoveRange(Data2);
                    DB.SaveChanges();
                }
                Data3 = DB.tblChilds.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
                if (Data3.Count() > 0)
                {
                    DB.tblChilds.RemoveRange(Data3);
                    DB.SaveChanges();
                }
                Data4 = DB.tblDocumentImgs.Select(r => r).Where(x => x.PersonIDNumber == PersonId).ToList();
                if (Data4.Count() > 0)
                {
                    DB.tblDocumentImgs.RemoveRange(Data4);
                    DB.SaveChanges();
                }

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
            ViewBag.Child = DB.tblChilds.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();

            ViewBag.Success = Success;
            ViewBag.Update = Update;
            ViewBag.Delete = Delete;

            ViewBag.Sex = DB.tblSex.Where(x => x.isActive == true).ToList();
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
                    if (DB.tblChilds.Select(r => r).Where(x => x.Name == Child.Name && x.PersonIDNumber == Child.PersonIDNumber).FirstOrDefault() == null)
                    {
                        Data = Child;
                        if (Data.BirthDate == null)
                        {
                            Data.BirthDate = new DateTime(1000, 01, 01).ToString();
                        }

                        Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        Data.isActive = true;
                        DB.tblChilds.Add(Data);
                        DB.SaveChanges();
                        return RedirectToAction("CreatePerson", new { Success = "Child has been add successfully.", id = Child.PersonIDNumber, tab = 3 });
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
                        //Data.BirthDate = Child.BirthDate;
                        Data.BirthDay = Child.BirthDay;
                        Data.BirthMonth = Child.BirthMonth;
                        Data.BirthYear = Child.BirthYear;
                        Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        DB.Entry(Data);
                        DB.SaveChanges();
                        return RedirectToAction("CreatePerson", new { Update = "Child has been Update successfully.", id = Data.PersonIDNumber, tab = 3 });
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

                    Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.isActive = true;
                    DB.tblAddresses.Add(Data);
                    DB.SaveChanges();
                    return RedirectToAction("CreatePerson", new { Success = "Address has been add successfully.", id = Address.PersonIDNumber, tab = 2 });

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
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    DB.Entry(Data);
                    DB.SaveChanges();
                    return RedirectToAction("CreatePerson", new { Update = "Address has been Update successfully.", id = Address.PersonIDNumber, tab = 2 });


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

                ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Cost).Sum();
                ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();
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
                string PassportNum = "";
                ViewBag.User = Session["User"];
                if (Transaction.TransactionIDNumber == 0)
                {
                    Data = Transaction;
                    //Data.ApplicationDate =Convert.ToDateTime(Transaction.ApplicationDate);
                    //Data.IssueDate = Convert.ToDateTime(Transaction.IssueDate);
                    //Data.SentDate = Convert.ToDateTime(Transaction.SentDate);
                    //Data.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate);
                    //if (Transaction.IssueDate.Year == 0001)
                    //{
                    //    Transaction.IssueDate = Convert.ToDateTime(Transaction.IssueDate.ToString("yyyy-MM-dd"));
                    //    if (Transaction.IssueDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.IssueDate.ToString() == "01/01/0001 12:00:00 AM")
                    //    {
                    //        Data.IssueDate = new DateTime(9999, 01, 01);
                    //    }
                    //}
                    //if (Transaction.SentDate.Year == 0001)
                    //{
                    //    Transaction.SentDate = Convert.ToDateTime(Transaction.SentDate.ToString("yyyy-MM-dd"));
                    //    if (Transaction.SentDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.SentDate.ToString() == "01/01/0001 12:00:00 AM")
                    //    {
                    //        Data.SentDate = new DateTime(9999, 01, 01);

                    //    }
                    //}
                    //if (Transaction.ReturnDate.Year == 0001)
                    //{
                    //    Transaction.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate.ToString("yyyy-MM-dd"));
                    //    if (Transaction.ReturnDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.ReturnDate.ToString() == "01/01/0001 12:00:00 AM")
                    //    {
                    //        Data.ReturnDate = new DateTime(9999, 01, 01);

                    //    }
                    //}

                    Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.CreatedBy = ViewBag.User.UserId;
                    Data.EditBy = ViewBag.User.UserId;
                    Data.isActive = true;
                    PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
                    var ID = DB.tblProducts.Where(x => x.ProductId == Transaction.ProductIDNumber).Select(s => s.ProductTypeId).FirstOrDefault();
                    if (ID == 1 && PassportNum != null)
                    {
                        //PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
                        PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
                        Data.IDCode = PassportNum;

                        PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
                        var Data1 = DB.tblSettings.FirstOrDefault();
                        Data1.NextPassport = PassportNum.ToString();
                        DB.Entry(Data1);
                        DB.SaveChanges();
                    }
                    else if (ID == 1 && PassportNum == null)
                    {

                        PassportNum = (Int32.Parse(Data.IDCode) + 1).ToString();
                        var Data1 = DB.tblSettings.FirstOrDefault();
                        Data1.NextPassport = PassportNum.ToString();
                        DB.Entry(Data1);
                        DB.SaveChanges();
                    }
                    DB.tblTransactions.Add(Data);
                    DB.SaveChanges();


                    return RedirectToAction("CreatePerson", new { Success = "Transaction has been add successfully.", id = Transaction.PersonIDNumber, tab = 1 });

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
                    Data.IssueDate = Transaction.IssueDate;
                    Data.SentDate = Transaction.SentDate;
                    Data.ReturnDate = Transaction.ReturnDate;
                    //if (Transaction.IssueDate.Year == 0001)
                    //{
                    //    Transaction.IssueDate = Convert.ToDateTime(Transaction.IssueDate.ToString("yyyy-MM-dd"));
                    //    if (Transaction.IssueDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.IssueDate.ToString() == "01/01/0001 12:00:00 AM")
                    //    {
                    //        Data.IssueDate = new DateTime(9999, 01, 01);
                    //    }
                    //}
                    //else
                    //{
                    //    Data.IssueDate = Convert.ToDateTime(Transaction.IssueDate);
                    //}
                    //if (Transaction.SentDate.Year == 0001)
                    //{
                    //    Transaction.SentDate = Convert.ToDateTime(Transaction.SentDate.ToString("yyyy-MM-dd"));
                    //    if (Transaction.SentDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.SentDate.ToString() == "01/01/0001 12:00:00 AM")
                    //    {
                    //        Data.SentDate = new DateTime(9999, 01, 01);

                    //    }
                    //}
                    //else
                    //{
                    //    Data.SentDate = Convert.ToDateTime(Transaction.SentDate);
                    //}
                    //if (Transaction.ReturnDate.Year == 0001)
                    //{
                    //    Transaction.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate.ToString("yyyy-MM-dd"));
                    //    if (Transaction.ReturnDate.ToString() == "01-Jan-01 12:00:00 AM" || Transaction.ReturnDate.ToString() == "01/01/0001 12:00:00 AM")
                    //    {
                    //        Data.ReturnDate = new DateTime(9999, 01, 01);

                    //    }
                    //}
                    //else
                    //{
                    //    Data.ReturnDate = Convert.ToDateTime(Transaction.ReturnDate);
                    //}
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.EditBy = ViewBag.User.UserId;


                    PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
                    var ID = DB.tblProducts.Where(x => x.ProductId == Transaction.ProductIDNumber).Select(s => s.ProductTypeId).FirstOrDefault();
                    if (ID == 1 && PassportNum != null)
                    {
                        //PassportNum = DB.tblTransactions.Where(x => x.tblProduct.tblProductType.ProductTypeId == 1).OrderByDescending(o => o.IDCode).Select(s => s.IDCode).FirstOrDefault();
                        PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
                        Data.IDCode = PassportNum;

                        PassportNum = (Int32.Parse(PassportNum) + 1).ToString();
                        var Data1 = DB.tblSettings.FirstOrDefault();
                        Data1.NextPassport = PassportNum.ToString();
                        DB.Entry(Data1);
                        DB.SaveChanges();
                    }
                    else if (ID == 1 && PassportNum == null)
                    {

                        PassportNum = (Int32.Parse(Data.IDCode) + 1).ToString();
                        var Data1 = DB.tblSettings.FirstOrDefault();
                        Data1.NextPassport = PassportNum.ToString();
                        DB.Entry(Data1);
                        DB.SaveChanges();
                    }


                    DB.Entry(Data);
                    DB.SaveChanges();
                    return RedirectToAction("CreatePerson", new { Update = "Transaction has been Update successfully.", id = Transaction.PersonIDNumber, tab = 1 });


                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("CreatePerson");
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
        public ActionResult CheckIDCode(string IDCode)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            try
            {
                if (DB.tblTransactions.Where(x => x.IDCode == IDCode).FirstOrDefault() == null)
                {
                    return Json(1);

                }
                else
                {
                    return Json(0);
                }
            }
            catch (Exception ex)
            {
                return Json("Error occurred.Error details: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult UploadImages(int? PersonIDNumber = 0)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            if (Request.Files.Count > 0)
            {
                try
                {


                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                            fname = file.FileName;
                        }
                        else
                        {
                            fname = file.FileName;

                        }


                        //var FolderPath = Server.MapPath("/TemplateImages/" + PersonIDNumber);

                        //if (!Directory.Exists(FolderPath))
                        //{
                        //    // Try to create the directory.
                        //    DirectoryInfo di = Directory.CreateDirectory(FolderPath);
                        //}
                        //FolderPath = "/TemplateImages/" + PersonIDNumber + "/" + fname + "";

                        string folder = Server.MapPath(string.Format("~/{0}/", "Uploading"));
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        string path = null;
                        path = Path.Combine(Server.MapPath("~/Uploading"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = Path.Combine("\\Uploading", Path.GetFileName(file.FileName));

                        tblDocumentImg temp = new tblDocumentImg();
                        temp.PersonIDNumber = PersonIDNumber;
                        temp.ImgPath = path;
                        temp.FileName = fname;
                        temp.isActive = true;
                        temp.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        temp.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        DB.tblDocumentImgs.Add(temp);
                        DB.SaveChanges();

                        //FolderPath = "/TemplateImages/" + PersonIDNumber + "/";

                        //fname = Path.Combine(Server.MapPath(FolderPath), fname);
                        //file.SaveAs(fname);

                    }
                    DB.Configuration.ProxyCreationEnabled = false;
                    List<tblDocumentImg> TemporaryUploadedFiles = new List<tblDocumentImg>();

                    TemporaryUploadedFiles = DB.tblDocumentImgs.ToList();
                    return Json(TemporaryUploadedFiles, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json("Error occurred.Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("1");
            }
        }

        public ActionResult DeleteImage(int? PersonIDNumber = 0, int? DocumentImgId = 0)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            if (PersonIDNumber > 0)
            {
                DB.Database.ExecuteSqlCommand("Delete from tblDocumentImg where DocumentImgId=" + DocumentImgId);
                //var ProductImage = db.tblTemplatesImages.Where(a => a.ID == ImageId);
                //db.tblTemplatesImages.Remove(ProductImage);
                DB.SaveChanges();
                DB.Configuration.ProxyCreationEnabled = false;
                List<tblDocumentImg> ProductUploadedFiles = new List<tblDocumentImg>();

                ProductUploadedFiles = DB.tblDocumentImgs.Where(p => p.PersonIDNumber == PersonIDNumber).ToList();
                return Json(ProductUploadedFiles, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProduct(int id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            ////Searching records from list using LINQ query  
            string IdCode = "";
            var ProductList = DB.tblProducts.Where(q => q.ProductId == id).Select(s => s.Price).FirstOrDefault();
            var Product = DB.tblProducts.Where(q => q.ProductId == id).FirstOrDefault();
            if (Product.tblProductType.ProductTypeId == 1)
            {
                IdCode = DB.tblSettings.Select(x => x.NextPassport).FirstOrDefault();
            }
            return Json(new { ProductList = ProductList, IdCode = IdCode }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddressLabel(int? id, int State = 0, int CState = 0)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            try
            {
                var Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).ToList();
                if (Address.Count > 0)
                {
                    ViewBag.WSA = Address.FirstOrDefault().tblPerson.WSANumber;
                    ViewBag.FName = Address.FirstOrDefault().tblPerson.FirstName;
                    ViewBag.LName = Address.FirstOrDefault().tblPerson.LastName;
                    ViewBag.QRCode = Address.FirstOrDefault().tblPerson.QRCode;
                }
                else
                {
                    ViewBag.WSA = "";
                    ViewBag.FName = "";
                    ViewBag.LName = "";
                }
                ViewBag.State = State;
                ViewBag.CState = CState;
                ViewBag.id = id;
                return View(Address);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();

        }


        public ActionResult ExportToExcel()
        {
            //Instantiate the spreadsheet creation engine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Instantiate the Excel application object
                IApplication application = excelEngine.Excel;

                //Create a new workbook and add a worksheet
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Add the header text and assign cell style
                worksheet["A3"].Text = "LastName";
                worksheet["B3"].Text = "FirstName";
                worksheet["C3"].Text = "City Of Birth";
                worksheet["D3"].Text = "Photograph";
                worksheet["E3"].Text = "Phone";
                worksheet["F3"].Text = "Fax";
                worksheet["G3"].Text = "Signature";
                worksheet["H3"].Text = "Height";
                worksheet["I3"].Text = "Marks";
                worksheet["J3"].Text = "Title";
                worksheet["K3"].Text = "Father Name";
                worksheet["L3"].Text = "Mother Name";
                worksheet["M3"].Text = "WSANumber";
                worksheet["N3"].Text = "Comments";
                worksheet["O3"].Text = "EMail";
                worksheet["P3"].Text = "Website";
                worksheet["Q3"].Text = "Eye";
                worksheet["R3"].Text = "Country Of Application";
                worksheet["S3"].Text = "Country Of Birth";
                worksheet["T3"].Text = "Country Of Birth Statistical";
                worksheet["U3"].Text = "Occupation";
                worksheet["V3"].Text = "Sex";
                worksheet["W3"].Text = "Status";
                worksheet["X3"].Text = "Birth Month";
                worksheet["Y3"].Text = "Birth Day";
                worksheet["Z3"].Text = "Birth Year";
                worksheet["A3:Z3"].CellStyle.Font.Bold = true;

                worksheet["A4"].Text = "%PersonExportData_Result.LastName";
                worksheet["B4"].Text = "%PersonExportData_Result.FirstName";
                worksheet["C4"].Text = "%PersonExportData_Result.CityOfBirth";
                worksheet["D4"].Text = "%PersonExportData_Result.Photograph";
                worksheet["E4"].Text = "%PersonExportData_Result.Phone";
                worksheet["F4"].Text = "%PersonExportData_Result.Fax";
                worksheet["G4"].Text = "%PersonExportData_Result.Signature";
                worksheet["H4"].Text = "%PersonExportData_Result.Height";
                worksheet["I4"].Text = "%PersonExportData_Result.Marks";
                worksheet["J4"].Text = "%PersonExportData_Result.Title";
                worksheet["K4"].Text = "%PersonExportData_Result.FatherName";
                worksheet["L4"].Text = "%PersonExportData_Result.MotherName";
                worksheet["M4"].Text = "%PersonExportData_Result.WSANumber";
                worksheet["N4"].Text = "%PersonExportData_Result.Comments";
                worksheet["O4"].Text = "%PersonExportData_Result.EMail";
                worksheet["P4"].Text = "%PersonExportData_Result.Website";
                worksheet["Q4"].Text = "%PersonExportData_Result.EyeName";
                worksheet["R4"].Text = "%PersonExportData_Result.CountryOfApplicationName";
                worksheet["S4"].Text = "%PersonExportData_Result.CountryOfBirthName";
                worksheet["T4"].Text = "%PersonExportData_Result.CountryOfBirthStatisticalName";
                worksheet["U4"].Text = "%PersonExportData_Result.OccupationName";
                worksheet["V4"].Text = "%PersonExportData_Result.SexName";
                worksheet["W4"].Text = "%PersonExportData_Result.StatusName";
                worksheet["X4"].Text = "%PersonExportData_Result.BirthMonth";
                worksheet["Y4"].Text = "%PersonExportData_Result.BirthDay";
                worksheet["Z4"].Text = "%PersonExportData_Result.BirthYear";

                //Create template marker processor
                ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();

                WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
                

                List<PersonExportData_Result> Data = DB.PersonExportData().ToList();

                foreach (var item in Data)
                {
                    byte[] image1 = System.IO.File.ReadAllBytes(Server.MapPath(item.Photo));
                    byte[] image2 = System.IO.File.ReadAllBytes(Server.MapPath(item.SignaturePath));
                    item.Photograph = image1;
                    item.Signature = image2;
                }

                //Add marker variable
                marker.AddVariable("PersonExportData_Result", Data);

                //Apply markers
                marker.ApplyMarkers();

                //Autofit the columns
                worksheet["B1:D10"].AutofitColumns();

                //Save the workbook
                workbook.SaveAs("Output.xlsx");

                System.Diagnostics.Process.Start("Output.xlsx");
            }

            return RedirectToAction("Persons");
        }

        //private static List<tblPerson> GetEmployeeDetails()
        //{
        //    //Get the images from folder
        //        byte[] image1 = System.IO.File.ReadAllBytes(@"E:\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\Data\Man2.png");
        //    byte[] image2 = System.IO.File.ReadAllBytes(@"E:\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\Data\Man2.png");
        //    byte[] image3 = System.IO.File.ReadAllBytes(@"E:\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\Data\Woman1.jpg");
        //    byte[] image4 = System.IO.File.ReadAllBytes(@"E:\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\ExportDataTableToExcelInMVC4\Data\Woman1.jpg");

        //    //Instantiate employee list
        //    List<tblPerson> employeeList = new List<tblPerson>();

        //    //Set the details of employee and into employee list
        //    tblPerson emp = new tblPerson();
        //    emp.Image = image1;
        //    emp.Name = "Andy Bernardsss";
        //    emp.Id = 1011;
        //    emp.Age = 35;
        //    employeeList.Add(emp);

        //    //Set the details of employee and into employee list
        //    emp = new Employee();
        //    emp.Image = image2;
        //    emp.Name = "Karen Fillippelli";
        //    emp.Id = 1012;
        //    emp.Age = 26;
        //    employeeList.Add(emp);

        //    //Set the details of employee and into employee list
        //    emp = new Employee();
        //    emp.Image = image3;
        //    emp.Name = "Patricia Mckenna";
        //    emp.Id = 1013;
        //    emp.Age = 28;
        //    employeeList.Add(emp);

        //    //Set the details of employee and into employee list
        //    emp = new Employee();
        //    emp.Image = image4;
        //    emp.Name = "nstall the Syncfusion.XlsIO.WinForms NuGet package as reference to your .NET Framework application from";
        //    emp.Id = 1025;
        //    emp.Age = 35;
        //    employeeList.Add(emp);

        //    //Return the employee list
        //    return employeeList;
        //}


        public ActionResult OneRecord(int? id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            try
            {
                var Persons = DB.tblPersons.Where(x => x.isActive == true && x.PersonIDNumber == id).FirstOrDefault();
                ViewBag.LabelAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
                ViewBag.AltAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == false).ToList();
                ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
                ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Cost).Sum();
                ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();

                ViewBag.MonthName = "xxx";
                ViewBag.CodeMonth = "xx";
                ViewBag.CodeDay = "xx";
                ViewBag.CodeYear = "xxxx";
                DateTime date = new DateTime();
                if (Persons.BirthMonth != null)
                {
                    if (Persons.BirthYear != null)
                    {
                        date = new DateTime(Persons.BirthYear ?? 0, Persons.BirthMonth ?? 0, 1);
                        ViewBag.CodeYear = date.ToString("yy");
                    }
                    else
                    {
                        date = new DateTime(2020, Persons.BirthMonth ?? 0, 1);

                    }


                    ViewBag.MonthName = date.ToString("MMM");
                    ViewBag.CodeMonth = date.ToString("MM");
                }
                else if (Persons.BirthYear != null)
                {
                    date = new DateTime(Persons.BirthYear ?? 0, 1, 1);
                    ViewBag.CodeYear = date.ToString("yy");

                }

                if (Persons.BirthDay != null && Persons.BirthDay < 10)
                {
                    ViewBag.CodeDay = "0" + Persons.BirthDay.ToString();
                }
                else if (Persons.BirthDay != null)
                {
                    ViewBag.CodeDay = Persons.BirthDay.ToString();
                }


                return View(Persons);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();

        }

        public ActionResult RoutingSlip(int? id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            try
            {
                var Persons = DB.tblPersons.Where(x => x.isActive == true && x.PersonIDNumber == id).FirstOrDefault();
                ViewBag.LabelAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
                ViewBag.AltAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == false).ToList();
                ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
                ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Quantity).Sum();
                ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();

                if (Persons.BirthMonth > 12)
                {
                    Persons.BirthMonth = 12;
                }
                ViewBag.MonthName = "xxx";
                ViewBag.CodeMonth = "xx";
                ViewBag.CodeDay = "xx";
                ViewBag.CodeYear = "xxxx";
                DateTime date = new DateTime();
                if (Persons.BirthMonth != null)
                {
                    if (Persons.BirthYear != null)
                    {
                        date = new DateTime(Persons.BirthYear ?? 0, Persons.BirthMonth ?? 0, 1);
                        ViewBag.CodeYear = date.ToString("yy");
                    }
                    else
                    {
                        date = new DateTime(2020, Persons.BirthMonth ?? 0, 1);

                    }


                    ViewBag.MonthName = date.ToString("MMM");
                    ViewBag.CodeMonth = date.ToString("MM");
                }
                else if (Persons.BirthYear != null)
                {
                    date = new DateTime(Persons.BirthYear ?? 0, 1, 1);
                    ViewBag.CodeYear = date.ToString("yy");

                }

                if (Persons.BirthDay != null && Persons.BirthDay < 10)
                {
                    ViewBag.CodeDay = "0" + Persons.BirthDay.ToString();
                }
                else if (Persons.BirthDay != null)
                {
                    ViewBag.CodeDay = Persons.BirthDay.ToString();
                }



                return View(Persons);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();

        }

        public ActionResult PassportLabel(string Success, string Update, int? id, int? tid)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            try
            {
                HttpCookie cookieObj = Request.Cookies["Settings"];
                string DateFormat = cookieObj["DateFormat"];
                var Persons = DB.tblPersons.Where(x => x.isActive == true && x.PersonIDNumber == id).FirstOrDefault();
                ViewBag.TL = DB.tblTransactions.Where(x => x.isActive == true && x.TransactionIDNumber == tid).FirstOrDefault();
                ViewBag.Settings = DB.tblPassportLabelSettings.ToList();
                ViewBag.Success = Success;
                ViewBag.Update = Update;
                ViewBag.PersonId = id;
                ViewBag.tid = tid;

                var data = DB.tblTransactions.Where(x => x.isActive == true && x.TransactionIDNumber == tid).FirstOrDefault();
                if (ViewBag.TL.IssueDate != "")
                {
                    ViewBag.Exp = Convert.ToDateTime(ViewBag.TL.IssueDate).AddYears(ViewBag.TL.tblProduct.ValidFor);
                    ViewBag.ExpAppend = ViewBag.Exp.ToString("yyMMdd");
                }
                else
                {
                    ViewBag.Exp = null;
                    ViewBag.ExpAppend = null;
                }
                string Line1 = null;
                string Line2 = null;
                int Len;
                if(Persons.FirstName.Contains(","))
                {
                    Persons.FirstName = Persons.FirstName.Replace(",", "<<");
                }
                if(Persons.FirstName.Contains("-"))
                {
                    Persons.FirstName = Persons.FirstName.Replace("-", "<");
                }
                if(Persons.FirstName.Contains(' '))
                {
                    Persons.FirstName= Persons.FirstName.Replace(" ", "<");
                }

                if(Persons.LastName.Contains(","))
                {
                    Persons.LastName= Persons.LastName.Replace(",", "<<");
                }
                if(Persons.LastName.Contains("-"))
                {
                    Persons.LastName = Persons.LastName.Replace("-", "<");
                }
                if(Persons.LastName.Contains(' '))
                {
                    Persons.LastName = Persons.LastName.Replace(" ", "<");
                }
                StringBuilder sb = new StringBuilder(Persons.FirstName);
                for (int i = 0; i < Persons.FirstName.Length; i++)
                {
                    if((Persons.FirstName[i]>='A'&& Persons.FirstName[i] <= 'Z')|| (Persons.FirstName[i] >= 'a' && Persons.FirstName[i] <= 'z'))
                    {

                    }
                    else
                    {
                        char R = Persons.FirstName[i];
                        if(R!= '<')
                        {
                            Persons.FirstName = Persons.FirstName.Replace(R, ' ');
                            Persons.FirstName = Persons.FirstName.Replace(" ", "");
                        }
                        
                        //sb[i] = '';
                    }
                }
                for (int i = 0; i < Persons.LastName.Length; i++)
                {
                    if((Persons.LastName[i]>='A'&& Persons.LastName[i] <= 'Z')|| (Persons.LastName[i] >= 'a' && Persons.LastName[i] <= 'z'))
                    {

                    }
                    else
                    {
                        char R = Persons.LastName[i];
                        if(R!= '<')
                        {
                            Persons.LastName = Persons.LastName.Replace(R, ' ');
                            Persons.LastName = Persons.LastName.Replace(" ", "");
                        }
                    }
                }

                if (Persons.FirstName.Contains(' '))
                {
                    string[] Arr = Persons.FirstName.Split(' ');
                    Len = Arr.Length;
                    Line1 += "P<WSA" + Persons.LastName + "<<" + Arr[0] + "<" + Arr[1] + "<";
                }
                else
                {
                    Line1 += "P<WSA" + Persons.LastName + "<<" + Persons.FirstName + "<";
                }
                while (Line1.Length < 44)
                {
                    Line1 += "<";
                }
                DateTime date = new DateTime();
                string CodeYear = "";
                ViewBag.MonthName = "xxx";
                ViewBag.CodeMonth = "xx";
                ViewBag.CodeDay = "xx";
                ViewBag.CodeYear = "xxxx";
                if (Persons.BirthMonth != null)
                {
                    if (Persons.BirthYear != null)
                    {
                        date = new DateTime(Persons.BirthYear ?? 0, Persons.BirthMonth ?? 0, 1);
                        CodeYear = date.ToString("yy");
                    }
                    else
                    {
                        date = new DateTime(2020, Persons.BirthMonth ?? 0, 1);
                    }


                    ViewBag.MonthName = date.ToString("MMM");
                    ViewBag.CodeMonth = date.ToString("MM");
                }
                else if (Persons.BirthYear != null)
                {
                    date = new DateTime(Persons.BirthYear ?? 0, 1, 1);
                    CodeYear = date.ToString("yy");
                    ViewBag.CodeYear = Persons.BirthYear;
                }

                if (Persons.BirthDay != null && Persons.BirthDay < 10)
                {
                    ViewBag.CodeDay = "0" + Persons.BirthDay.ToString();
                }
                else if (Persons.BirthDay != null)
                {
                    ViewBag.CodeDay = Persons.BirthDay.ToString();
                }





                Line2 += ViewBag.TL.IDCode + "<<<0WSA" + CodeYear + ViewBag.CodeMonth + ViewBag.CodeDay + "9" + Persons.tblSex.Name + ViewBag.ExpAppend + "7";
                while (Line2.Length < 42)
                {
                    Line2 += "<";
                }
                Line2 += "08";
                ViewBag.Line1 = Line1;
                ViewBag.Line2 = Line2;

                //data.tblProduct.tblProductType.Name
                //ViewBag.LabelAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
                //ViewBag.AltAddress = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == false).ToList();
                //ViewBag.Transaction = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).ToList();
                //ViewBag.Sum = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Select(s => s.Quantity).Sum();
                //ViewBag.Count = DB.tblTransactions.Where(x => x.isActive == true && x.PersonIDNumber == id).Count();
                return View(Persons);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();

        }

        public ActionResult AlphaLabel(int? id, int State = 0, int CState = 0)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            try
            {
                var Address = DB.tblAddresses.Where(x => x.isActive == true && x.PersonIDNumber == id && x.Label == true).FirstOrDefault();
                if (Address != null)
                {
                    ViewBag.WSA = Address.tblPerson.WSANumber;
                    ViewBag.FName = Address.tblPerson.FirstName;
                    ViewBag.LName = Address.tblPerson.LastName;
                    ViewBag.QRCode = Address.tblPerson.QRCode;
                }
                else
                {
                    ViewBag.WSA = "";
                    ViewBag.FName = "";
                    ViewBag.LName = "";
                }
                ViewBag.State = State;
                ViewBag.CState = CState;
                ViewBag.id = id;
                return View(Address);
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }
            return View();

        }

        [HttpPost]
        public ActionResult CreatePassportLabelSetting(tblPassportLabelSetting PassportLabelSetting, int? id, int? tid)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblPassportLabelSetting Data = new tblPassportLabelSetting();
            try
            {

                ViewBag.User = Session["User"];
                if (PassportLabelSetting.PassportLabelSettingId == 0)
                {
                    Data = PassportLabelSetting;


                    Data.CreatedDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    Data.CreatedBy = ViewBag.User.UserId;
                    Data.EditBy = ViewBag.User.UserId;
                    DB.tblPassportLabelSettings.Add(Data);
                    DB.SaveChanges();


                    return RedirectToAction("PassportLabel", new { Success = "Settings has been add successfully.", id = id, tid = tid });

                }
                else
                {

                    //Data = DB.tblPassportLabelSettings.Select(r => r).Where(x => x.PassportLabelSettingId == PassportLabelSetting.PassportLabelSettingId).FirstOrDefault();
                    //Data = PassportLabelSetting;
                    //Data.PersonIDNumber = Transaction.PersonIDNumber;
                    //Data.ProductIDNumber = Transaction.ProductIDNumber;
                    //Data.IDCode = Transaction.IDCode;
                    //Data.Cost = Transaction.Cost;
                    //Data.Quantity = Transaction.Quantity;
                    //Data.Problems = Transaction.Problems;
                    //Data.IssueDate = Transaction.IssueDate;
                    //Data.SentDate = Transaction.SentDate;
                    //Data.ReturnDate = Transaction.ReturnDate;

                    PassportLabelSetting.EditDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    PassportLabelSetting.EditBy = ViewBag.User.UserId;

                    DB.Entry(PassportLabelSetting).State = EntityState.Modified; ;
                    DB.SaveChanges();
                    return RedirectToAction("PassportLabel", new { Update = "Settings has been Update successfully.", id = id, tid = tid });


                }


            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("PassportLabel", new { id = id, tid = tid });
        }
    }
}