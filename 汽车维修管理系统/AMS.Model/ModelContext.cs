using System.Data.Entity.ModelConfiguration.Conventions;
using AMS.Model.poco;

namespace AMS.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=AmsSqlConn")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
    }
}