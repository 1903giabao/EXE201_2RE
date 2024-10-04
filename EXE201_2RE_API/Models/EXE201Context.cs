﻿using EXE201_2RE_API.Domain.Helpers;
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
        public DbSet<TblProductImage> tblProductImages { get; set; }
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

            modelBuilder.Entity<TblProductImage>().HasData(
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23" }
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
                productId = new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"),
                name = "Men's Classic T-Shirt",
                price = 200000,
                description = "Classic men's t-shirt in various sizes",
                brand = "Nike",
                condition = "90%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), 
                name = "Men's Slim Fit Jeans",
                price = 300000,
                description = "Slim-fit jeans with a modern look",
                brand = "Nike",
                condition = "90%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"),
                name = "Men's Casual Jacket",
                price = 400000,
                description = "Casual jacket for everyday wear",
                brand = "Adidas",
                condition = "96%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"),
                sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), 
                name = "Women's Fitted T-Shirt",
                price = 250000,
                description = "Comfortable fitted t-shirt for women",
                brand = "Adidas",
                condition = "90%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), 
                sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), 
                name = "Women's Skinny Jeans",
                price = 350000,
                description = "Fashionable skinny jeans for women",
                brand = "Puma",
                condition = "89%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), 
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), 
                name = "Women's Casual Jacket",
                price = 500000,
                description = "Stylish and warm jacket for women",
                brand = "Adidas",
                condition = "99%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), 
                name = "Men's Graphic Tee",
                price = 290000,
                description = "Trendy graphic t-shirt with cool design",
                brand = "Nike",
                condition = "99%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId =  new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"),
                name = "Men's Regular Fit Jeans",
                price = 440000,
                description = "Classic regular fit jeans",
                brand = "Puma",
                condition = "85%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId =  new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), 
                categoryId = new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), 
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), 
                name = "Men's Leather Jacket",
                price = 280000,
                description = "Premium leather jacket for men",
                brand = "Nike",
                condition = "70%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), 
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), 
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), 
                name = "Women's Cotton Tee",
                price = 340000,
                description = "Soft cotton t-shirt for casual wear",
                brand = "Adidas",
                condition = "80%",
                status = "Available",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            }
             );

        }
    }
}
