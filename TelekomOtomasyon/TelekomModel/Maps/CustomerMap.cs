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
    public class CustomerMap : CoreMap<Customer>
    {

        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Tc).HasMaxLength(11).IsRequired(true);
        }

    }
}
