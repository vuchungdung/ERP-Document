using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERP_Document.Models
{
    public class ERDDbContext : DbContext
    {
        public ERDDbContext() : base("ERPConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public static ERDDbContext Create()
        {
            return new ERDDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}