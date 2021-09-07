using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class PermiConfiguration : IEntityTypeConfiguration<Permi>
    {
        public void Configure(EntityTypeBuilder<Permi> builder)
        {
            builder.ToTable("Permi");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Permisions).IsRequired();
            builder.Property(x => x.Permision_Description).IsRequired();
            builder.Property(x => x.Compny_Id).IsRequired();
            builder.Property(x => x.ScrenId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false); //  builder.Property(x => x.updatedDate).IsRequired(false);

            builder.HasOne(x => x.Screen).WithMany().HasForeignKey(x => x.ScrenId);
            builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.Compny_Id);

        }
    }
}
