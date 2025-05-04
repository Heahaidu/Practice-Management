using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Medicine
    {
        //ID
        public int id { get; set; }
        //Name
        [Display(Name = "Tên thuốc")]
        public string name { get; set; }
        // Nhà sản xuất
        [Display(Name = "Nhà sản xuất")]
        public string manufacturer { get; set; }
        // Loại
        [Display(Name = "Bào chế dạng")]
        public string type { get; set; }
        // Mô tả
        [Display(Name = "Mô tả")]
        public string description { get; set; }
        // Giá
        // Giá khuyến mãi
        [Display(Name = "Giá khuyến mãi")]
        public float discountPrice { get; set; }
        [Display(Name = "Giá")]
        public float price { get; set; }
        // Số lượng
        [Display(Name = "Số lượng")]
        public int quantity { get; set; }
        // Ngày sản xuất
        [Display(Name = "Ngày sản xuất")]
        public DateTime manufacturingDate { get; set; }
        // Hạn sử dụng
        [Display(Name = "Hạn sử dụng")]
        public DateTime expiryDate { get; set; }
        // Ngày nhập
        [Display(Name = "Ngày nhập")]
        public DateTime importDate { get; set; }
        // Cách sử dụng
        [Display(Name = "Cách sử dụng")]
        public string usage { get; set; }
        // Liều lượng
        [Display(Name = "Liều lượng")]
        public string dosage { get; set; }

        public Medicine(int id, string name, string manufacturer, string type, string description, float discountPrice, float price, int quantity, DateTime manufacturingDate, DateTime expiryDate, DateTime importDate, string usage, string dosage)
        {
            this.id = id;
            this.name = name;
            this.manufacturer = manufacturer;
            this.type = type;
            this.description = description;
            this.discountPrice = discountPrice;
            this.price = price;
            this.quantity = quantity;
            this.manufacturingDate = manufacturingDate;
            this.expiryDate = expiryDate;
            this.importDate = importDate;
            this.usage = usage;
            this.dosage = dosage;
        }

        public Medicine(string name, string manufacturer, string type, string description, float discountPrice, float price, int quantity, DateTime manufacturingDate, DateTime expiryDate, DateTime importDate, string usage, string dosage)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.type = type;
            this.description = description;
            this.discountPrice = discountPrice;
            this.price = price;
            this.quantity = quantity;
            this.manufacturingDate = manufacturingDate;
            this.expiryDate = expiryDate;
            this.importDate = importDate;
            this.usage = usage;
            this.dosage = dosage;
        }
    }
}
