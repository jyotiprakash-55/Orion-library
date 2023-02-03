using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Orion_library.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AppUserRecord> AppUserRecords { get; set; }
        public virtual DbSet<LibraryRecord> LibraryRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
