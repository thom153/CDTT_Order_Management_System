using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Order_Management_System
{
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<table> tables { get; set; }
        public virtual DbSet<tblDetail> tblDetails { get; set; }
        public virtual DbSet<tblMain> tblMains { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<staff>()
                .Property(e => e.sPhone)
                .IsFixedLength();

            modelBuilder.Entity<tblMain>()
                .Property(e => e.aTime)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.upass)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.uName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.uphone)
                .IsUnicode(false);
        }
    }
}
