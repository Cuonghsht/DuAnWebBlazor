using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Bill
    {
        public Guid IdBill { get; set; }
        [Required(ErrorMessage ="khong duoc de trong")]
        public DateTime NgayHoanthanh { get; set; } = DateTime.Now;
        public Guid IdUser { get; set; }
        public int IdPay { get; set; }
        public decimal ToTal { get; set; }
        [JsonIgnore]
        public ICollection<BillDetail>? BillDetails { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public Pay? Pay { get; set; } 
        public Bill()
        {
            BillDetails = new List<BillDetail>();
            
        }
    }
}
