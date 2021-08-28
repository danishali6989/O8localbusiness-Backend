using UserManagement.DataLayer.EntityConfigurations;
using UserManagement.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.DataLayer
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }


        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<LoginModule> LoginModule { get; set; }
        public DbSet<UserScreenAccess> UserScreenAccess { get; set; }
        public DbSet<ScreenDetail> ScreenDetail { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<EmailSetting> EmailSetting { get; set; }

        public DbSet<LogRecord> LogRecord { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new LoginModuleConfiguration());
            modelBuilder.ApplyConfiguration(new UserScreenAccessConfiguration());
            modelBuilder.ApplyConfiguration(new ScreenDetailConfiguration());
            modelBuilder.ApplyConfiguration(new LanguagesConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new FieldConfiguration());
            modelBuilder.ApplyConfiguration(new EmailSettingConfiguration());
            modelBuilder.ApplyConfiguration(new LogRecordConfiguration());




        }
    }
}
