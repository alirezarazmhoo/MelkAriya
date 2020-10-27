using MelkAria.DAL;
using MelkAria.Models;
using MelkAria.Utility;
using MelkAria.ViewModels.melk;
using MelkAria.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MelkAria.Controllers
{
    public enum SendSmsReturnType
    {
        [Description("")]
        None = -10,

        [Description("ارسال با موفقیت انجام شد")]
        SendWasSuccessful = 0,

        [Description("نام کاربر یا کلمه عبور نامعتبر می باشد")]
        InvalidUserNameOrPassword = 1,

        [Description("کاربر مسدود شده است")]
        UserBlocked = 2,

        [Description("شماره فرستنده نامعتبر است")]
        InvalidSenderNumber = 3,

        [Description("محدودیت در ارسال روزانه")]
        LimitationInDailySend = 4,

        [Description("تعداد گیرندگان حداکثر 100 شماره می باشد")]
        LimitationInRecieverCount = 5,

        [Description("خط فرسنتده غیرفعال است")]
        SenderLineIsInactive = 6,

        [Description("متن پیامک شامل کلمات فیلتر شده است")]
        SmsContentFilteredWordsIsIncluded = 7,

        [Description("اعتبار کافی نیست")]
        NoCredit = 8,

        [Description("سامانه در حال بروز رسانی است")]
        SystemBeingUpdated = 9,

        [Description("پیاده سازی نشده است")]
        NotImplemented = 10
    }
    public class UserController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Store(LoginUserViewModel viewModel)
        {
            ModelState.Remove("Captcha");
            if (ModelState.IsValid)
            {
                //if (Session["Captcha"] == null || Session["Captcha"].ToString() != viewModel.Captcha)
                //{
                //    ModelState.Clear();
                //    ModelState.AddModelError("", "کپچا صحیح نمی باشد");
                //    return View("RegisterUser");
                //}
                if (db.Users.Any(p => p.mobile == viewModel.Mobile))
                {
                    //ModelState.AddModelError("", "تلفن همراه تکراری است");
                    TempData["Message"] = "DublicateMobile";
                    return RedirectToAction("Index", "Home");
                }
                role r = db.Roles.Where(p => p.RoleNameEn == "Member").FirstOrDefault();
                var user = new user();
                user.role = r;
                Random random = new Random();
                string password = random.Next(1000, 9999).ToString();
                //string password = viewModel.Password;
                //var UserName = "U" + random.Next(1000, 9999);
                user.passwordShow = password;
                user.password = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(password, DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt());
                user.mobile = viewModel.Mobile;
                user.userNamee = viewModel.Mobile;
                //user.email = viewModel.Email;
                //user.name = viewModel.name;
                //user.family = viewModel.family;
                var sendServiceClient = new com.irpayamak.login.Send();
                var res = sendServiceClient.SendSms("Alisabzevari", "210759",
                     "50002964", new[] { user.mobile },
                 "به املاک اجلاس خوش آمدید" + System.Environment.NewLine + "رمز عبور:" + user.passwordShow, false);
                var persianCalendar = new PersianCalendar();
                var today = DateTime.Today;
                var beforeMonthFromToday = persianCalendar.AddMonths(today, -1);
                db.Users.Add(user);
                db.SaveChanges();
                TempData["Message"] = "Registered";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = "IncorrectInput";
                return RedirectToAction("Index", "Home");

            }
        }
     
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult SignOutAdmin()
        {
            FormsAuthentication.SignOut();

            return Redirect("/User/LoginAdmin");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SignIn(LoginUserViewModel user)
        {
            //if (Session["Captcha"] == null || Session["Captcha"].ToString() != user.Captcha)
            //{
            //    ModelState.Clear();
            //    ModelState.AddModelError("", "کپچا صحیح نمی باشد");
            //    return View("Login");
            //}
            if (user.Password == "" || user.Password == null || user.UserNamee == "" || user.UserNamee == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                //return View("Login");
                return Redirect("/Home/Index");

            }
            var u = db.Users.Include("Role").Where(p => p.userNamee == user.UserNamee).Where(p => p.role.RoleNameEn == "Member").FirstOrDefault();
            if (u == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                //return View("Login");
                return Redirect("/Home/Index");

            }
            if (!DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(user.Password, u.password))
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                //return View("Login");
                return Redirect("/Home/Index");

            }
            //if (u.Status == false)
            //{
            //    ModelState.Clear();
            //    ModelState.AddModelError("", "ورود غیر مجاز");
            //    return View("Login");
            //}

            FormsAuthentication.SetAuthCookie(u.userNamee, false);
            //var url = Request["Url"];
            //if (url != null && url.Trim() != "")
            //{
            //    return Redirect(url);
            //}
            return Redirect("/User/Profile");
        }
        //[Authorize(Roles = "Member")]
        public ActionResult Profile()
        {
            if(User.Identity.IsAuthenticated == false)
            {
                TempData["sessionExpired"] = "لطفا دوباره وارد اکانت خود شوید.";
                return RedirectToAction(nameof(SignOut));
            }
            var userNamee = User.Identity.Name;
            var user = db.Users.Where(p => p.userNamee == userNamee).FirstOrDefault();
            var model = new UpdateProfileViewModel
            {
                Family = user.family,
                Name = user.name,
                Mobile = user.mobile,
            };
            model.melks = db.melks.Where(x => x.userId == user.id).OrderByDescending(x => x.id).ToList();
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Update(UpdateProfileViewModel viewModel)
        //{
        //    var userNamee = User.Identity.Name;
        //    var user = db.Users.Where(p => p.UserNamee == userNamee).FirstOrDefault();
        //    if (!user.IsProfileActive)
        //    {
        //        var img = Request.Files["ImageUpload"];
        //        var img2 = Request.Files["ShenasnameUpload"];
        //        var img3 = Request.Files["CartMeliUpload"];
        //        // var img4 = Request.Files["ImageTaahod"];

        //        if (img == null || img.FileName == "")
        //        {
        //            TempData["Error"] = "عکس 3*4 را انتخاب کنید";
        //            return RedirectToAction("Profile");

        //        }
        //        if (img2 == null || img2.FileName == "")
        //        {
        //            TempData["Error"] = "عکس شناسنامه را انتخاب کنید";
        //            return RedirectToAction("Profile");

        //        }
        //        if (img3 == null || img3.FileName == "")
        //        {
        //            TempData["Error"] = "عکس کارت ملی را انتخاب کنید";
        //            return RedirectToAction("Profile");

        //        }
        //        //if (img4 == null || img4.FileName == "")
        //        //{
        //        //    TempData["Error"] = "عکس تعهد نامه را انتخاب کنید";
        //        //    return RedirectToAction("Profile");

        //        //}

        //        if (db.Users.Any(p => p.Mobile == viewModel.Mobile && p.UserNamee != userNamee))
        //        {
        //            TempData["Error"] = "تلفن همراه تکراری است";
        //            return RedirectToAction("Profile");
        //        }

        //        user.Address = viewModel.Address;
        //        user.Name = viewModel.Name;
        //        user.Family = viewModel.Family;
        //        user.CodePosti = viewModel.CodePosti;
        //        user.CodeMeli = viewModel.CodeMeli;
        //        user.BirthDateDay = viewModel.BirthDateDay;
        //        user.BirthDateYear = viewModel.BirthDateYear;
        //        user.BirthDateMonth = viewModel.BirthDateMonth;
        //        user.Phone = viewModel.Phone;
        //        user.ShomareShenasname = viewModel.ShomareShenasname;

        //        user.Mobile = viewModel.Mobile;
        //        //var name = Guid.NewGuid().ToString().Replace('-', '0') + "." + img.FileName.Split('.')[1];
        //        var name = Guid.NewGuid().ToString().Replace('-', '0') + ".jpg";


        //        var imageUrl = "/Upload/Users/" + name;
        //        string path = Server.MapPath(imageUrl);
        //        img.SaveAs(path);


        //        var name2 = Guid.NewGuid().ToString().Replace('-', '0') + ".jpg";

        //        var imageUrl2 = "/Upload/Users/" + name2;
        //        string path2 = Server.MapPath(imageUrl2);
        //        img2.SaveAs(path2);
        //        var name3 = Guid.NewGuid().ToString().Replace('-', '0') + ".jpg";
        //        var imageUrl3 = "/Upload/Users/" + name3;
        //        string path3 = Server.MapPath(imageUrl3);
        //        img3.SaveAs(path3);

        //        //var name4 = Guid.NewGuid().ToString().Replace('-', '0') + ".jpg";
        //        //var imageUrl4 = "/Upload/Users/" + name4;
        //        //string path4 = Server.MapPath(imageUrl4);
        //        //img4.SaveAs(path4);

        //        user.ImageUpload = imageUrl;
        //        user.ShenasnameUpload = imageUrl2;
        //        user.CartMeliUpload = imageUrl3;
        //        // user.ImageTaahod = imageUrl4;

        //        db.SaveChanges();
        //        return RedirectToAction("Profile");
        //    }
        //    else
        //    {
        //        if (db.Users.Any(p => p.Mobile == viewModel.Mobile && p.UserNamee != userNamee))
        //        {
        //            TempData["Error"] = "تلفن همراه تکراری است";
        //            return RedirectToAction("Profile");
        //        }
        //        user.Mobile = viewModel.Mobile;
        //        db.SaveChanges();
        //        return RedirectToAction("Profile");
        //    }
        //}

        [HttpGet]


        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignInAdmin(LoginUserViewModel user)
        {
            if (Session["Captcha"] == null || Session["Captcha"].ToString() != user.Captcha)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "کپچا صحیح نمی باشد");
                return View("LoginAdmin");
            }
            if (user.Password == "" || user.Password == null || user.UserNamee == "" || user.UserNamee == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("LoginAdmin");
            }
            var u = db.Users.Include("role").Where(p => p.userNamee == user.UserNamee).Where(p => p.role.RoleNameEn == "Admin").FirstOrDefault();
            if (u == null)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("LoginAdmin");
            }
            if (!DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(user.Password, u.password))
            {
                ModelState.Clear();
                ModelState.AddModelError("", "نام کاربری یا رمز عبور صحیح نیست");
                return View("LoginAdmin");
            }


            FormsAuthentication.SetAuthCookie(u.userNamee, false);
            var url = Request["Url"];
            if (url != null && url.Trim() != "")
            {
                return Redirect(url);
            }
            return Redirect("/Admin/Index");
        }

        public ActionResult CaptchaImage(string prefix, bool noisy = true)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            //generate new question 
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            var captcha = string.Format("{0} + {1} = ?", a, b);

            //store answer 
            Session["Captcha" + prefix] = a + b;

            //image stream 
            FileContentResult img = null;

            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                //add noise 
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 10; i++)
                    {
                        pen.Color = Color.FromArgb(
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);

                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }

                //add question 
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);

                //render as Jpeg 
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
            }

            return img;
        }

        public ActionResult RegisterUser()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult RequestCancle()
        //{
        //    try
        //    {
        //        var userNamee = User.Identity.Name;
        //        var user = db.Users.Where(p => p.UserNamee == userNamee).FirstOrDefault();
        //        user.RequestCancle = true;
        //        db.SaveChanges();
        //        return Json("Done");

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json("Failed");
        //    }
        //}

        public ActionResult NewMelk(int? id, bool isRahn)
        {
            var model = new melkViewModel();
            model.IsRahn = isRahn;
            //model.citys = db.cities.ToList();
            //model.melkstatuss = db.melkstatuss.ToList();
            model.lon = 51.6650002;
            model.lat = 32.6707877;
            model.id = 0;
            if (id != null)
            {
                var melk = db.melks.FirstOrDefault(x => x.id == id);
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
                model.IsRahn = melk.IsRahn;
                model.Tavafoghi = melk.Tavafoghi;
                model.sanad = melk.sanad;
                model.Ghabeletabdil = melk.Ghabeletabdil;
                model.Pricepersquaremeter = melk.Pricepersquaremeter;
                model.IsElevator = melk.IsElevator;
                model.IsJacuzzi = melk.IsJacuzzi;
                model.IsParking = melk.IsParking;
                model.Isswimmingpool = melk.Isswimmingpool;
                model.Skeletontype = melk.Skeletontype;
                model.CoolKind = melk.CoolKind;
            }
            return PartialView("NewMelk", model);
        }

    }
}