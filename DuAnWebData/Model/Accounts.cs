using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Accounts
    {
        public Guid AccountId { get; set; }
        [Required(ErrorMessage ="khong duoc de trong Name account")]
        [StringLength(50,MinimumLength =6 ,ErrorMessage ="Ten tai khoan phai dai hon 6 ki tu , it hon 50")]
        public string AccountName { get; set; }
        [Required(ErrorMessage = "khong duoc de trong Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Ten tai khoan phai dai hon 6 ki tu , it hon 50")]
        public string AccountPass { get; set; }
        public int RoleId { get; set; }
        [JsonIgnore]
        public Role? role { get; set; }
        [JsonIgnore]
        public User? user { get; set; } 
        public Accounts()
        {
            
        }
    }
}
