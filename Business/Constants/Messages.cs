using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string RentalAdded = "Araç Kiralandı";
        public static string RentalUpdated="Araç Kiralama Güncellendi";
        public static string RentalListed = "Kiralık Araçlar Listelendi";
        public static string RentalDeleted = "Kiralık Araç Silindi";

        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarNotDelivered = "Araç Teslim edilmedi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandUse = "Marka Kullanıldığı için Silinemez";

        public static string CarAdded="Araç Eklendi";
        public static string CarDeleted="Araç Silindi";
        public static string CarUpdated="Araç Güncellendi";

        public static string ColorAdded="Renk Eklendi";
        public static string ColorDeleted="Renk Silindi.";
        public static string ColorUpdated="Renk Güncellendi";
        public static string ColorUse= "Renk Kullanıldığı için Silinemez";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerNot = "Bu kullanıcı bilgisi olmadığı için müşteri olamaz";

        public static string UserAdded="Kullanıcı Eklendi";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string UserUpdated="Kullanıcı Güncellendi";
        public static string UserUse="Kullanıcı müşterimiz olduğu için silinemez";
    }
}
