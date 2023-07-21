using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomCore.Entity;

namespace TelekomCore.Map
{
    public abstract class CoreMap<T> : IEntityTypeConfiguration<T> where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CreateDate).IsRequired(false);
            builder.Property(x => x.UpdateDate).IsRequired(false);
        }
    }
}
