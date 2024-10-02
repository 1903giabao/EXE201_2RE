using EXE201_2RE_API.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EXE201_2RE_API.Models
{
    public class EXE201Context : DbContext
    {
        public EXE201Context() { }
        public EXE201Context(DbContextOptions<EXE201Context> options) : base(options)
        {
        }

        #region DbSet

        public DbSet<TblCart> tblCarts { get; set; }
        public DbSet<TblCartDetail> tblCartDetails { get; set; }
        public DbSet<TblCategory> tblCategories { get; set; }
        public DbSet<TblFavorite> tblFavorites { get; set; }
        public DbSet<TblGenderCategory> tblGenderCategories { get; set; }
        public DbSet<TblOrderHistory> tblOrderHistories { get; set; }
        public DbSet<TblProduct> tblProducts { get; set; }
        public DbSet<TblReview> tblReviews { get; set; }
        public DbSet<TblRole> tblRoles { get; set; }
        public DbSet<TblSize> tblSizes { get; set; }
        public DbSet<TblUser> tblUsers { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=EXE201;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TblRole>().HasData(
                new TblRole { RoleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), Name = "User" },
                new TblRole { RoleId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), Name = "Admin" }
            );

            modelBuilder.Entity<TblUser>().HasData(
                new TblUser { UserId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), Username = "user1", Password = SecurityUtil.Hash("12345"), Email = "user1@gmail.com", Address = "address",
                PhoneNumber = "0909123456", RoleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), IsShopOwner = true, ShopName = "shop1", ShopAddress = "shop1address",
                ShopDescription = "shop1des", ShopLogo = "shop1logo", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },

                new TblUser { UserId = new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), Username = "admin", Password = SecurityUtil.Hash("12345"), Email = "admin@gmail.com", Address = "address",
                PhoneNumber = "0912398765", RoleId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), IsShopOwner = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            modelBuilder.Entity<TblCategory>().HasData(
                new TblCategory { CategoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), Name = "T-Shirts" },
                new TblCategory { CategoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), Name = "Jeans" },
                new TblCategory { CategoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), Name = "Jackets" }
            );

            modelBuilder.Entity<TblGenderCategory>().HasData(
                new TblGenderCategory { GenderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), Name = "Male" },
                new TblGenderCategory { GenderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), Name = "Female" }
            );

            modelBuilder.Entity<TblSize>().HasData(
                new TblSize { SizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), SizeName = "S" },
                new TblSize { SizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), SizeName = "M" },
                new TblSize { SizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), SizeName = "L" },
                new TblSize { SizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), SizeName = "XL" }
            );
        }
    }
}
