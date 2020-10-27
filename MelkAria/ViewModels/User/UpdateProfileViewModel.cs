using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MelkAria.ViewModels.User
{
    public class UpdateProfileViewModel
    {
        public int Id { get; set; }
        [RegularExpression(@"^[\u0600-\u06FF]+$", ErrorMessage = "لطفا نام را فارسی وارد نمایید")]
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [RegularExpression(@"^[\u0600-\u06FF]+$", ErrorMessage = "لطفا نام خانوادگی را فارسی وارد نمایید")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        [Display(Name = "نام خانوادگی")]

        public string Family { get; set; }
        [Display(Name = "کد ملی")]
       [RegularExpression(@"(.{10})", ErrorMessage = "کد ملی باید شامل 10 عدد باشد")]
       
        public string CodeMeli { get; set; }
        
        [Display(Name = "تاریخ تولد")]

        public string BirthDate { get; set; }
         [Display(Name = "روز")]
        [Required(ErrorMessage = "لطفا روز تولد را وارد نمایید")]
       [RegularExpression(@"^[0-9]*$", ErrorMessage = "لطفا روز تولد را به صورت عددی وارد نمایید")]

        
        public string BirthDateDay { get; set; }
         [Display(Name = "ماه")]
        [Required(ErrorMessage = "لطفا ماه تولد را وارد نمایید")]
       [RegularExpression(@"^[0-9]*$", ErrorMessage = "لطفا ماه تولد را به صورت عددی وارد نمایید")]

        public string BirthDateMonth { get; set; }
         [Display(Name = "سال")]
        [Required(ErrorMessage = "لطفا سال تولد را وارد نمایید")]
       [RegularExpression(@"^[0-9]*$", ErrorMessage = "لطفا سال تولد را به صورت عددی وارد نمایید")]

        public string BirthDateYear { get; set; }
        [Required(ErrorMessage = "لطفا شماره شناسنامه را وارد نمایید")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        [Display(Name = "شماره شناسنامه")]
       [RegularExpression(@"^[0-9]*$", ErrorMessage = "لطفا شماره شناسنامه را به صورت عددی وارد نمایید")]

        public string ShomareShenasname { get; set; }
        [Required(ErrorMessage = "لطفا کد پستی را وارد نمایید")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        [Display(Name = "کد پستی")]
       [RegularExpression(@"^[0-9]*$", ErrorMessage = "لطفا کد پستی را به صورت عددی وارد نمایید")]

        public string CodePosti { get; set; }
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        [StringLength(11, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        [Display(Name = "تلفن")]
       [RegularExpression(@"^[0-9]*$", ErrorMessage = "لطفا تلفن را به صورت عددی وارد نمایید")]

        public string Phone { get; set; }
        [RegularExpression(@"(.{11})", ErrorMessage = "تلفن همراه باید شامل 11 عدد باشد")]
       [Required(ErrorMessage ="لطفا تلفن همراه را وارد نمایید")]
        [Display(Name = "تلفن همراه")]

        public string Mobile { get; set; }
        [Required(ErrorMessage = "لطفا آدرس را وارد نمایید")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "تعداد کاراکتر های ورودی از حد مجاز بیشتر است")]
        [Display(Name = "آدرس")]

        public string Address { get; set; }
        [Required(ErrorMessage = "لطفا تصویر کارت ملی را وارد نمایید")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "حجم تصویر ارسالی از 32 مگابایت بیشتر نمیتواند باشد ")]
        [Display(Name = " تصویر کارت ملی")]

        public string CartMeliUpload { get; set; }
        [Required(ErrorMessage = "لطفا تصویر شناسنامه را وارد نمایید")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "حجم تصویر ارسالی از 32 مگابایت بیشتر نمیتواند باشد ")]
        [Display(Name = " تصویر شناسنامه")]

        public string ShenasnameUpload { get; set; }
        [Required(ErrorMessage = "لطفا عکس خود را وارد نمایید")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "حجم عکس ارسالی از 32 مگابایت بیشتر نمیتواند باشد ")]
        [Display(Name = " عکس 3*4")]

        public string ImageUpload { get; set; }
        [Required(ErrorMessage = "لطفا عکس تعهد با امضا را وارد نمایید")]
        [StringLength(70, MinimumLength = 1, ErrorMessage = "حجم عکس ارسالی از 32 مگابایت بیشتر نمیتواند باشد ")]
        [Display(Name = " عکس تعهد")]

        public string ImageTaahod { get; set; }
        
        public bool IsProfileActive { get; set; }
        public bool Status { get; set; }
        [Display(Name = " نام کاربری")]
        
        public string UserNamee { get; set; }
        [Display(Name = "رمز عبور")]

        public string PasswordShow { get; set; }
        [Display(Name = "اضافه کردن زیر مجموعه")]

        public bool IsInsertChild { get; set; }

        public List<Models.user> Users { get; set; }

        public List<Models.melk> melks { get; set; }

    }
}