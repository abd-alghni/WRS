using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WRS.Models;

namespace WRS
{
      public class WRSDbContext : DbContext
      {
            public WRSDbContext(DbContextOptions<WRSDbContext> options)
                : base(options)
            {
            }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Query>().HasKey(x => new { x.ReportId });
  
        }

        public DbSet<DataSource> DataSources { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<QueryParameter> QueryParameters { get; set; }
    }
 }
