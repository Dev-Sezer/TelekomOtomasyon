using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomCore.Map;
using TelekomModel.Entities;

namespace TelekomModel.Maps
{
    public class PackageMap : CoreMap<Package>
    {
        public override void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.Property(x => x.PackageName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Contents).HasMaxLength(50).IsRequired(true);
        }
    }
}
