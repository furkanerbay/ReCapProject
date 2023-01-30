using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string ErrorCarAdded = "Araba eklenmesi hatali.";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba guncellendi.";

        public static string BrandAdded = "Yeni marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka guncellendi.";
        public static string BrandGetAll = "Tum markalar listelendi.";
        public static string BrandGetById = "Istenilen id'nin marka datalari listelendi.";

        public static string ColorAdded = "Yeni renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk guncellendi.";
        public static string ColorGetAll = "Tum renkler listelendi.";
        public static string ColorGetById = "Istenilen id'nin renk datalari listelendi.";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
