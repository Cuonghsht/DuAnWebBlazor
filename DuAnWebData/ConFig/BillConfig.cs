using DuAnWebData.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnWebData.ConFig
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.IdBill);
            builder.HasOne(x => x.User).WithMany(x => x.bills).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.Pay).WithMany(x => x.Bills).HasForeignKey(x => x.IdPay);
        }
    }

}

