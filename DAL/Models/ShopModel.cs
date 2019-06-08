namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopModel : DbContext
    {
        public ShopModel()
            : base("name=ShopModelConnection")
        {
        }

        public virtual DbSet<Category> Category { get; set; }       //was Categories
        public virtual DbSet<Good> Good { get; set; }           //was Goods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>()
                .Property(e => e.GoodName)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.ShortDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Good>()
                .Property(e => e.GoodCount)
                .HasPrecision(18, 3);
        }
    }
}
