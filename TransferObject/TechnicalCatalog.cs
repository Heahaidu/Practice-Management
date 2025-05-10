using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransferObject
{
    public class TechnicalCatalog
    {
        //ID
        [Browsable(false)]
        public int id { get; set; }
        // Loại
        [Display(Name = "Loại")]
        public string type { get; set; }
        // Tên chỉ định
        [Display(Name = "Tên chỉ định")]
        public string name { get; set; }
        // Giá
        [Display(Name = "Giá")]
        public float price { get; set; }
        // Giá khuyến mãi
        [Display(Name = "Giá khuyến mãi")]
        public float discountPrice { get; set; }
        // Mô tả
        [Display(Name = "Mô tả")]
        public string description { get; set; }

        public TechnicalCatalog(string type, string name, float price, float discountPrice, string description)
        {
            this.type = type;
            this.name = name;
            this.price = price;
            this.discountPrice = discountPrice;
            this.description = description;
        }

        public TechnicalCatalog(int id, string type, string name, float price, float discountPrice, string description)
        {
            this.id = id;
            this.type = type;
            this.name = name;
            this.price = price;
            this.discountPrice = discountPrice;
            this.description = description;
        }

    }
}
