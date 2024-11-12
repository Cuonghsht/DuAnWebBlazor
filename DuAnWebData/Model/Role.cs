using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Role
    {
        public int IdRole { get; set; }
        public string? NameRole { get; set; }
        public ICollection<Accounts>? Accounts { get; set; } = new List<Accounts>();
    }
}
