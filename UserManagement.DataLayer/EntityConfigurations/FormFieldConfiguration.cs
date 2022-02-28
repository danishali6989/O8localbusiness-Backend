using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class FormFieldConfiguration : IEntityTypeConfiguration<FormField>
    {
        public void Configure(EntityTypeBuilder<FormField> builder)
        {
            builder.ToTable("FormField");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FieldName).IsRequired();
            builder.Property(x => x.FormId).IsRequired();
            builder.Property(x => x.className).IsRequired(false);
            builder.Property(x => x.HelpText).IsRequired(false);
            builder.Property(x => x.Placeholder).IsRequired(false);
            builder.Property(x => x.Required).IsRequired(false);
            builder.Property(x => x.Toggle).IsRequired(false);
            builder.Property(x => x.EnableOther).IsRequired(false);
            builder.Property(x => x.Inline).IsRequired(false);
            builder.Property(x => x.Access).IsRequired(false);
            builder.Property(x => x.SubType).IsRequired(false);
            builder.Property(x => x.Style).IsRequired(false);
            //  builder.Property(x => x.Class).IsRequired(false)
            builder.Property(x => x.Multiple).IsRequired(false);
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.Value).IsRequired(false);
            builder.Property(x => x.Maxlength).IsRequired(false);
            builder.Property(x => x.Rows).IsRequired(false);
            builder.Property(x => x.requireValidOption).IsRequired(false);
            builder.Property(x => x.FormFieldType).IsRequired(false);




            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);

          //  builder.HasOne(x => x.FormBuilderType).WithMany().HasForeignKey(x => x.FormBuilderTypeId);

        }
    }
}
