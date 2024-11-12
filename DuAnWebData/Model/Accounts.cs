using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Accounts
    {
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountPass { get; set; }
        public int RoleId { get; set; }
        public Role? role { get; set; }  = new Role();
        public User? user { get; set; } = new User();
    }
}
