using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pz_13_LogAziz
{
    internal class DataBaseContext : DbContext
    {
        public DbSet<Trip> Trip => Set<Trip>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer((new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-MUDCOF5",
                InitialCatalog = "aero",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            }).ConnectionString);
        }
    }
}
