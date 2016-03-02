namespace WXQuestionnaire.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WXQuestionnaire.Model.Admin;

    public partial class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Stat> Stats { get; set; }
    }
}
