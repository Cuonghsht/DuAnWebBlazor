using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Cart
    {
        public Guid IdCart { get; set; }
        public Guid IdUser { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public ICollection<CartDetail>? cartDetails { get; set; }
        public Cart()
        {
            cartDetails = new List<CartDetail>();
        }
    }
}
