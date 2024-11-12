using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
        public string AccountName { get; set; }
        public Accounts? Accounts { get; set; }  = new Accounts();
        public Cart? Cart { get; set; } = new Cart();
        public ICollection<Bill>? bills { get; set; } = new List<Bill>();
    }
}
