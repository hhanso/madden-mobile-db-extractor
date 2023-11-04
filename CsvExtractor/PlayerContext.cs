using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CsvExtractor
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(this.GetConnectionString());

        private string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-3U43T74\\SQLEXPRESS",
                InitialCatalog = "madden_mobile_24_players",
                UserID = Environment.GetEnvironmentVariable("DBUSERNAME"),
                Password = Environment.GetEnvironmentVariable("DBPASSWORD"),
                IntegratedSecurity = false,
                Encrypt = false,
            };
            return builder.ConnectionString;
        }
    }
}
