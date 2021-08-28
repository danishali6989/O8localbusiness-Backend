using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class LogRecordConfiguration : IEntityTypeConfiguration<LogRecord>
    {
        public void Configure(EntityTypeBuilder<LogRecord> builder)
        {

            builder.ToTable("LogRecord");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(500);

            builder.Property(x => x.CreatedOn).IsRequired();


            builder.Property(x => x.UpdatedOn).IsRequired(false);


        }
    }
}
