using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Role
    {
        public int IdRole { get; set; }
        public string? NameRole { get; set; }
        [JsonIgnore]
        public ICollection<Accounts>? Accounts { get; set; } 
        public Role()
        {
            Accounts = new List<Accounts>();
        }
    }
}
