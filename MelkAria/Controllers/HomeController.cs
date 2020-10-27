using MelkAria.DAL;
using MelkAria.Models;
using MelkAria.Utility;
using MelkAria.ViewModels.Home;
using MelkAria.ViewModels.melk;
using MelkAria.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services;

namespace MelkAria.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        //[Authorize(Roles = "Member")]
        public ActionResult Index(HomeViewModel viewModel)
        {
            var userNamee = User.Identity.Name;
            var user = db.Users.Where(p => p.userNamee == userNamee).FirstOrDefault();
            return View(viewModel);
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

        public ActionResult Single(string name)
        {
            name = name.Replace('-', ' ');
            var melk = db.melks.FirstOrDefault(x => x.title == name);
            if (melk.ViewCount == null)
                melk.ViewCount = 0;
            if (melk.status == EnumStatus.Accept)
            {
                melk.ViewCount = melk.ViewCount + 1;
            }
            db.SaveChanges();
            HomeSingleViewModel model = new HomeSingleViewModel();
            model.melk = melk;
            model.Lastmelks = db.melks.Where(x => x.id != melk.id).OrderByDescending(p =>p.id).Take(3).ToList();
            model.photos = db.photos.Where(x => x.melkId == melk.id).OrderByDescending(x => x.id).ToList();
            return View(model);
        }
        public ActionResult LoadMelksData(SearchHomeViewModel search)
        {
            search.page = search.page > 0 ? search.page : 1;

            var query = db.melks.Where(x => x.status == EnumStatus.Accept).AsQueryable();
            if (search.address != null)
                query = query.Where(p => p.address.Contains(EntityFunctions.AsUnicode(search.address)));
            if (search.fromPrice != null)
                query = query.Where(p => p.price >= search.fromPrice);
            if (search.toPrice != null)
                query = query.Where(p => p.price <= search.toPrice);
            if (search.roomCount != null)
                query = query.Where(p => p.roomCount == search.roomCount);
            if (search.kind != null)
                query = query.Where(p => p.kind == search.kind);
            if (search.code != null)
                query = query.Where(p => p.code == search.code);
            //if (search.statusKind != 0)
            //    query = query.Where(p => p.statusKind == search.statusKind);
            return View(query.OrderByDescending(p => p.id).Skip(12 * (search.page - 1)).Take(12).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addmelk(melkViewModel page)
        {
            ModelState.Remove("id");
            var userNamee = User.Identity.Name;
            var user = db.Users.Where(p => p.userNamee == userNamee).FirstOrDefault();
            if (user != null)
                ModelState.Remove("usermobile");
            if (page.Tavafoghi == true)
            {
                ModelState.Remove("price");
                ModelState.Remove("priceRahn");
            }
            if (!page.IsRahn)
                ModelState.Remove("Ghabeletabdil");
            if (ModelState.IsValid)
            {

                if (db.melks.Any(x => x.title == page.title && x.id != page.id))
                {
                    return Json("ErrorTitle");

                }
                var melk = new melk();
                var img = Request.Files["imageUrl"];
                var imageUrl = "";
                if (img.ContentLength != 0)
                {
                    var name = Guid.NewGuid().ToString().Replace('-', '0') + ".jpg";
                    imageUrl = "/Upload/melks/" + name;
                    string path = Server.MapPath(imageUrl);
                    img.SaveAs(path);
                }
                if (page.id == 0)
                {
                    //Random random1 = new Random();
                    if (db.melks.Count() == 0)
                        melk.code = 1;
                    else
                        melk.code = (db.melks.ToList().LastOrDefault().code) + 1;

                    melk.title = page.title;
                    melk.yearProduce = page.yearProduce;

                    melk.ensheabat = page.ensheabat;
                    melk.tell = page.tell;
                    melk.address = page.address;
                    melk.description = page.description;
                    melk.Tavafoghi = page.Tavafoghi;
                    melk.Ghabeletabdil = page.Ghabeletabdil;
                    melk.sanad = page.sanad;
                    //melk.lon = page.lon;
                    //melk.lat = page.lat;
                    melk.createDate = DateTime.Now;
                    melk.pCreateDate = PersianCalendarDate.PersianCalendarResult(DateTime.Now);
                    if (imageUrl != "")
                    {
                        melk.imageUrl = imageUrl;
                    }
                    melk.kind = page.kind;
                    //melk.statusKind = page.statusKind;
                    melk.cellingKind = page.cellingKind;
                    melk.floorCount = page.floorCount;
                    melk.price = page.price;
                    melk.priceRahn = page.priceRahn;

                    melk.floorKind = page.floorKind;
                    melk.heatingKind = page.heatingKind;
                    //melk.isYard = page.isYard;
                    melk.metraj = page.metraj;
                    melk.parkingKind = page.parkingKind;
                    melk.roomCount = page.roomCount;
                    melk.IsRahn = page.IsRahn;
                    melk.Skeletontype = page.Skeletontype;
                    melk.Pricepersquaremeter = page.Pricepersquaremeter;
                    melk.IsElevator = page.IsElevator;
                    melk.IsJacuzzi = page.IsJacuzzi;
                    melk.IsParking = page.IsParking;
                    melk.Isswimmingpool = page.Isswimmingpool;
                    melk.CoolKind = page.CoolKind;
                    melk.status = MelkAria.Models.EnumStatus.Pending;
                    if (user != null)
                        melk.userId = user.id;
                    else
                    {
                        if (db.Users.Any(p => p.mobile == page.usermobile))
                        {
                            var userr = db.Users.FirstOrDefault(p => p.mobile == page.usermobile);
                            melk.userId = userr.id;
                            var sendServiceClient = new com.irpayamak.login.Send();
                            var res = sendServiceClient.SendSms("Alisabzevari", "210759",
                                 "50002964", new[] { userr.mobile },
                             "به املاک آریا خوش آمدید" + System.Environment.NewLine + "رمز عبور:" + userr.passwordShow, false);
                        }
                        else
                        {
                            role r = db.Roles.Where(p => p.RoleNameEn == "Member").FirstOrDefault();
                            var user2 = new user();
                            user2.role = r;
                            Random random = new Random();
                            string password = random.Next(1000, 9999).ToString();
                            //var UserName = "U" + random.Next(1000, 9999);
                            user2.passwordShow = password;
                            user2.password = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(password, DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt());
                            user2.mobile = page.usermobile;
                            user2.userNamee = page.usermobile;

                            var sendServiceClient = new com.irpayamak.login.Send();
                            var res = sendServiceClient.SendSms("Alisabzevari", "210759",
                                 "50002964", new[] { user2.mobile },
                             "به املاک آریا خوش آمدید" + System.Environment.NewLine + "رمز عبور:" + user2.passwordShow, false);
                            db.Users.Add(user2);
                            melk.userId = user2.id;
                        }
                    }
                    db.melks.Add(melk);
                }
                else
                {
                    melk = db.melks.Find(page.id);
                    melk.ensheabat = page.ensheabat;
                    melk.title = page.title;
                    melk.yearProduce = page.yearProduce;
                    melk.tell = page.tell;
                    melk.address = page.address;
                    melk.description = page.description;
                    //melk.lon = page.lon;
                    //melk.lat = page.lat;
                    melk.kind = page.kind;
                    melk.Tavafoghi = page.Tavafoghi;
                    melk.Ghabeletabdil = page.Ghabeletabdil;
                    melk.sanad = page.sanad;
                    //melk.statusKind = page.statusKind;
                    melk.cellingKind = page.cellingKind;
                    melk.floorCount = page.floorCount;
                    melk.price = page.price;
                    melk.priceRahn = page.priceRahn;
                    melk.floorKind = page.floorKind;
                    melk.heatingKind = page.heatingKind;
                    //melk.isYard = page.isYard;
                    melk.metraj = page.metraj;
                    melk.parkingKind = page.parkingKind;
                    melk.roomCount = page.roomCount;
                    //melk.IsRahn = page.IsRahn;
                    melk.Skeletontype = page.Skeletontype;
                    melk.Pricepersquaremeter = page.Pricepersquaremeter;
                    melk.IsElevator = page.IsElevator;
                    melk.IsJacuzzi = page.IsJacuzzi;
                    melk.IsParking = page.IsParking;
                    melk.Isswimmingpool = page.Isswimmingpool;
                    melk.CoolKind = page.CoolKind;
                    melk.status = MelkAria.Models.EnumStatus.Pending;
                    if (imageUrl != "")
                    {
                        melk.imageUrl = imageUrl;
                    }
                }
                db.SaveChanges();
                if (user != null)
                    return RedirectToAction("AddAditionalmelk", new { id = melk.id });
                else
                    return RedirectToAction("AddAditionalmelkNewUser", new { id = melk.id });

            }
            else
            {
                return Json("Error");
            }
        }

        public ActionResult AddAditionalmelk(int id)
        {
            var model = new additionalInfoViewModel();
            model.id = id;
            model.photos = db.photos.Where(x => x.melkId == id).ToList();
            var melk = db.melks.FirstOrDefault(x => x.id == id);
            model.melk = melk;
            if (melk.lon == 0)
                melk.lon = 51.6650002;
            if (melk.lat == 0)
                melk.lat = 32.6707877;
            return View(model);
        }
        public ActionResult AddAditionalmelkNewUser(int id)
        {
            var model = new additionalInfoViewModel();
            model.id = id;
            model.photos = db.photos.Where(x => x.melkId == id).ToList();
            var melk = db.melks.FirstOrDefault(x => x.id == id);
            model.melk = melk;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddmelkWithLon(int melkId, double lon, double lat)
        {
            var melk = db.melks.FirstOrDefault(x => x.id == melkId);
            melk.lon = lon;
            melk.lat = lat;
            db.SaveChanges();
            return Json("Done");
        }



        [HttpPost]
        public ActionResult AddmelkWithNewUser(int melkId, string password)
        {
            var melk = db.melks.FirstOrDefault(x => x.id == melkId);
            var user = db.Users.FirstOrDefault(x => x.id == melk.userId);
            if (user.passwordShow != password)
            {
                var photo = db.photos.Where(x => x.melkId == melkId);
                try
                {
                    System.IO.File.Delete(Server.MapPath(melk.imageUrl));
                }
                catch (Exception ex)
                {

                }
                if (photo != null)
                {
                    foreach (var item in photo)
                    {
                        try
                        {
                            System.IO.File.Delete(Server.MapPath(item.file));
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                db.melks.Remove(melk);
                db.SaveChanges();
                return Json("Fail");

            }
            return RedirectToAction("AddAditionalmelk", new { id = melk.id });



        }
        [HttpPost]
        public ActionResult DeletePhoto(int id)
        {
            try
            {
                var photo = db.photos.Find(id);
                try
                {
                    System.IO.File.Delete(HostingEnvironment.MapPath(photo.file));
                }
                catch (Exception ex)
                {

                }
                db.photos.Remove(photo);
                db.SaveChanges();
                return Json("Done");
            }
            catch (Exception ex)
            {
                return Json("Failed");
            }
        }
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase[] files, int id, double lon, double lat)
        {
            try
            {
                var melk = db.melks.FirstOrDefault(x => x.id == id);

                List<photo> photos = new List<photo>();
                if (ModelState.IsValid)
                {   //iterating through multiple file collection   
                    foreach (HttpPostedFileBase file in files)
                    {
                        //Checking file is available to save.  
                        if (file != null)
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace('-', '0');
                            var ServerSavePath = Path.Combine(Server.MapPath("~/Upload/melks/") + fileName + Path.GetExtension(InputFileName));
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);
                            //assigning file uploaded status to ViewBag for showing message to user.  
                            ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                            photos.Add(new photo()
                            {
                                file = "/Upload/melks/" + fileName + Path.GetExtension(InputFileName),
                                melkId = id
                            });
                        }

                    }
                    db.photos.AddRange(photos);
                    melk.lon = lon;
                    melk.lat = lat;
                    db.SaveChanges();
                }
                var userNamee = User.Identity.Name;
                var user = db.Users.Where(p => p.userNamee == userNamee).FirstOrDefault();
                if (user != null)
                    return Redirect("/User/Profile");
                else
                {
                    var user2 = db.Users.Where(p => p.id == melk.userId).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(user2.userNamee, false);
                    return Redirect("/User/Profile");
                }
            }
            catch (Exception ex)
            {
                var userNamee = User.Identity.Name;
                var user = db.Users.Where(p => p.userNamee == userNamee).FirstOrDefault();
                if (user != null)
                    return Redirect("/User/Profile");
                else
                    return Json("Done");
            }
        }
        public ActionResult RegisterMelk(bool israhn)
        {
            var model = new melkViewModel();
            //model.citys = db.cities.ToList();
            //model.melkstatuss = db.melkstatuss.ToList();
            model.lon = 51.6650002;
            model.lat = 32.6707877;
            model.id = 0;
            model.IsRahn = israhn;
            return View(model);
        }
        [HttpPost]
        public ActionResult Deletemelk(int ID)
        {
            try
            {
                var melk = db.melks.Find(ID);
                var photo = db.photos.Where(x => x.melkId == ID);
                try
                {
                    System.IO.File.Delete(Server.MapPath(melk.imageUrl));
                }
                catch (Exception ex)
                {

                }
                if (photo != null)
                {
                    foreach (var item in photo)
                    {
                        try
                        {
                            System.IO.File.Delete(Server.MapPath(item.file));
                        }
                        catch (Exception ex)
                        { }
                    }
                }
                db.melks.Remove(melk);
                db.SaveChanges();
                return Json("Done");

            }
            catch (Exception ex)
            {
                return Json("Failed");
            }
        }
    }
}