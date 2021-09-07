using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Entities;

namespace UserManagement.DataLayer.EntityConfigurations
{
    class RolePermisionConfiguration :IEntityTypeConfiguration<RolePermi>
    {
            public void Configure(EntityTypeBuilder<RolePermi> builder)
        {
            builder.ToTable("RolePermission");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.Companyid).IsRequired();
            builder.Property(x => x.Pid).IsRequired();
            builder.Property(x => x.Roleid).IsRequired();

            builder.HasOne(x => x.Permi).WithMany().HasForeignKey(x => x.Pid);
            builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.Roleid);

        }
    
    }
}
