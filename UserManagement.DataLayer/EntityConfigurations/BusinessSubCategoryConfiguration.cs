using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class BusinessSubCategoryConfiguration : IEntityTypeConfiguration<BusinessSubCategory>
    {
        public void Configure(EntityTypeBuilder<BusinessSubCategory> builder)
        {
            builder.ToTable("BusinessSubCategory");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BusinessCategoryId).IsRequired();

            builder.Property(x => x.BusinessSubCategoryName).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
        }
    }
}
