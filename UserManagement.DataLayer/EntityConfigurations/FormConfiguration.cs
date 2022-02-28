using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("Form");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.BusinessCategoryId).IsRequired(false);
            builder.Property(x => x.BusinessSubCategoryId).IsRequired(false);
            builder.Property(x => x.UserName).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.MobileNo).IsRequired(false);
            builder.Property(x => x.BusinessName).IsRequired(false);
            builder.Property(x => x.BusinessAlias).IsRequired(false);
            builder.Property(x => x.Email).IsRequired(false);
            builder.Property(x => x.IsClaim).IsRequired();
            builder.Property(x => x.ClaimUserId).IsRequired(false);
            builder.Property(x => x.Otp).IsRequired(false);
            // builder.Property(x => x.PostalCode).IsRequired();
            builder.Property(x => x.Address).IsRequired(false);
            //  builder.Property(x => x.FormData).IsRequired();
            builder.Property(x => x.Postalcode).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}
