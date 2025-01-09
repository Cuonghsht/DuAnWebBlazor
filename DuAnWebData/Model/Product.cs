using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public Guid Iduser { get; set; }
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Quantity { get; set; }
        public string DescriptionProduct { get; set; }
        public bool Status { get; set; } = false;
        public string Image { get; set; }
        [JsonIgnore]
        public ICollection<CartDetail>? CartDetail { get; set; }
        [JsonIgnore]
        public ICollection<BillDetail>? BillDetais { get; set; }  
        public Product()
        {
            CartDetail = new List<CartDetail>();
            BillDetais = new List<BillDetail>();
        }
    }
}
