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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasOne(x => x.Accounts).WithOne(x => x.user).HasForeignKey<User>(x => x.AccountName).HasPrincipalKey<Accounts>(x => x.AccountName);
        }
    }
}
