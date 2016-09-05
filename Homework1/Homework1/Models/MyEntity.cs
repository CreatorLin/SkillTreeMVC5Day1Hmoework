using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace Homework1.Models
{
    public class MyDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public MyDbContext() : this("MyEntity") { }
        public MyDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public virtual DbSet<AccountBook> AccountBooks { get; set; }

        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(new DbInitializer());
        }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region IdentityDbContext.OnModelCreating
            //Link:https://aspnetidentity.codeplex.com/SourceControl/latest#src/Microsoft.AspNet.Identity.EntityFramework/IdentityDbContext.cs
            // Needed to ensure subclasses share the same table
            var user = modelBuilder.Entity<User>();
            //.ToTable("AspNetUsers");
            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));

            // CONSIDER: u.Email is Required if set on options?
            user.Property(u => u.Email).HasMaxLength(256);

            modelBuilder.Entity<UserRole>()
                .HasKey(r => new { r.UserId, r.RoleId });
            //.ToTable("UserRoles");

            modelBuilder.Entity<UserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            //.ToTable("UserLogins");

            modelBuilder.Entity<UserClaim>();
            //.ToTable("UserClaims");

            var role = modelBuilder.Entity<Role>();
            //.ToTable("Roles");
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);

            #endregion
        }
    }
}