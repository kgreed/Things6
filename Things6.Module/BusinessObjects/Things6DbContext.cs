using System;
using System.Data;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using SQLite.CodeFirst;

namespace Things6.Module.BusinessObjects {
	public class Things6DbContext : DbContext {
        public Things6DbContext(String connectionString)
            : base(new SQLiteConnection() {ConnectionString = connectionString}, true)
        {
        }

        public Things6DbContext(DbConnection connection)
			: base(connection, false) {
		}
        //public Things6DbContext()
        //	: base("name=ConnectionString") {
        //}

        public Things6DbContext()
            : base(new SQLiteConnection()
            {
                ConnectionString =  System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString
            }, true)
        {
            

        }

        public DbSet<ModuleInfo> ModulesInfo { get; set; }
	    public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<PermissionPolicyTypePermissionObject> TypePermissionObjects { get; set; }
		public DbSet<PermissionPolicyUser> Users { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }

        public DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Things6DbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }

    public class Thing
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}