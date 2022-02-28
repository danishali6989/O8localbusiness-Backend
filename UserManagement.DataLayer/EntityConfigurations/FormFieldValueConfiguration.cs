using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class FormFieldValueConfiguration : IEntityTypeConfiguration<FormFieldValue>
    {
        public void Configure(EntityTypeBuilder<FormFieldValue> builder)
        {
            builder.ToTable("FormFieldValue");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.FormId).IsRequired();
            builder.Property(x => x.FormFieldId).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}
