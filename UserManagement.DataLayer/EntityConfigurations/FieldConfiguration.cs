using UserManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {

            builder.ToTable("Field");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id).ValueGeneratedOnAdd();

            builder.Property(x => x.lang_id).IsRequired();
            builder.Property(x => x.field).IsRequired().HasMaxLength(500);
            builder.Property(x => x.description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.screen_id);
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
              builder.HasOne(x => x.Language).WithMany().HasForeignKey(x => x.lang_id);





        }
    }
}
