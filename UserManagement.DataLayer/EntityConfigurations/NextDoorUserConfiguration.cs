using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class NextDoorUserConfiguration : IEntityTypeConfiguration<NextDoorUser>
    {
        public void Configure(EntityTypeBuilder<NextDoorUser> builder)
        {
            builder.ToTable("NextDoorUser");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.StreetAdress).IsRequired();
            builder.Property(x => x.ApartmentNo).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Lan).IsRequired();
            builder.Property(x => x.Lat).IsRequired();
            
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            
            
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
            
        }
    }
}
