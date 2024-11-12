using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.Model
{
    public class Pay
    {
        public int IdPay { get; set; }
        public string NamePay { get; set; }
        public ICollection<Bill>? Bills { get; set; } =  new List<Bill>();
    }
}
