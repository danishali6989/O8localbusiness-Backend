using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
  public  class LanguagesConfiguration : IEntityTypeConfiguration<Languages>
    {
        public void Configure(EntityTypeBuilder<Languages> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(x => x.lang_id);

            builder.Property(x => x.lang_id).ValueGeneratedOnAdd();
            builder.Property(x => x.lang_name).IsRequired();
            builder.Property(x => x.lang_orientation).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}
