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
    public class APIOptionConfig : IEntityTypeConfiguration<APIOption>
    {
        public void Configure(EntityTypeBuilder<APIOption> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Owner)
                .WithMany(c => c.APIOptions)
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
