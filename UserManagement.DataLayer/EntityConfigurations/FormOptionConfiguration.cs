using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.DataLayer.EntityConfiguration
{
    class FormOptionConfiguration : IEntityTypeConfiguration<FormOption>
    {
        public void Configure(EntityTypeBuilder<FormOption> builder)
        {
            builder.ToTable("FormOption");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FieldId).IsRequired();
            builder.Property(x => x.FormId).IsRequired();
            builder.Property(x => x.OptionName).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.IsSelected).IsRequired(false);


            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
        }
    }
}
