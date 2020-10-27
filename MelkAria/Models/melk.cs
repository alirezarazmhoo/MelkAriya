using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MelkAria.Models
{
    public enum EnumStatus
    {
        Pending=1,
        Accept=2,
        NotAccept=3,
    }
    public enum EnumMelkKind
    {
        Tejari=1,
        Edari=2,
        Maskooni=3,
        Apartment=4,
        Zamin=5,
        Sanati=6,
        Keshavarzi=7
    }
    public enum EnumSanad
    {
        ShishDong=1,
        Mosha=2,
        Aady=3
    }
    //public enum EnumMelkStatusKind
    //{
    //    RahnAndEjare=1,
    //    Rahn=2,
    //    Foroosh=3
    //}
   
    public class melk
    {
        public int id { get; set; }
        //[ForeignKey("city")]
        //public int cityId { get; set; }
        //public virtual city city { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public virtual user user { get; set; }
        // [ForeignKey("melkstatus")]
        //public int statusKind { get; set; }
        //public virtual  melkstatus melkstatus{ get; set; }

        public DateTime createDate { get; set; }
        [MaxLength(20)]
        public string pCreateDate { get; set; }
        //public bool isYard { get; set; }
        public EnumMelkKind kind { get; set; }
        //public EnumMelkStatusKind statusKind { get; set; }
        //قیمت اجاره اگر در حالت رهن و اجاره باشه اگه در حالت فروش باشه فقط قیمت فروش
        public long? price { get; set; }
        public double metraj { get; set; }
        public int? roomCount { get; set; }
        public int? yearProduce { get; set; }
        public int floorCount { get; set; }
        [MaxLength(200)]
        public string parkingKind { get; set; }
        [MaxLength(200)]
        public string cellingKind { get; set; }
        [MaxLength(200)]
        public string floorKind { get; set; }
        [MaxLength(200)]
        public string heatingKind { get; set; }
        public EnumStatus status { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        [MaxLength(11)]
        public string tell { get; set; }
        [MaxLength(200)]
        public string title { get; set; }
        [MaxLength(500)]
        public string address { get; set; }
        [MaxLength(70)]
        public string imageUrl { get; set; }
        [MaxLength(1000)]
        public string confirmDescription { get; set; }
        public int? ViewCount { get; set; }
        
        public long code { get; set; }
         [MaxLength(200)]
        public string ensheabat { get; set; }
        public bool IsRahn { get; set; }
        public bool? Tavafoghi { get; set; }
        public bool? Ghabeletabdil { get; set; }
        public EnumSanad? sanad { get; set; }
        //قیمت رهن
        public long? priceRahn { get; set; }
        public bool IsElevator { get; set; }
        public bool IsParking { get; set; }
        public string CoolKind { get; set; }
        public bool Isswimmingpool { get; set; }
        public bool IsJacuzzi { get; set; }
        public string Skeletontype { get; set; }
        public long? Pricepersquaremeter { get; set; }



    }
}