using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Cart
    {
        public Guid IdCart { get; set; }
        public Guid IdUser { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public User? User { get; set; }  = new User();
        public ICollection<CartDetail>? cartDetails { get; set; }  = new List<CartDetail>();
    }
}
