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

      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=EXE201;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TblRole>().HasData(
                new TblRole { roleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), name = "User" },
                new TblRole { roleId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), name = "Admin" }
            );

            modelBuilder.Entity<TblUser>().HasData(
                new TblUser { userId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), userName = "user1", passWord = SecurityUtil.Hash("12345"), email = "user1@gmail.com", address = "address",
                phoneNumber = "0909123456", roleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), isShopOwner = true, shopName = "shop1", shopAddress = "shop1address",   
                shopDescription = "shop1des", shopLogo = "shop1logo", createdAt = DateTime.Now, updatedAt = DateTime.Now },                                                    
                                                                                                                                                                               
                new TblUser { userId = new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), userName = "admin", passWord = SecurityUtil.Hash("12345"), email = "admin@gmail.com", address = "address",
                phoneNumber = "0912398765", roleId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), isShopOwner = false, createdAt = DateTime.Now, updatedAt = DateTime.Now }
            );

            modelBuilder.Entity<TblCategory>().HasData(
                new TblCategory { categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), name = "T-Shirts" },
                new TblCategory { categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), name = "Jeans" },
                new TblCategory { categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), name = "Jackets" }
            );

            modelBuilder.Entity<TblGenderCategory>().HasData(
                new TblGenderCategory { genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), name = "Male" },
                new TblGenderCategory { genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), name = "Female" }
            );

            modelBuilder.Entity<TblSize>().HasData(
                new TblSize { sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), sizeName = "S" },
                new TblSize { sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), sizeName = "M" },
                new TblSize { sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), sizeName = "L" },
                new TblSize { sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), sizeName = "XL" }
            );
            modelBuilder.Entity<TblProduct>().HasData(
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"),
                name = "Men's Classic T-Shirt",
                price = 19.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Classic men's t-shirt in various sizes",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), 
                name = "Men's Slim Fit Jeans",
                price = 39.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Slim-fit jeans with a modern look",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"),
                name = "Men's Casual Jacket",
                price = 49.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Casual jacket for everyday wear",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"),
                sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), 
                name = "Women's Fitted T-Shirt",
                price = 24.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Comfortable fitted t-shirt for women",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), 
                sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), 
                name = "Women's Skinny Jeans",
                price = 34.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Fashionable skinny jeans for women",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), 
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), 
                name = "Women's Casual Jacket",
                price = 59.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Stylish and warm jacket for women",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), 
                name = "Men's Graphic Tee",
                price = 29.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Trendy graphic t-shirt with cool design",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"),
                name = "Men's Regular Fit Jeans",
                price = 44.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Classic regular fit jeans",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), 
                name = "Men's Leather Jacket",
                price = 99.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Premium leather jacket for men",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = Guid.NewGuid(),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), 
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), 
                name = "Women's Cotton Tee",
                price = 18.99m,
                imgUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23",
                description = "Soft cotton t-shirt for casual wear",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            }
             );

        }
    }
}
