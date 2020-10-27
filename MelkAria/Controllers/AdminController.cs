
using MelkAria.DAL;
using MelkAria.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using MelkAria.ViewModels.city;
using MelkAria.ViewModels.contactUs;
using MelkAria.ViewModels.melk;
using MelkAria.ViewModels.rule;
using MelkAria.ViewModels.aboutUs;
using MelkAria.ViewModels.User;
using System.IO;
using MelkAria.Utility;
using System.Web;
using System.Collections.Generic;
using System.Web.Hosting;
//using MelkAria.ViewModels.melkstatus;
using System.Net.Http;
using System.Text;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
//using TeleBot;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using InstagramApiSharp.API;

namespace MelkAria.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataBaseContext db = new DataBaseContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            return View();
        }

        //#region city
        //[Authorize(Roles = "Admin")]

        //public ActionResult city()
        //{
        //    var model = new cityViewModel();
        //    return View(model);
        //}
        //public ActionResult LoadcityData(string name = "", string nameEnglish = "", int page = 1, int pageSize = 10)
        //{
        //    page = page > 0 ? page : 1;
        //    pageSize = pageSize > 0 ? pageSize : 10;
        //    var query = db.cities.AsQueryable();
        //    if (name != "")
        //        query = query.Where(p => p.name.Contains(EntityFunctions.AsUnicode(name)));
        //    if (nameEnglish != "")
        //        query = query.Where(p => p.nameEnglish.Contains(nameEnglish));
        //    var model = new LoadcityDataViewModel();
        //    model.cities = query.OrderByDescending(p => p.id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
        //    model.TotalNumber = query.ToList().Count();
        //    return View(model);

        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Addcity(cityViewModel page)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (page.id == 0 || page.id == null)
        //        {
        //            var city = new city();
        //            city.name = page.name;
        //            city.nameEnglish = page.nameEnglish;
        //            db.cities.Add(city);
        //        }
        //        else
        //        {
        //            var city = db.cities.Find(page.id);
        //            city.name = page.name;
        //            city.nameEnglish = page.nameEnglish;
        //        }
        //        db.SaveChanges();
        //        return Json("Done");
        //    }
        //    else
        //    {
        //        return Json("Error");
        //    }
        //}


        //[HttpGet]
        //public JsonResult Getcity(int ID)
        //{
        //    var city = new city();
        //    string Message = "False";
        //    if (ID != 0)
        //    {
        //        city = db.cities.FirstOrDefault(x => x.id == ID);
        //        Message = "True";
        //        return Json(city, Message, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(city, Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public ActionResult Deletecity(int ID)
        //{
        //    try
        //    {
        //        var city = db.cities.Find(ID);
        //        db.cities.Remove(city);
        //        db.SaveChanges();
        //        return Json("Done");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("Failed");
        //    }
        //}

        //#endregion
        #region rule
        [Authorize(Roles = "Admin")]
        public ActionResult rule()
        {
            var model = new ruleViewModel();

            return View(model);
        }
        public ActionResult LoadruleData(string title = "", int page = 1, int pageSize = 10)
        {
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 10;

            var query = db.rules.AsQueryable();
            if (title != "")
                query = query.Where(p => p.title.Contains(EntityFunctions.AsUnicode(title)));
            var model = new LoadruleDataViewModel();
            model.rules = query.OrderByDescending(p => p.id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            model.TotalNumber = query.ToList().Count();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addrule(ruleViewModel page)
        {
            if (ModelState.IsValid)
            {
                if (page.id == 0 || page.id == null)
                {
                    var rule = new rule();
                    rule.title = page.title;
                    rule.description = page.description;
                    db.rules.Add(rule);
                }
                else
                {
                    var rule = db.rules.Find(page.id);
                    rule.title = page.title;
                    rule.description = page.description;
                }
                db.SaveChanges();
                return Json("Done");
            }
            else
            {
                return Json("Error");
            }
        }
        [HttpGet]
        public JsonResult Getrule(int ID)
        {
            var rule = new rule();
            string Message = "False";
            if (ID != 0)
            {
                rule = db.rules.FirstOrDefault(x => x.id == ID);
                Message = "True";
                return Json(rule, Message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(rule, Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Deleterule(int ID)
        {
            try
            {
                var rule = db.rules.Find(ID);
                db.rules.Remove(rule);
                db.SaveChanges();
                return Json("Done");

            }
            catch (Exception ex)
            {
                return Json("Failed");
            }
        }
        #endregion
        //#region melkstatus
        //[Authorize(Roles = "Admin")]

        //public ActionResult melkstatus()
        //{
        //    var model = new melkstatusViewModel();

        //    return View(model);
        //}
        //public ActionResult LoadmelkstatusData(string title = "", int page = 1, int pageSize = 10)
        //{
        //    page = page > 0 ? page : 1;
        //    pageSize = pageSize > 0 ? pageSize : 10;

        //    var query = db.melkstatuss.AsQueryable();
        //    if (title != "")
        //        query = query.Where(p => p.title.Contains(EntityFunctions.AsUnicode(title)));
        //    var model = new LoadmelkstatusDataViewModel();
        //    model.melkstatuss = query.OrderByDescending(p => p.id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
        //    model.TotalNumber = query.ToList().Count();
        //    return View(model);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Addmelkstatus(melkstatusViewModel page)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (page.id == 0 || page.id == null)
        //        {
        //            var melkstatus = new melkstatus();
        //            melkstatus.title = page.title;
        //            db.melkstatuss.Add(melkstatus);
        //        }
        //        else
        //        {
        //            var melkstatus = db.melkstatuss.Find(page.id);
        //            melkstatus.title = page.title;
        //        }
        //        db.SaveChanges();
        //        return Json("Done");
        //    }
        //    else
        //    {
        //        return Json("Error");
        //    }
        //}


        //[HttpGet]
        //public JsonResult Getmelkstatus(int ID)
        //{
        //    var melkstatus = new melkstatus();
        //    string Message = "False";
        //    if (ID != 0)
        //    {
        //        melkstatus = db.melkstatuss.FirstOrDefault(x => x.id == ID);
        //        Message = "True";
        //        return Json(melkstatus, Message, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(melkstatus, Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public ActionResult Deletemelkstatus(int ID)
        //{
        //    try
        //    {
        //        var melkstatus = db.melkstatuss.Find(ID);
        //        db.melkstatuss.Remove(melkstatus);
        //        db.SaveChanges();
        //        return Json("Done");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("Failed");
        //    }
        //}

        //#endregion



        #region contactUs

        [Authorize(Roles = "Admin")]

        public ActionResult contactUs()
        {
            var contactUs = db.contactUss.FirstOrDefault();
            var model = new contactUsViewModel();
            if (contactUs != null)
            {
                model.phone = contactUs.phone;
                model.pageTelegramUrl = contactUs.pageTelegramUrl;
                model.pageInstagramUrl = contactUs.pageInstagramUrl;
                model.pageTwitterUrl = contactUs.pageTwitterUrl;
                model.siteName = contactUs.siteName;
                model.email = contactUs.email;
                model.id = contactUs.id;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UpdatecontactUs(contactUsViewModel viewModel)
        {
            if (db.contactUss.Any(p => p.id == viewModel.id))
            {
                var contactUs = db.contactUss.Where(p => p.id == viewModel.id).FirstOrDefault();
                contactUs.phone = viewModel.phone;
                contactUs.pageTelegramUrl = viewModel.pageTelegramUrl;
                contactUs.pageInstagramUrl = viewModel.pageInstagramUrl;
                contactUs.pageTwitterUrl = viewModel.pageTwitterUrl;
                contactUs.siteName = viewModel.siteName;
                contactUs.email = viewModel.email;
                db.SaveChanges();
            }
            else
            {
                var contactUs = new contactUs();
                contactUs.phone = viewModel.phone;
                contactUs.pageTelegramUrl = viewModel.pageTelegramUrl;
                contactUs.pageInstagramUrl = viewModel.pageInstagramUrl;
                contactUs.pageTwitterUrl = viewModel.pageTwitterUrl;
                contactUs.siteName = viewModel.siteName;
                contactUs.email = viewModel.email;
                db.contactUss.Add(contactUs);
                db.SaveChanges();
            }
            return RedirectToAction("contactUs");
        }
        #endregion

        #region aboutUs

        [Authorize(Roles = "Admin")]

        public ActionResult aboutUs()
        {
            var aboutUs = db.aboutUss.FirstOrDefault();
            var model = new aboutUsViewModel();
            if (aboutUs != null)
            {
                model.androidVersion = aboutUs.androidVersion;
                model.author = aboutUs.author;
                model.description = aboutUs.description;
                model.title = aboutUs.title;
                model.id = aboutUs.id;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UpdateaboutUs(aboutUsViewModel viewModel)
        {
            if (db.aboutUss.Any(p => p.id == viewModel.id))
            {
                var aboutUs = db.aboutUss.Where(p => p.id == viewModel.id).FirstOrDefault();
                aboutUs.androidVersion = viewModel.androidVersion;
                aboutUs.author = viewModel.author;
                aboutUs.description = viewModel.description;
                aboutUs.title = viewModel.title;
                db.SaveChanges();
            }
            else
            {
                var aboutUs = new aboutUs();
                aboutUs.androidVersion = viewModel.androidVersion;
                aboutUs.author = viewModel.author;
                aboutUs.description = viewModel.description;
                aboutUs.title = viewModel.title;
                db.aboutUss.Add(aboutUs);
                db.SaveChanges();
            }
            return RedirectToAction("aboutUs");
        }
        #endregion

        #region melk
        [Authorize(Roles = "Admin")]

        public ActionResult melk()
        {
            var model = new melkViewModel();

            return View(model);
        }
        [Authorize(Roles = "Admin")]

        public ActionResult newmelk(int? id , string israhn)
        {
            var model = new melkViewModel();
            model.users = db.Users.ToList();
            if (!string.IsNullOrEmpty(israhn)&&israhn.Equals("true"))
            {
                model.IsRahn = true;
            }
            model.lon = 51.6650002;
            model.lat = 32.6707877;
            if (id != null)
            {
                var melk = db.melks.FirstOrDefault(x => x.id == id);
                if (melk.IsRahn)
                {
                    model.IsRahn = true;
                }
                model.code = melk.code;
                model.id = melk.id;
                model.lon = melk.lon;
                model.lat = melk.lat;
                model.ensheabat = melk.ensheabat;
                model.yearProduce = melk.yearProduce;
                model.title = melk.title;
                model.tell = melk.tell;
                model.address = melk.address;
                model.description = melk.description;
                model.imageUrl = melk.imageUrl;
                model.kind = melk.kind;
                //model.statusKind = melk.statusKind;
                model.cellingKind = melk.cellingKind;
                model.floorCount = melk.floorCount;
                model.floorKind = melk.floorKind;
                model.heatingKind = melk.heatingKind;
                //model.isYard = melk.isYard;
                model.metraj = melk.metraj;
                model.parkingKind = melk.parkingKind;
                model.roomCount = melk.roomCount;
                model.price = melk.price;
                model.priceRahn = melk.priceRahn;
                model.userId = melk.userId;
                model.Tavafoghi = melk.Tavafoghi;
                model.sanad = melk.sanad;
                model.Ghabeletabdil = melk.Ghabeletabdil;
                model.IsRahn = melk.IsRahn;
                model.Pricepersquaremeter = melk.Pricepersquaremeter;
                model.IsElevator = melk.IsElevator;
                model.IsJacuzzi = melk.IsJacuzzi;
                model.IsParking = melk.IsParking;
                model.Isswimmingpool = melk.Isswimmingpool;
                model.Skeletontype = melk.Skeletontype;
                model.CoolKind = melk.CoolKind;
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addmelk(melkViewModel page)
        {
            ModelState.Remove("id");
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
                    if (db.melks.Count()==0)
                        melk.code = 1;
                    else
                        melk.code=(db.melks.ToList().LastOrDefault().code)+1;                  
                    melk.title = page.title;
                    melk.ensheabat = page.ensheabat;
                    melk.yearProduce = page.yearProduce;
                    melk.userId = page.userId;
                    melk.tell = page.tell;
                    melk.address = page.address;
                    melk.description = page.description;
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
                    melk.Tavafoghi = page.Tavafoghi;
                    melk.Ghabeletabdil = page.Ghabeletabdil;
                    melk.sanad = page.sanad;
                    melk.floorKind = page.floorKind;
                    melk.heatingKind = page.heatingKind;
                    //melk.isYard = page.isYard;
                    melk.metraj = page.metraj;
                    melk.parkingKind = page.parkingKind;
                    melk.roomCount = page.roomCount;
                    melk.status = MelkAria.Models.EnumStatus.Accept;
                    melk.Pricepersquaremeter = page.Pricepersquaremeter;
                    melk.IsElevator = page.IsElevator;
                    melk.IsJacuzzi = page.IsJacuzzi;
                    melk.IsParking = page.IsParking;
                    melk.Isswimmingpool = page.Isswimmingpool;
                    melk.Skeletontype = page.Skeletontype;
                    melk.CoolKind = page.CoolKind;
                    if (page.IsRahn)
                    {
                        melk.IsRahn = true;
                    }
                    db.melks.Add(melk);
                }
                else
                {
                    melk = db.melks.Find(page.id);
                    melk.title = page.title;
                    melk.ensheabat = page.ensheabat;
                    melk.yearProduce = page.yearProduce;
                    melk.userId = page.userId;
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
                    melk.status = MelkAria.Models.EnumStatus.Accept;
                    melk.Pricepersquaremeter = page.Pricepersquaremeter;
                    melk.IsElevator = page.IsElevator;
                    melk.IsJacuzzi = page.IsJacuzzi;
                    melk.IsParking = page.IsParking;
                    melk.Isswimmingpool = page.Isswimmingpool;
                    melk.Skeletontype = page.Skeletontype;
                    melk.CoolKind = page.CoolKind;
                    if (imageUrl != "")
                    {
                        melk.imageUrl = imageUrl;
                    }
                }
                db.SaveChanges();
                //return RedirectToAction("AddAditionalmelk", new { id = melk.id });
                return Json(melk.id , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error");
            }
        }

        public ActionResult AddAditionalmelk(int? id)
        {
            var model = new additionalInfoViewModel();
            model.id = id.Value;
            model.photos = db.photos.Where(x => x.melkId == id).ToList();
            var melk = db.melks.FirstOrDefault(x => x.id == id);
            model.melk = melk;
            if (melk.lon == 0)
                melk.lon = 51.6650002;
            if (melk.lat == 0)
                melk.lat = 32.6707877;
            return View(model);
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
                //return RedirectToAction("AddAditionalmelk", new { id = id });
                return RedirectToAction("melk") ;
            }
            catch (Exception ex)
            {
                return RedirectToAction("AddAditionalmelk", new { id = id });
            }
        }
        public ActionResult LoadmelkData(long? code, string title = "", string tell = "", int page = 1, int pageSize = 10)
        {
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            var query = db.melks.AsQueryable();

            if (title != "")
                query = query.Where(p => p.title.Contains(EntityFunctions.AsUnicode(title)));

            if (tell != "")
                query = query.Where(p => p.tell == tell);
            if (code != null)
                query = query.Where(p => p.code == code);
            var melk = new LoadmelkDataViewModel();
            melk.melks = query.OrderByDescending(p => p.id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            melk.TotalNumber = query.ToList().Count();
            return View(melk);
        }
        [HttpGet]
        public JsonResult Getmelk(int ID)
        {
            var melk = new melk();
            string Message = "False";
            if (ID != 0)
            {
                melk = db.melks.FirstOrDefault(x => x.id == ID);
                Message = "True";
                return Json(melk, Message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(melk, Message, JsonRequestBehavior.AllowGet);
            }
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
        //[HttpPost]
        //public ActionResult DeleteSchedual(int id)
        //{
        //    try
        //    {
        //        var schedule = db.schedules.Find(id);
        //        db.schedules.Remove(schedule);
        //        db.SaveChanges();
        //        return Json("Done");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("Failed");
        //    }
        //}
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
        public async Task<ActionResult> Acceptmelk(int ID, EnumStatus status, string confirmDescription)
        {
            try
            {
                var melk =await db.melks.FindAsync(ID);
                melk.status = status;
                melk.confirmDescription = confirmDescription;
                await  db.SaveChangesAsync();
                return Json("Done");
            }
            catch (Exception ex)
            {
                return Json("Failed");
            }
        }
        [HttpPost]
        public string SendMelkToWhatsApp(int ID)
        {
                var melk = db.melks.Find(ID);
            
            var description =  melk.title+"\n"+ "مشاور املاک آریا:09139200042" + "\n" + "تاریخ ایجاد:" + melk.pCreateDate + "\n" + "کد ملک:" + melk.code + "\n" + "متراژ:" + melk.metraj + "\n" + "تعداد اتاق:" + melk.roomCount + "\n" + "تعداد طبقه:" + melk.floorCount + "\n" + "آدرس:" + melk.address ;

                        if (!String.IsNullOrWhiteSpace(melk.priceRahn.ToString()))
                        {
                            description += "\n" + "قیمت رهن:" + String.Format("{0:0,0}",melk.priceRahn);
                            description += "\n" + "قیمت اجاره:" + String.Format("{0:0,0}", melk.price);
                        }
                        else
                        {
                            description += "\n" + "قیمت:" + String.Format("{0:0,0}", melk.price);
                        }
                        if (!String.IsNullOrWhiteSpace(melk.sanad.ToString()))
                        {
                            string sanadKind = "";
                            switch(melk.sanad)
                            {
                                case EnumSanad.Aady:
                                    sanadKind = "عادی";
                                    break;
                                    case EnumSanad.Mosha:
                                    sanadKind = "مشاع";
                                    break;
                                    case EnumSanad.ShishDong:
                                    sanadKind = "شش دانگ";
                                    break;

                            }
                            description += "\n" + "نوع سند:" + sanadKind;
                        }
                         description += "\n" + "توضیحات:" + melk.description;
            return description;

        }
        

        #endregion

        #region UserRegion
        [Authorize(Roles = "Admin")]

        public ActionResult UserView()
        {
            var model = new UpdateProfileViewModel();
            model.Users = db.Users.Where(p => p.role.RoleNameEn == "Member").ToList();
            return View(model);
        }
        public ActionResult LoadUserData(string mobile = "", string family = "", string name = "", int page = 1, int pageSize = 10)
        {
            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            var query = db.Users.Include("role").Where(p => p.role.RoleNameEn == "Member").AsQueryable();
            if (mobile != "")
                query = query.Where(p => p.mobile == mobile);
            if (family != "")
                query = query.Where(p => p.family.Contains(EntityFunctions.AsUnicode(family)));
            if (name != "")
                query = query.Where(p => p.name.Contains(EntityFunctions.AsUnicode(name)));
            var model = new LoadUserDataViewModel();
            model.Users = query.OrderByDescending(p => p.id).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            model.TotalNumber = query.ToList().Count();
            return View(model);

        }

        [HttpGet]
        public JsonResult GetUser(int ID)
        {
            var User = new user();
            string Message = "False";
            if (ID != 0)
            {
                User = db.Users.FirstOrDefault(x => x.id == ID);
                Message = "True";
                return Json(User, Message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(User, Message, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion







    }
}