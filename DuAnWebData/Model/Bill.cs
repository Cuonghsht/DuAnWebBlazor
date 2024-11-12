using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Bill
    {
        public Guid IdBill { get; set; }
        public DateTime NgayHoanthanh { get; set; } = DateTime.Now;
        public Guid IdUser { get; set; }
        public int IdPay { get; set; }
        public decimal ToTal { get; set; }
        public ICollection<BillDetail>? BillDetails { get; set; } = new List<BillDetail>();
        public User? User { get; set; } = new User();
        public Pay? Pay { get; set; } = new Pay();
    }
}
