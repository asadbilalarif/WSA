using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldServiceOrganization.Models;

namespace WorldServiceOrganization.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Users()
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            List<tblUser> UserList = DB.tblUsers.Where(x=>x.isActive==true).ToList();
            return View(UserList);
        }

        public ActionResult CreateUser(int? id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblUser User = null;
            ViewBag.Roles = DB.tblRoles.Where(x => x.isActive == true).ToList();
            if (id != null && id != 0)
            {

                User = DB.tblUsers.Where(x => x.UserId == id).FirstOrDefault();
                return View(User);
            }
            else
            {
                return View(User);
            }
        }

        [HttpPost]
        public ActionResult CreateUser(tblUser User)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();

            tblUser Data = new tblUser();
            tblRole Foreign = new tblRole();
            try
            {
                if(User.UserId==0)
                {
                    if (DB.tblUsers.Select(r => r).Where(x => x.username == User.username || x.Email == User.Email).FirstOrDefault() == null)
                    {
                        Data = User;
                        //Foreign = DB.tblRoles.Where(x => x.RoleId == User.RoleId).FirstOrDefault();
                        //Data.tblRole = Foreign;
                        byte[] EncDataBtye = new byte[User.PIN.Length];
                        EncDataBtye = System.Text.Encoding.UTF8.GetBytes(User.PIN);
                        Data.PIN = Convert.ToBase64String(EncDataBtye);
                        Data.CreatedDate = DateTime.Now;
                        Data.isActive = true;
                        DB.tblUsers.Add(Data);
                        DB.SaveChanges();

                    }
                    else
                    {
                        ViewBag.Error = "User Already Exsist!!!";
                    }
                }
                else
                {
                    var check = DB.tblUsers.Select(r => r).Where(x => x.username == User.username || x.Email == User.Email).FirstOrDefault();
                    if (check==null||check.UserId==User.UserId)
                    {
                        //Foreign = DB.tblRoles.Where(x => x.RoleId == User.RoleId).FirstOrDefault();
                        //Data.tblRole = Foreign;
                        Data = DB.tblUsers.Select(r => r).Where(x => x.UserId == User.UserId).FirstOrDefault();
                        Data.username = User.username;
                        Data.UserId = User.UserId;
                        Data.FirstName = User.FirstName;
                        Data.LastName = User.LastName;
                        Data.Organization = User.Organization;
                        Data.Title = User.Title;
                        Data.Address1 = User.Address1;
                        Data.Address2 = User.Address2;
                        Data.City = User.City;
                        Data.StateProvince = User.StateProvince;
                        Data.Country = User.Country;
                        Data.PostalCode = User.PostalCode;
                        Data.PhoneNumber = User.PhoneNumber;
                        Data.Email = User.Email;
                        Data.RoleId = User.RoleId;
                        if (User.PIN != null)
                        {
                            byte[] EncDataBtye = new byte[User.PIN.Length];
                            EncDataBtye = System.Text.Encoding.UTF8.GetBytes(User.PIN);
                            Data.PIN = Convert.ToBase64String(EncDataBtye);
                        }
                        DB.Entry(Data);
                        DB.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Error = "User Already Exsist!!!";
                    }
                    
                }
                

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

            return RedirectToAction("Users");
        }


        [HttpPost]
        public ActionResult DeleteUser( int UserId)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblUser Data = new tblUser();
            try
            {
                Data = DB.tblUsers.Select(r => r).Where(x => x.UserId == UserId).FirstOrDefault();
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

        public ActionResult RolesPermission(int? id)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            List<tblRole> Roles= DB.tblRoles.Where(x => x.isActive == true).ToList();
            ViewBag.MenuList = DB.tblMenus.ToList();


            var check = DB.tblAccessLevels.Where(x => x.RoleId == id).FirstOrDefault();
            if (id != null && id != 0 && check != null)
            {
                ViewBag.SelectedRole = DB.tblRoles.Where(x => x.RoleId == id).FirstOrDefault();

                ViewBag.SelectedMenuAccess = (from h in DB.tblMenus
                                              join t in DB.tblAccessLevels.Where(x => x.RoleId == id) on h.MenuId equals t.MenuId into gj
                                              from acc in gj.DefaultIfEmpty()
                                                  //where acc.roleid == id
                                              select new MenuAccess
                                              {
                                                  menu = h,
                                                  //accesslevelid = acc.accesslevelid,
                                                  accessedit = acc.EditAccess,
                                                  accessdelete = acc.DeleteAccess,
                                                  accesscreate = acc.CreateAccess,
                                                  isactive = acc.isActive,
                                                  roleid = id,
                                                  menuid = h.MenuId,

                                              }).ToList();
            }
            else
            {
                if (id != null && id != 0)
                {
                    ViewBag.SelectedRole = DB.tblRoles.Where(x => x.RoleId == id).FirstOrDefault();
                }
                else
                {
                    ViewBag.SelectedRole = null;
                }
                ViewBag.SelectedMenuAccess = null;
            }

            try
            {

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                Console.WriteLine("Error" + ex.Message);
            }

           

            return View(Roles);
        }


        [HttpPost]
        public ActionResult CreateRole(string Role ,bool? isActive, int RoleId = 0)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            tblRole Data = new tblRole();
            try
            {
                if (RoleId != 0)
                {
                    //tblrole foreigntbl = _context.tblrole.Select(r => r).Where(x => x.roleid == User.roleid).FirstOrDefault();

                    tblRole check = DB.tblRoles.Select(r => r).Where(x => x.Role == Role).FirstOrDefault();
                    if (check == null || check.RoleId == RoleId)
                    {
                        Data = DB.tblRoles.Select(r => r).Where(x => x.RoleId == RoleId).FirstOrDefault();
                        
                        Data.Role = Role;
                        Data.isActive = isActive;
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
                    //tblrole foreigntbl = _context.tblrole.Select(r => r).Where(x => x.roleid == User.roleid).FirstOrDefault();

                    if(DB.tblRoles.Select(r => r).Where(x => x.Role == Role).FirstOrDefault() == null)
                    {
                        Data.Role = Role;
                        Data.isActive = isActive;
                        Data.CreatedDate = DateTime.Now;
                        DB.tblRoles.Add(Data);
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
        public ActionResult CreateAccessLevel( List<tblAccessLevel> Items)
        {
            WorldServiceOrganizationEntities DB = new WorldServiceOrganizationEntities();
            //tblaccesslevel Data = new tblaccesslevel();
            try
            {
                foreach (tblAccessLevel AccessLevel in Items)
                {
                    var Del = DB.tblAccessLevels.Select(r => r).Where(x => x.RoleId == AccessLevel.RoleId && x.MenuId == AccessLevel.MenuId).FirstOrDefault();
                    if (Del != null)
                    {
                        DB.tblAccessLevels.Remove(Del);
                    }
                }

                foreach (tblAccessLevel AccessLevel in Items)
                {
                    AccessLevel.CreatedDate = DateTime.Now;
                    AccessLevel.tblMenu = DB.tblMenus.Select(r => r).Where(x => x.MenuId == AccessLevel.MenuId).FirstOrDefault();
                    AccessLevel.tblRole = DB.tblRoles.Select(r => r).Where(x => x.RoleId == AccessLevel.RoleId).FirstOrDefault();
                    DB.tblAccessLevels.Add(AccessLevel);
                }
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