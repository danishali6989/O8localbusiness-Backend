// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.DataLayer;

namespace UserManagement.DataLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210903100621_live932021g")]
    partial class live932021g
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UserManagement.DataLayer.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("LastLogOn");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("UserManagement.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("CompanyId");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("UserManagement.Entities.EmailSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("DeletedBy");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Portnumber");

                    b.Property<string>("SmtpNo")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("EmailSetting");
                });

            modelBuilder.Entity("UserManagement.Entities.Field", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("field")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("lang_id");

                    b.Property<int>("screen_id");

                    b.HasKey("id");

                    b.HasIndex("lang_id");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("UserManagement.Entities.Languages", b =>
                {
                    b.Property<int>("lang_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("lang_name")
                        .IsRequired();

                    b.Property<string>("lang_orientation")
                        .IsRequired();

                    b.HasKey("lang_id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("UserManagement.Entities.LogRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("LogRecord");
                });

            modelBuilder.Entity("UserManagement.Entities.LoginModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<int?>("RoleId");

                    b.Property<int>("Status");

                    b.Property<int>("UserId");

                    b.Property<DateTime?>("createdOn");

                    b.Property<bool?>("status1");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginModule");
                });

            modelBuilder.Entity("UserManagement.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Company_Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Permission_Description")
                        .IsRequired();

                    b.Property<string>("Permissions")
                        .IsRequired();

                    b.Property<int>("ScreenId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<DateTime>("updatedDate");

                    b.HasKey("Id");

                    b.HasIndex("Company_Id");

                    b.HasIndex("ScreenId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("UserManagement.Entities.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Per_Id")
                        .IsRequired();

                    b.Property<int?>("Role_id")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Per_Id");

                    b.HasIndex("Role_id");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("UserManagement.Entities.ScreenDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ScreenCode")
                        .IsRequired();

                    b.Property<string>("ScreenName")
                        .IsRequired();

                    b.Property<string>("ScreenUrl")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("ScreenDetail");
                });

            modelBuilder.Entity("UserManagement.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("App_id");

                    b.Property<int>("CompanyId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Finance_year");

                    b.Property<string>("Ip_Address")
                        .IsRequired();

                    b.Property<int?>("LangId");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("Mobile")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("Usr_FName")
                        .IsRequired();

                    b.Property<string>("Usr_LName")
                        .IsRequired();

                    b.Property<string>("image");

                    b.Property<int>("otp");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LangId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserManagement.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("UserManagement.Entities.UserScreenAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanAccess");

                    b.Property<int>("CompanyId");

                    b.Property<int?>("RoleId");

                    b.Property<int>("ScreenId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("ScreenId");

                    b.ToTable("UserScreenAccess");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UserManagement.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UserManagement.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManagement.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UserManagement.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManagement.Entities.EmailSetting", b =>
                {
                    b.HasOne("UserManagement.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("UserManagement.Entities.Field", b =>
                {
                    b.HasOne("UserManagement.Entities.Languages", "Language")
                        .WithMany()
                        .HasForeignKey("lang_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManagement.Entities.LoginModule", b =>
                {
                    b.HasOne("UserManagement.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManagement.Entities.Permission", b =>
                {
                    b.HasOne("UserManagement.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManagement.Entities.ScreenDetail", "Screen")
                        .WithMany()
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManagement.Entities.RolePermission", b =>
                {
                    b.HasOne("UserManagement.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("Per_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManagement.Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("Role_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManagement.Entities.User", b =>
                {
                    b.HasOne("UserManagement.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManagement.Entities.Languages", "Language")
                        .WithMany()
                        .HasForeignKey("LangId");

                    b.HasOne("UserManagement.Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManagement.Entities.UserScreenAccess", b =>
                {
                    b.HasOne("UserManagement.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("UserManagement.Entities.ScreenDetail", "Screen")
                        .WithMany()
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
