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
        public DbSet<TblTransaction> tblTransactions { get; set; }
        #endregion

      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=EXE201;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblReview>()
                        .HasIndex(r => new { r.userId, r.shopId })
                        .IsUnique();

            modelBuilder.Entity<TblReview>()
                .HasOne(r => r.user)
                .WithMany(u => u.reviewsWritten)
                .HasForeignKey(r => r.userId)
                .OnDelete(DeleteBehavior.ClientSetNull); 

            modelBuilder.Entity<TblReview>()
                .HasOne(r => r.shop)
                .WithMany(u => u.reviewsReceivedAsShop)
                .HasForeignKey(r => r.shopId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<TblRole>().HasData(
                new TblRole { roleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), name = "User" },
                new TblRole { roleId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), name = "Admin" }
            );

            modelBuilder.Entity<TblUser>().HasData(
                new TblUser { userId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), userName = "shop1", passWord = SecurityUtil.Hash("12345"), email = "shop1@gmail.com", address = "123 Đường Nguyễn Văn Cừ, Quận 5, TP.HCM",
                phoneNumber = "0909123456", roleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), isShopOwner = true, shopName = "Second Chance Styles", shopAddress = "123 Đường Nguyễn Văn Cừ, Quận 5, TP.HCM",   
                shopDescription = "Tại Second Chance Styles, chúng tôi tin vào việc mang lại một cuộc sống mới cho quần áo. Cửa hàng của chúng tôi cung cấp một loạt các trang phục đã qua sử dụng, giúp bạn dễ dàng tìm thấy những bộ đồ hợp thời trang và giá cả phải chăng trong khi thúc đẩy một tủ đồ bền vững hơn.", 
                    shopLogo = "data:image/jpeg;base64,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", 
                    createdAt = DateTime.Now, updatedAt = DateTime.Now, shopBankId = "1234567890", shopBank = "TPBANK" },

                                new TblUser
                                {
                                    userId = new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"),
                                    userName = "shop2",
                                    passWord = SecurityUtil.Hash("12345"),
                                    email = "shop2@gmail.com",
                                    address = "456 Đường Trần Hưng Đạo, Hà Nội, Việt Nam",
                                    phoneNumber = "0901020304",
                                    roleId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                                    isShopOwner = true,
                                    shopName = "Second Hand Store",
                                    shopAddress = "456 Đường Trần Hưng Đạo, Hà Nội, Việt Nam",
                                    shopDescription = "Chào mừng bạn đến với Second Hand Store, nơi mỗi món đồ đều có một câu chuyện chờ đợi được khám phá! Cửa hàng của chúng tôi là kho tàng của những bộ quần áo, phụ kiện và đồ gia dụng đã qua sử dụng, được chọn lọc kỹ lưỡng về chất lượng và phong cách. Dù bạn đang tìm kiếm thời trang vintage, đồ trang trí độc đáo hay những món đồ thiết yếu bền vững, bạn sẽ tìm thấy tất cả ở đây.\r\n\r\nTại Second Hand Store, chúng tôi tin vào vẻ đẹp của việc tái chế thời trang. Mỗi món đồ đều được chúng tôi lựa chọn để đảm bảo đáp ứng tiêu chuẩn về chất lượng và sự quyến rũ. Khi mua sắm tại đây, bạn không chỉ tiết kiệm chi phí mà còn góp phần tích cực vào việc bảo vệ môi trường bằng cách giảm thiểu rác thải.\r\n\r\nHãy tham gia cộng đồng những người tiêu dùng ý thức về môi trường và khám phá bộ sưu tập đa dạng của chúng tôi. Trải nghiệm niềm vui tìm kiếm món đồ hoàn hảo trong khi góp phần vào một tương lai bền vững hơn!",
                                    shopLogo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ06F1Sa-h5bZ48AtFdYb0xOfvFTi9nTkE8sg&s",
                                    createdAt = DateTime.Now,
                                    updatedAt = DateTime.Now,
                                    shopBankId = "9876543210",
                                    shopBank = "TPBANK"
                                },

                new TblUser { userId = new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), userName = "admin", passWord = SecurityUtil.Hash("12345"), email = "admin@gmail.com", address = "address",
                phoneNumber = "0912398765", roleId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), isShopOwner = false, createdAt = DateTime.Now, updatedAt = DateTime.Now }
            );

            modelBuilder.Entity<TblCategory>().HasData(
                new TblCategory { categoryId = new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), name = "Áo Thun" },
                new TblCategory { categoryId = new Guid("a7b8c9d8-3e2a-4b9b-b9f7-5e6a7c8e9f0b"), name = "Quần Jeans" },
                new TblCategory { categoryId = new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), name = "Áo Khoác" },
                new TblCategory { categoryId = new Guid("e2b3d5a6-3e4f-5a6b-c8d9-2f2b3e5a7b8c"), name = "Váy" },
                new TblCategory { categoryId = new Guid("3419aa1b-7454-4a17-9c8f-e3f1c497f7ab"), name = "Khác" }
            );

            modelBuilder.Entity<TblGenderCategory>().HasData(
                new TblGenderCategory { genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), name = "Nam" },
                new TblGenderCategory { genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), name = "Nữ" },
                new TblGenderCategory { genderCategoryId = new Guid("6dd832ca-f7fe-4b77-9e4a-068ffd8db08e"), name = "Tất cả" }
            );

            modelBuilder.Entity<TblProductImage>().HasData(
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/07/27/f1a212658fd958b6a1daf3a51855bc19.webp" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/07/27/0e40ffa2da05eabf85ff48a5d0a7a55d.webp" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/07/26/120b42f9fed7c045636d93cfbee2cf97.webp" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), imageUrl = "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/06/19/cadc04d6af8814ac902b2405b8373cb0.webp" },
                
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://product.hstatic.net/1000284478/product/57_g3103j231309_1_a7a35a73c0a5464083c945a4d5fa4254_large.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://product.hstatic.net/1000284478/product/57_g3103j231309_2_795f101e6e714e96afa76c516fd651cc_large.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://product.hstatic.net/1000284478/product/57_g3103j231309_3_6f0acd608f11472da115a27fd0da6a2d_large.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), imageUrl = "https://product.hstatic.net/1000284478/product/57_g3103j231309_5_d46e3a485e03418e80c067585e626dd0_large.jpg" },
                
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://media.routine.vn/120x120/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-1-dsqi.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://media.routine.vn/1200x1500/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-2-fjjp.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://media.routine.vn/1200x1500/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-10-pkbo.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), imageUrl = "https://media.routine.vn/1200x1500/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-4-jslu.jpg" },
                
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/00c35ab94a354b4287c8a1efb214af0f_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_21_model.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://assets.adidas.com/images/h_2000,f_auto,q_auto,fl_lossy,c_fill,g_auto/601c73da96bf41dd8ad3901fcfd31f28_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_23_hover_model.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/39bc14e1fb5c425e88ead296cc502836_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_25_model.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), imageUrl = "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/5a8a216bb4e74ae2a792ca55c440d10a_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_01_laydown.jpg" },
                
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), imageUrl = "https://product.hstatic.net/1000078312/product/ao-da-nam-kieu-jean_a349597f895c445b9aa61e5057438ef4_master.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), imageUrl = "https://product.hstatic.net/1000078312/product/ao-da-nam-trucker-jacket_71f1c31e72764a24833eedbeb00ecf50_master.jpg" },
                
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://product.hstatic.net/200000525243/product/image_trang_1_ao-thun-graphic-nu-cotton-ninomaxx-2402006_c2808c600ae640e59cb74a9f257ae4e7_1024x1024.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://product.hstatic.net/200000525243/product/image_trang_2_ao-thun-graphic-nu-cotton-ninomaxx-2402006_25825badcda84c248e77b39c489cd5b4_1024x1024.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://product.hstatic.net/200000525243/product/image_trang_3_ao-thun-graphic-nu-cotton-ninomaxx-2402006_3f6c5964c4664218a8e32439251fd5b5_1024x1024.jpg" },
                new TblProductImage { productImageId = Guid.NewGuid(), productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), imageUrl = "https://product.hstatic.net/200000525243/product/image_trang_4_ao-thun-graphic-nu-cotton-ninomaxx-2402006_287470c662a84f3298b69575843e3176_1024x1024.jpg" }
                );

            modelBuilder.Entity<TblSize>().HasData(
                new TblSize { sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), sizeName = "S" },
                new TblSize { sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), sizeName = "M" },
                new TblSize { sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), sizeName = "L" },
                new TblSize { sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), sizeName = "XL" },
                new TblSize { sizeId = new Guid("b1bc2089-742e-4cd2-b66e-21f7babf62df"), sizeName = "FREE" }
            );
            modelBuilder.Entity<TblProduct>().HasData(
            new TblProduct
            {
                productId = new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"),
                shopOwnerId = new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"),
                categoryId = new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"),
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"),
                sizeId = new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"),
                name = "Áo Thun Ôm Nữ",
                price = 250000,
                sale = 300000,
                description = "Áo thun ôm thoải mái cho nữ",
                brand = "Ivymoda",
                condition = "90%",
                status = "Có sẵn",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"),
                shopOwnerId = new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"),
                categoryId = new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"),
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"),
                sizeId = new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"),
                name = "Quần Jeans Ôm Nữ",
                price = 350000,
                sale = 480000,
                description = "Quần jeans ôm thời trang cho nữ",
                brand = "Maison",
                condition = "89%",
                status = "CÓ SẴN",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"),
                shopOwnerId = new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"),
                categoryId = new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"),
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"),
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"),
                name = "Áo Khoác Thường Nữ",
                price = 300000,
                sale = 400000,
                description = "Áo khoác thời trang và ấm áp cho nữ",
                brand = "Routine",
                condition = "99%",
                status = "CÓ SẴN",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"),
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"),
                name = "Áo Thun Họa Tiết Nam",
                price = 290000,
                sale = 350000,
                description = "Áo thun họa tiết thời trang với thiết kế đẹp",
                brand = "Adidas",
                condition = "99%",
                status = "CÓ SẴN",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"),
                shopOwnerId = new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"),
                categoryId = new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"),
                genderCategoryId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                sizeId = new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"),
                name = "Áo Khoác Da Nam",
                price = 280000,
                sale = 600000,
                description = "Áo khoác da cao cấp dành cho nam",
                brand = "Nike",
                condition = "70%",
                status = "CÓ SẴN",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new TblProduct
            {
                productId = new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"),
                shopOwnerId = new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"),
                categoryId = new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"),
                genderCategoryId = new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"),
                sizeId = new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"),
                name = "Áo Thun Cotton Nữ",
                price = 340000,
                sale = 520000,
                description = "Áo thun cotton mềm mại dành cho trang phục thường ngày",
                brand = "Adidas",
                condition = "80%",
                status = "CÓ SẴN",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            }                       
            );
        }
    }
}
