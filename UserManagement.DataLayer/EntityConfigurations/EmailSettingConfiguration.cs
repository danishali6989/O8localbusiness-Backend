using UserManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManagement.DataLayer.EntityConfigurations
{
    public class EmailSettingConfiguration: IEntityTypeConfiguration<EmailSetting>
    {
        public void Configure(EntityTypeBuilder<EmailSetting> builder)
        {

            builder.ToTable("EmailSetting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.CompanyId).IsRequired(false);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.password).IsRequired();
            builder.Property(x => x.Portnumber).IsRequired();
            builder.Property(x => x.SmtpNo).IsRequired();
            builder.Property(x=> x.DeletedBy).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.UpdatedOn).IsRequired(false);
            builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(40);
          





        }

       
    }
}
