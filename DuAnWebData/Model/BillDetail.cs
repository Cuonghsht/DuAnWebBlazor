using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class BillDetail
    {
        public Guid IdBillDetail { get; set; }
        public Guid IdBill { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public Guid IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public Bill? Bill { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
        public BillDetail()
        {
            
        }
    }
}
