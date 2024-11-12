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
    public class CartDetailConfig : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.IdCartDetail);
            builder.HasOne(x => x.Cart).WithMany(x => x.cartDetails).HasForeignKey(x => x.IdCart);
            builder.HasOne(x => x.Product).WithMany(x => x.CartDetail).HasForeignKey(x => x.Idproduct);
        }
    }
}
