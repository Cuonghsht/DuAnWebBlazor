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
    internal class BillDetailConfig : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.IdBill);
            builder.HasOne(x => x.Product).WithMany(x => x.BillDetais).HasForeignKey(x => x.IdProduct);
        }
    }
}
