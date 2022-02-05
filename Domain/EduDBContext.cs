using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Domain
{
    public class EduDBContext : IdentityDbContext
    {
        private readonly string connString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DbConnection");

        public EduDBContext() { }
        public EduDBContext(DbContextOptions<EduDBContext> options) : base(options) { }

        #region Table 
       // public DbSet<DxNotificationSettings> DxNotificationSettings { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
