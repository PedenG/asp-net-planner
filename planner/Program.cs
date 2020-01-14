using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using planner.Models;

namespace planner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("https://*:16550");
    }

    public class AspDbContext : DbContext
    {
        public AspDbContext(DbContextOptions<AspDbContext> options) : base(options)
        {
            
        }

        public DbSet<Organisateur> Organisateurs { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Visisteur> Visisteurs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisateur>().ToTable("Organisateur");
            modelBuilder.Entity<Evenement>().ToTable("Evenement");
            modelBuilder.Entity<Visisteur>().ToTable("Visisteur");
        }
    }
    public class AspDbContextFactory : IDesignTimeDbContextFactory<AspDbContext>
    {
        public AspDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AspDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspCore-Evenement-DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new AspDbContext(optionsBuilder.Options);
        }
    }
}
