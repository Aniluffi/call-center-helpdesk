using CallCenterHelpdesk.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Configs
{
    public class MailOptionConfig : IEntityTypeConfiguration<MailOption>
    {
        public void Configure(EntityTypeBuilder<MailOption> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Owner)
                .WithMany(c => c.MailOptions)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
