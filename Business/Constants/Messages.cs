using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Kayıt eklendi.";
        public static string ValidationError = "Kayıt belirtilen kurallara uygun olmnadığı için işlem başarısız.";
        public static string Deleted = "Kayıt silindi.";
        public static string Updated = "Kayıt güncellendi.";
        public static string Listed = "Kayıtlar listelendi.";
        public static string NoData = "Sistemde böyle bir kayıt bulunamadı.";
        public static string DefaultError = "İşlem gerçekleştirilirken bir hata ile karşılaşıldı." +
            " Daha sonra tekrar deneyiniz.";
        public static string ErrorForColourAdded = "Renk 2 karakterden kısa olamaz.";
        public static string ZeroListedData = "Listelenebilecek veri bulunmamaktadır.";
        public static string ErrorForBrandAdded ="Brand 2 karakterden küçük olamaz.";
        public static string DeliverCarBack = "Araç teslim alındı. Tekrar kiralama yapılabilir durumda";
        public static string CantRentThisCar = "Bu araç zaten kiralık durumdadır. Teslim edilmeden kiralama işlemi yapılamaz.";
        public static string GetDataById = "Verilen Id ye ait dataya başarıyla ulaşıldı.";
        internal static string CarImageLimitError ="Bir araç için maximum 5 görsel eklenebilir.";
        internal static string DefaultImage;
        internal static string RegisterSuccessForIndividualCustomer;
        internal static string UserAlreadyExist = "Böyle bir kullanıcı zaten var.";
        internal static string UserNotExist ="Böyle bir kullanıcı yok";
        public static string TokenCreated = "Token üretildi.";
    }
}
