using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class CartDetail
    {
        public int IdCartDetail { get; set; }
        public Guid IdCart { get; set; }
        public Guid Idproduct { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime NgayThemVao { get; set; }
        [JsonIgnore]
        public Cart? Cart { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }  
        public CartDetail()
        {
        }
    }
}
