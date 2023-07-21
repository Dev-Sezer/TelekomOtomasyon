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
    public class AllTableMap : CoreMap<AllTable>
    {
        public override void Configure(EntityTypeBuilder<AllTable> builder)
        {
            builder.Property(x => x.CustomerName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.CustomerSurname).HasMaxLength(50).IsRequired(true);
        }
    }
}
