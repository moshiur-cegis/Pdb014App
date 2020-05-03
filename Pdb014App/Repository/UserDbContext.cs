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
using Pdb014App.Models.UserManage;

namespace Pdb014App.Repository
{
    public class UserDbContext : IdentityDbContext<TblUserRegistrationDetail, IdentityRole, string>
    {
        //public virtual DbSet<UserInfo> UserInfo { get; set; }

        public virtual DbSet<TblUserRegistrationDetail> TblUserRegistrationDetail { get; set; }
        //public virtual DbSet<LookUpUserGroup> LookUpUserGroup { get; set; }


        //LookUpUserBpdbDivision
        //LookUpUserBpdbEmployee
        //LookUpUserContentType
        //LookUpUserPermissionType
        //LookUpUserSecurityQuestion
        //LookUpUsersPermittedContent


        //TblUserGrpWisePermissionDetail
        //TblUserGrpWiseUsersDistribution
        //TblUserLogHistory
        //TblUserProfileDetail

        public virtual DbSet<LookUpUserActivationStatus> UserActivationStatus { get; set; }
        public virtual DbSet<LookUpUserBpdbDivision> UserBpdbDivision { get; set; }
        public virtual DbSet<LookUpUserBpdbEmployee> UserBpdbEmployee { get; set; }
        public virtual DbSet<LookUpUserContentType> UserContentType { get; set; }
        public virtual DbSet<LookUpUserPermissionType> UserPermissionType { get; set; }
        public virtual DbSet<LookUpUserSecurityQuestion> UserSecurityQuestion { get; set; }
        public virtual DbSet<LookUpUsersPermittedContent> UsersPermittedContent { get; set; }


        public virtual DbSet<TblUserGrpWisePermissionDetail> UserGrpWisePermissionDetail { get; set; }
        public virtual DbSet<TblUserGrpWiseUsersDistribution> UserGrpWiseUsersDistribution { get; set; }
        public virtual DbSet<TblUserLogHistory> UserLogHistory { get; set; }
        public virtual DbSet<TblUserProfileDetail> UserProfileDetail { get; set; }


        //public virtual DbSet<IdentityRole> Roles { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<UserInfo>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");

            //modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "UserRoleList"); });

            //modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            //modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            //modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            //modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
            //modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("UserRoleClaim"); });

            modelBuilder.Entity<TblUserRegistrationDetail>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");

            //modelBuilder.Entity<TblUserRegistrationDetail>().ToTable("Users").Property(p => p.UserRegistrationId).HasColumnName("UserId").HasKey<TblUserRegistrationDetail>(u => u.RE);


            //.Entity<TblUserRegistrationDetail>().ToTable("Users").HasKey(i => i.UserRegistrationId); 
                
                
                //.HasForeignKey<TblUserRegistrationDetail>(u => u.UserName)
                //.HasPrincipalKey<Customer>(c => c.UserName);




            //modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "UserRoleList"); });
            modelBuilder.Entity<IdentityRole>().ToTable("UserRoleList").Property(p => p.Id).HasColumnName("RoleId");            


            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("UserRoleClaim"); });


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
