using UserManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DataLayer.EntityConfigurations
{
    public class ScreenDetailConfiguration : IEntityTypeConfiguration<ScreenDetail>
    {
        public void Configure(EntityTypeBuilder<ScreenDetail> builder)
        {
            builder.ToTable("ScreenDetail");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.ScreenName).IsRequired();

            builder.Property(x => x.ScreenCode).IsRequired();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}

