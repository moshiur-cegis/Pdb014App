using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Pdb014App.Models;


namespace Pdb014App.Repository
{
    public class UserDbContext : IdentityDbContext<UserInfo, IdentityRole, string>
    {
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        //public virtual DbSet<IdentityRole> Roles { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInfo>().ToTable("TblUsers").Property(p => p.Id).HasColumnName("UserId");

            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "LookUpRole"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("LookUpUserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("LookUpUserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("LookUpUserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("LookUpRoleClaim"); });
        }

        //public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
        //{
        //    public UserDbContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //            .Build();

        //        var dbConnStr = configuration.GetConnectionString("ConnectionStr");
        //        var optBuilder = new DbContextOptionsBuilder<UserDbContext>();

        //        optBuilder.UseSqlServer(dbConnStr);
        //        return new UserDbContext(optBuilder.Options);
        //    }
        //}
    }
}
