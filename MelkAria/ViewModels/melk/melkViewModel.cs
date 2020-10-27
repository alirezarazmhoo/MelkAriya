using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MelkAria.Models;

namespace MelkAria.ViewModels.melk
{
    public class melkViewModel
    {
        public int id { get; set; }

        public List<Models.city> citys { get; set; }
        public List<Models.melkstatus> melkstatuss { get; set; }
        public int statusKind { get; set; }

        public List<Models.user> users { get; set; }
        //[Display(Name = "حیاط دارد")]

        //public bool isYard { get; set; }
        [Display(Name = "نوع سند")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public EnumMelkKind kind { get; set; }
        //[Display(Name = "نوع ملک")]
        //[Required(ErrorMessage = "ورود {0} الزامی است")]

        //public EnumMelkStatusKind statusKind { get; set; }
        [Display(Name = "قیمت")]
        //[Required(ErrorMessage = "ورود {0} الزامی است")]

        public long? price { get; set; }
        [Display(Name = "متراژ")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public double metraj { get; set; }
        [Display(Name = "تعداد اتاق")]

        public int? roomCount { get; set; }
         [Display(Name = "سال ساخت به صورت 1990")]

        public int? yearProduce { get; set; }
        [Display(Name = "تعداد طبقات")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public int floorCount { get; set; }
        //[MaxLength(200)]
        [Display(Name = "نوع پارکینگ")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 200 کاراکتر باشد")]

        public string parkingKind { get; set; }
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 200 کاراکتر باشد")]

        [Display(Name = "نوع سقف")]

        public string cellingKind { get; set; }
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 200 کاراکتر باشد")]

        [Display(Name = "نوع کفپوش")]

        public string floorKind { get; set; }
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 200 کاراکتر باشد")]

        [Display(Name = "نوع گرمایش")]

        public string heatingKind { get; set; }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public int cityId { get; set; }
        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public int userId { get; set; }
        [MaxLength(1000, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 1000 کاراکتر باشد")]


        [Display(Name = "توضیحات")]

        public string description { get; set; }

        public double lon { get; set; }
        public double lat { get; set; }
        [MaxLength(11, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 11 کاراکتر باشد")]

        [Display(Name = "تلفن")]

        public string tell { get; set; }
        [Display(Name = "عنوان متن آگهی")]
        [MinLength(2, ErrorMessage = "فیلد {0} نمی تواند کمتر از 2 کاراکتر باشد")]

        //[MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 200 کاراکتر باشد")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public string title { get; set; }
        [Display(Name = "آدرس")]
        [MaxLength(500, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 500 کاراکتر باشد")]

        public string address { get; set; }
        [MaxLength(70, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 500 کاراکتر باشد")]

        [Display(Name = "عکس")]
        public string imageUrl { get; set; }
        [Display(Name = "تلفن همراه")]
        [StringLength(11, ErrorMessage = "فیلد {0} باید 11 کاراکتر باشد")]
        [Required(ErrorMessage = "ورود {0} الزامی است")]

        public string usermobile { get; set; }
        public EnumStatus status { get; set; }
        [Display(Name = "دلیل رد")]

        public string confirmDescription { get; set; }
        [Display(Name = "انشعابات")]

        public string ensheabat { get; set; }
        [Display(Name = "کد")]

        public long code { get; set; }
        public bool IsRahn { get; set; }
        //قیمت رهن
        [Display(Name = "قیمت")]
        //[Required(ErrorMessage = "ورود {0} الزامی است")]
        public long? priceRahn { get; set; }
        [Display(Name = "توافقی")]
        public bool? Tavafoghi { get; set; }
        [Display(Name = "قابل تبدیل")]
        public bool? Ghabeletabdil { get; set; }
        [Display(Name = "نوع سند")]
        public EnumSanad? sanad { get; set; }

        [Display(Name = "دارای آسانسور")]
        public bool IsElevator { get; set; }
        [Display(Name = "دارای پارکینگ")]
        public bool IsParking { get; set; }
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از 200 کاراکتر باشد")]
        [Display(Name = "نوع سرمایشی")]
        public string CoolKind { get; set; }
        public bool Isswimmingpool { get; set; }
        public bool IsJacuzzi { get; set; }
        [Display(Name = "نوع اسکلت")]
        public string Skeletontype { get; set; }
        [Display(Name = "قیمت هر متراژ")]
        public long? Pricepersquaremeter { get; set; }
    }
}