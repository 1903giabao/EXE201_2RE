using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_2RE_API.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblGenderCategories",
                columns: table => new
                {
                    genderCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenderCategories", x => x.genderCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "tblSizes",
                columns: table => new
                {
                    sizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sizeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSizes", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isShopOwner = table.Column<bool>(type: "bit", nullable: true),
                    shopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shopAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shopDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shopLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.userId);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblRoles_roleId",
                        column: x => x.roleId,
                        principalTable: "tblRoles",
                        principalColumn: "roleId");
                });

            migrationBuilder.CreateTable(
                name: "tblCarts",
                columns: table => new
                {
                    cartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCarts", x => x.cartId);
                    table.ForeignKey(
                        name: "FK_tblCarts_tblUsers_userId",
                        column: x => x.userId,
                        principalTable: "tblUsers",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    shopOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    genderCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    sizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    sale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.productId);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "tblCategories",
                        principalColumn: "categoryId");
                    table.ForeignKey(
                        name: "FK_tblProducts_tblGenderCategories_genderCategoryId",
                        column: x => x.genderCategoryId,
                        principalTable: "tblGenderCategories",
                        principalColumn: "genderCategoryId");
                    table.ForeignKey(
                        name: "FK_tblProducts_tblSizes_sizeId",
                        column: x => x.sizeId,
                        principalTable: "tblSizes",
                        principalColumn: "sizeId");
                    table.ForeignKey(
                        name: "FK_tblProducts_tblUsers_shopOwnerId",
                        column: x => x.shopOwnerId,
                        principalTable: "tblUsers",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "tblOrderHistories",
                columns: table => new
                {
                    orderHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderHistories", x => x.orderHistoryId);
                    table.ForeignKey(
                        name: "FK_tblOrderHistories_tblCarts_cartId",
                        column: x => x.cartId,
                        principalTable: "tblCarts",
                        principalColumn: "cartId");
                });

            migrationBuilder.CreateTable(
                name: "tblCartDetails",
                columns: table => new
                {
                    cartDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartDetails", x => x.cartDetailId);
                    table.ForeignKey(
                        name: "FK_tblCartDetails_tblCarts_cartId",
                        column: x => x.cartId,
                        principalTable: "tblCarts",
                        principalColumn: "cartId");
                    table.ForeignKey(
                        name: "FK_tblCartDetails_tblProducts_productId",
                        column: x => x.productId,
                        principalTable: "tblProducts",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "tblFavorites",
                columns: table => new
                {
                    favoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFavorites", x => x.favoriteId);
                    table.ForeignKey(
                        name: "FK_tblFavorites_tblProducts_productId",
                        column: x => x.productId,
                        principalTable: "tblProducts",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFavorites_tblUsers_userId",
                        column: x => x.userId,
                        principalTable: "tblUsers",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProductImages",
                columns: table => new
                {
                    productImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductImages", x => x.productImageId);
                    table.ForeignKey(
                        name: "FK_tblProductImages_tblProducts_productId",
                        column: x => x.productId,
                        principalTable: "tblProducts",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "tblReviews",
                columns: table => new
                {
                    reviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    shopId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TblProductproductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReviews", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_tblReviews_tblProducts_TblProductproductId",
                        column: x => x.TblProductproductId,
                        principalTable: "tblProducts",
                        principalColumn: "productId");
                    table.ForeignKey(
                        name: "FK_tblReviews_tblUsers_shopId",
                        column: x => x.shopId,
                        principalTable: "tblUsers",
                        principalColumn: "userId");
                    table.ForeignKey(
                        name: "FK_tblReviews_tblUsers_userId",
                        column: x => x.userId,
                        principalTable: "tblUsers",
                        principalColumn: "userId");
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "categoryId", "name" },
                values: new object[,]
                {
                    { new Guid("a7b8c9d8-3e2a-4b9b-b9f7-5e6a7c8e9f0b"), "Quần Jeans" },
                    { new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "Áo Khoác" },
                    { new Guid("e2b3d5a6-3e4f-5a6b-c8d9-2f2b3e5a7b8c"), "Váy" },
                    { new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "Áo Thun" }
                });

            migrationBuilder.InsertData(
                table: "tblGenderCategories",
                columns: new[] { "genderCategoryId", "name" },
                values: new object[,]
                {
                    { new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Nữ" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Nam" }
                });

            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "roleId", "name" },
                values: new object[,]
                {
                    { new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Admin" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "User" }
                });

            migrationBuilder.InsertData(
                table: "tblSizes",
                columns: new[] { "sizeId", "sizeName" },
                values: new object[,]
                {
                    { new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "XL" },
                    { new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "S" },
                    { new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "M" },
                    { new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "L" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), "123 Đường Nguyễn Văn Cừ, Quận 5, TP.HCM", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(2610), "shop1@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123456", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "123 Đường Nguyễn Văn Cừ, Quận 5, TP.HCM", "Tại Second Chance Styles, chúng tôi tin vào việc mang lại một cuộc sống mới cho quần áo. Cửa hàng của chúng tôi cung cấp một loạt các trang phục đã qua sử dụng, giúp bạn dễ dàng tìm thấy những bộ đồ hợp thời trang và giá cả phải chăng trong khi thúc đẩy một tủ đồ bền vững hơn.", "data:image/jpeg;base64,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", "Second Chance Styles", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(2626), "shop1" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), "456 Đường Trần Hưng Đạo, Hà Nội, Việt Nam", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(2657), "shop2@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0901020304", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "456 Đường Trần Hưng Đạo, Hà Nội, Việt Nam", "Chào mừng bạn đến với Second Hand Store, nơi mỗi món đồ đều có một câu chuyện chờ đợi được khám phá! Cửa hàng của chúng tôi là kho tàng của những bộ quần áo, phụ kiện và đồ gia dụng đã qua sử dụng, được chọn lọc kỹ lưỡng về chất lượng và phong cách. Dù bạn đang tìm kiếm thời trang vintage, đồ trang trí độc đáo hay những món đồ thiết yếu bền vững, bạn sẽ tìm thấy tất cả ở đây.\r\n\r\nTại Second Hand Store, chúng tôi tin vào vẻ đẹp của việc tái chế thời trang. Mỗi món đồ đều được chúng tôi lựa chọn để đảm bảo đáp ứng tiêu chuẩn về chất lượng và sự quyến rũ. Khi mua sắm tại đây, bạn không chỉ tiết kiệm chi phí mà còn góp phần tích cực vào việc bảo vệ môi trường bằng cách giảm thiểu rác thải.\r\n\r\nHãy tham gia cộng đồng những người tiêu dùng ý thức về môi trường và khám phá bộ sưu tập đa dạng của chúng tôi. Trải nghiệm niềm vui tìm kiếm món đồ hoàn hảo trong khi góp phần vào một tương lai bền vững hơn!", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ06F1Sa-h5bZ48AtFdYb0xOfvFTi9nTkE8sg&s", "Second Hand Store", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(2658), "shop2" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), "address", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(2714), "admin@gmail.com", false, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0912398765", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), null, null, null, null, new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(2715), "admin" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "productId", "brand", "categoryId", "condition", "createdAt", "description", "genderCategoryId", "name", "price", "sale", "shopOwnerId", "sizeId", "status", "updatedAt" },
                values: new object[,]
                {
                    { new Guid("0906effd-eace-457a-80b2-3f10f809d210"), "Mango", new Guid("e2b3d5a6-3e4f-5a6b-c8d9-2f2b3e5a7b8c"), "90%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3170), "Váy caro thời trang với thiết kế trẻ trung, phù hợp cho các buổi đi chơi hoặc dạo phố. Chất liệu mềm mại và thoải mái.", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Váy Caro", 300000m, 490000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3170) },
                    { new Guid("0b3dd1c4-c067-4f63-868c-21862a49f60e"), "H&M", new Guid("e2b3d5a6-3e4f-5a6b-c8d9-2f2b3e5a7b8c"), "85%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3157), "Váy đầm hoa với thiết kế trẻ trung, phù hợp cho các buổi tiệc hoặc dạo phố. Chất liệu mềm mại, thoải mái.", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Váy Đầm Hoa", 350000m, 630000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3158) },
                    { new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), "Maison", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "89%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3115), "Quần jeans ôm thời trang cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Quần Jeans Ôm Nữ", 350000m, 480000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3115) },
                    { new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3088), "Áo thun cổ điển dành cho nam, có nhiều kích cỡ", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Cổ Điển Nam", 200000m, 320000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3089) },
                    { new Guid("80bb1d76-a069-4d84-938c-093e69361edd"), "Adidas", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "80%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3177), "Áo khoác dù chỉ mới sử dung được 2 tháng kể từ khi mua", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo khoác dù", 120000m, 320000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3177) },
                    { new Guid("90414d7b-1e02-4303-a4d3-0990ac362010"), "Nike", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "85%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3183), "Áo khoác nỉ, day dặn, form đứng", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo khoác nỉ", 250000m, 480000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3183) },
                    { new Guid("911c1d18-78d9-4048-b470-856965d03bc2"), "Nike", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "99%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3188), "Áo khoác hoodie Nike màu xám, thiết kế năng động và thoải mái, phù hợp cho các hoạt động thể thao hoặc dạo phố.", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Hoodie Nike", 750000m, 820000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3189) },
                    { new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), "Adidas", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "80%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3145), "Áo thun cotton mềm mại dành cho trang phục thường ngày", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Cotton Nữ", 340000m, 520000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3145) },
                    { new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), "Puma", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "85%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3133), "Quần jeans regular fit cổ điển", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Regular Fit Nam", 440000m, 550000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3134) },
                    { new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), "Adidas", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "96%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3102), "Áo khoác Jeans thời trang cho nam", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Jeans Nam", 400000m, 430000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3103) },
                    { new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), "Nike", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "70%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3139), "Áo khoác da cao cấp dành cho nam", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Da Nam", 280000m, 600000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3139) },
                    { new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3095), "Quần jeans với kiểu dáng hiện đại", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Nam", 300000m, 350000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3096) },
                    { new Guid("d13c732a-7b91-4acd-b169-5e3b2d74c806"), "Forever 21", new Guid("e2b3d5a6-3e4f-5a6b-c8d9-2f2b3e5a7b8c"), "90%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3163), "Váy đầm hoa đỏ với thiết kế dễ thương, phù hợp cho các buổi hẹn hò hoặc đi chơi. Chất liệu thoáng mát và thoải mái.", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Váy Đầm Hoa Đỏ", 320000m, 450000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3164) },
                    { new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), "Routine", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "99%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3121), "Áo khoác thời trang và ấm áp cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Khoác Thường Nữ", 300000m, 400000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3121) },
                    { new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), "Adidas", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "99%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3127), "Áo thun họa tiết thời trang với thiết kế đẹp", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Họa Tiết Nam", 290000m, 350000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3128) },
                    { new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), "Ivymoda", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3109), "Áo thun ôm thoải mái cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Ôm Nữ", 250000m, 300000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3109) },
                    { new Guid("f5105221-88db-4f40-9eff-b533ec35cb60"), "Zara", new Guid("e2b3d5a6-3e4f-5a6b-c8d9-2f2b3e5a7b8c"), "90%", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3151), "Váy đen dài, kiểu dáng thanh lịch với chất liệu mềm mại, phù hợp cho cả những dịp đi làm và tiệc tùng.", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Váy Đen Dài", 280000m, 410000m, new Guid("cdfeb832-0387-479f-8162-51d028d0c8ec"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 7, 19, 40, 0, 103, DateTimeKind.Local).AddTicks(3152) }
                });

            migrationBuilder.InsertData(
                table: "tblProductImages",
                columns: new[] { "productImageId", "imageUrl", "productId" },
                values: new object[,]
                {
                    { new Guid("00a66276-3061-4646-96ad-07884afa3a5e"), "https://product.hstatic.net/1000078312/product/ao-da-nam-kieu-jean_a349597f895c445b9aa61e5057438ef4_master.jpg", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("03b1b48a-733a-4400-8d1d-db31b6469cf0"), "https://scontent-sin6-2.xx.fbcdn.net/v/t39.30808-6/462367269_1190650565524658_7913700634870157215_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=102&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHsIyUraWqJM6d_4ni7a7EhvHNP_BUzqne8c0_8FTOqd7exlRxGWBS5Fu5zC0O-Mzg0JVbWjsksXboSXgHSGovw&_nc_ohc=T-2w_fiTmekQ7kNvgEAFMzy&_nc_ht=scontent-sin6-2.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYBqoDMLIBMi7a-q7lJrIETpC7Ots29RVpCosBHumHn6hQ&oe=67098F74", new Guid("80bb1d76-a069-4d84-938c-093e69361edd") },
                    { new Guid("068f37a0-88a7-46d4-bd93-00ac8df75ab7"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462143536_1190650245524690_3338923196790388173_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=101&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHJjOCp1EsgX0XuqpdkIjPDpGjnSp3Pk_mkaOdKnc-T-VzzVJm3ZgmNiW6gYpaN9ESuQYTkcsw8MVxLnTu47qZb&_nc_ohc=c76v7HPKjcgQ7kNvgG78tg7&_nc_ht=scontent-sin6-4.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYBxXcC7KxGwYuRsMSTC1jFLdEaaJ9Z7u6sDZNLB4w6TCQ&oe=67097F59", new Guid("90414d7b-1e02-4303-a4d3-0990ac362010") },
                    { new Guid("07967667-bc16-4d57-98cf-a44690e59a42"), "https://assets.adidas.com/images/h_2000,f_auto,q_auto,fl_lossy,c_fill,g_auto/601c73da96bf41dd8ad3901fcfd31f28_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_23_hover_model.jpg", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("07d80c4b-b4f0-4979-a28b-82e849b06117"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462430113_1190651098857938_2804501176613932886_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEp9hEdfI9wu-JX-BluA7XgIx81Vu-vneIjHzVW76-d4jqHX_P_uBASjDG4OUYdoZmcMYjo8BaW2TlT3Bf2b5iK&_nc_ohc=fchnIyXC_fEQ7kNvgF0RFUl&_nc_ht=scontent-sin6-3.xx&_nc_gid=A4DtD62MGpNqQ1YoDkNzYJM&oh=00_AYD1gY4-s_uINE-wOpjqwnAQ6OnshiZTZ1Wt4FI_0ETIPg&oe=6709A2F0", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("092b076d-eb8e-4d33-bbaf-f2aff4d2a910"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462280874_1190649438858104_5605548969058679071_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=106&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGknSDAbCDAvwFIVHOMGjTJUjywqsc1ajdSPLCqxzVqNyujWx2tVK6R695AuVxlffiI92hNbAaRaAnPPcQ4eUsl&_nc_ohc=VL17BBg-SfsQ7kNvgEG-dPx&_nc_ht=scontent-sin6-3.xx&_nc_gid=AMPKQZmYAkK_rt1KZ8BRacV&oh=00_AYCfROjDDwFIJuxjDuuymO8tgZ1d2cSvAJaGaV5nLh1PLA&oe=67099A32", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("1918cdd7-d90b-41f7-b8dc-e6256b43a7dd"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462276672_864269152522632_8956318730307087268_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=104&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEg4rRWJUHH1zSUURoFKeaKQ4nhtc-T6u5DieG1z5Pq7mZASJv8odBz5TsKlGBmVW-S0ZECTWBOAPho4KJ5uEqP&_nc_ohc=Ms64fP35FqQQ7kNvgH8ZST9&_nc_ht=scontent-sin6-3.xx&_nc_gid=AwfVhOCIbm33Z9X7LwdQE5K&oh=00_AYBUR5EF93SDlQZr_sb3-ZiTdcuaqSkuWClbhY2NWFz9RA&oe=6709AD06", new Guid("911c1d18-78d9-4048-b470-856965d03bc2") },
                    { new Guid("1efde34e-a31f-4442-bfae-6f51c2b4575d"), "https://media.routine.vn/1200x1500/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-10-pkbo.jpg", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("262e7005-42d6-47e8-8fc1-ab9219091efd"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462189188_1190650552191326_3979515046974121509_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeH7wHXwSyRGidnnQJqGo1N84SW_oF6qTebhJb-gXqpN5qDsZr8g5AKB9aklU21vMoIU7VF_qS8fm1UuE0WMvNBz&_nc_ohc=DW6dMH5d4agQ7kNvgF8ilX3&_nc_ht=scontent-sin6-3.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYCxCgygfjP_g-GuaEAPrSCbzGNJUoj5vMPXELi9BFaDFw&oe=670989B8", new Guid("80bb1d76-a069-4d84-938c-093e69361edd") },
                    { new Guid("2791b8b6-874f-48f7-a93d-d0a72934e5bf"), "https://media.routine.vn/1200x1500/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-2-fjjp.jpg", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("287853c4-d659-4b64-8c70-9b1198fb4697"), "https://product.hstatic.net/1000284478/product/57_g3103j231309_2_795f101e6e714e96afa76c516fd651cc_large.jpg", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("28ebbde8-577b-4b8f-b29c-72bfed8b3d54"), "https://product.hstatic.net/200000525243/product/image_trang_3_ao-thun-graphic-nu-cotton-ninomaxx-2402006_3f6c5964c4664218a8e32439251fd5b5_1024x1024.jpg", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("2ec52a7a-1c23-49cb-ac04-2bf42b314559"), "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/06/19/cadc04d6af8814ac902b2405b8373cb0.webp", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("31a6a3cb-38cc-4c7a-bf7f-a0e2d98b7a78"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462360852_864269195855961_8323563770541401975_n.jpg?stp=cp6_dst-jpg&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEwVmGG39YVp15IQm74zIO2jYfpXbDNl8-Nh-ldsM2Xz5PJcOaiAlqwRTzK3YSUjrRKvT0eMgL9Q8ClXGRFDWQU&_nc_ohc=lcSAeSIKy0sQ7kNvgEpnJ7N&_nc_ht=scontent-sin6-4.xx&_nc_gid=AfQYDIO94xuI4RpXX9k3NfG&oh=00_AYCjks-UON1CXLejBCnGZtAb6845Ceo8TiZPvoi3bet1Ow&oe=670996A4", new Guid("911c1d18-78d9-4048-b470-856965d03bc2") },
                    { new Guid("33473b70-fca8-4a1b-80a3-d94b7485f7c5"), "https://media.routine.vn/120x120/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-1-dsqi.jpg", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("34a728b8-1645-462e-8da4-b412d86096b5"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462361805_1190652858857762_6862991413391019038_n.jpg?stp=dst-jpg_p417x417&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeH7-iVGxvbGfofIto0zvIZanJCKZXWDhHickIpldYOEeH0bwmOI0ZaYHBt6VcNCFGMBzK9K3ZvJdFoF8ndwA9FG&_nc_ohc=oYcLrzY_26cQ7kNvgG8aNIH&_nc_ht=scontent-sin6-3.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYBRPFNFMXMwYTLcOlhtWQ07n2A-UeEid78FlnS-8MzNXA&oe=670987A0", new Guid("d13c732a-7b91-4acd-b169-5e3b2d74c806") },
                    { new Guid("3766ba25-666e-4ba0-9c82-f62fdb2961ee"), "https://scontent-sin6-1.xx.fbcdn.net/v/t39.30808-6/462209613_1190652482191133_3682019644227254964_n.jpg?stp=dst-jpg_p417x417&_nc_cat=107&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeFWRuTXps-M997RB2xBn7wneYHdLtWIsm55gd0u1Yiybk0EK4UsbGzo9QZbpxNabq7WCWPXosqJIO3mgoZnp89x&_nc_ohc=Kcw3uLsde58Q7kNvgGx_8ay&_nc_ht=scontent-sin6-1.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYBKc__N1fSeyRrE-JZz83bYoVYPETuz9diiAUVuyRZyNg&oe=67098A38", new Guid("0b3dd1c4-c067-4f63-868c-21862a49f60e") },
                    { new Guid("3ade3d59-bacf-4a45-8fc3-a357369d7b3b"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462143442_1190648778858170_8527128245348001503_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeE52zZpv9SsGlHN3d8s1rqO-UGD4nj0as_5QYPiePRqz0ynqx2WA26BD18jwaAI7oYBlPk3MES6-vcfHzbA3y2D&_nc_ohc=zyFG-Qshh6gQ7kNvgEmttzq&_nc_ht=scontent-sin6-4.xx&_nc_gid=AeeswRyuP4ByMMsg84EImIn&oh=00_AYDJ7kwMlFnZvmxhDgcgGTRDWLMBljD--OYr_tG1KgHLlA&oe=67099E1D", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("3b030ebc-d0f7-4f32-9224-cfb9bc5ec3f7"), "https://product.hstatic.net/1000078312/product/ao-da-nam-trucker-jacket_71f1c31e72764a24833eedbeb00ecf50_master.jpg", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("3b09a9a5-7924-4019-8d8f-aa5ca996f981"), "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/07/27/f1a212658fd958b6a1daf3a51855bc19.webp", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("3e61afeb-3c38-4ca9-893d-b37ca8344cf9"), "https://scontent-sin6-2.xx.fbcdn.net/v/t39.30808-6/462200504_1190648765524838_6177386380076503619_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=109&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGYir_YTyUfSFOtFE2nMj10SEUGdOAivltIRQZ04CK-Wyfod9CtihXpIbYRBZYGPn5r2A3Zq0n7av7yiEVQeonz&_nc_ohc=n4rcZN68JTkQ7kNvgHNUa2O&_nc_ht=scontent-sin6-2.xx&_nc_gid=AeeswRyuP4ByMMsg84EImIn&oh=00_AYCCV4jBzy-ac1Ir3HxdFlQA0cVjBt5N8ri0LQkppAOT3Q&oe=67098C22", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("43d74a24-2f88-4068-a3e5-4c9d83cb3e8e"), "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/5a8a216bb4e74ae2a792ca55c440d10a_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_01_laydown.jpg", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("475deda8-6e7a-498a-9ce5-bfb59acfca7c"), "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/07/26/120b42f9fed7c045636d93cfbee2cf97.webp", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("47ca228f-3af3-4bff-bddb-ba744635b5f2"), "https://scontent-sin6-2.xx.fbcdn.net/v/t39.30808-6/462146157_1190653742191007_7896700143736823604_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=109&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHZxDuXFJT5tJJnmYss2tqYf1JxRGn0S4h_UnFEafRLiJ4Mf2eGzo9UGH0Yhs1Jvrd3gSDd8xMX654UA6E1B_0x&_nc_ohc=B16UbY7vefkQ7kNvgEbTqAv&_nc_ht=scontent-sin6-2.xx&_nc_gid=Akw1P5LvrIDN2cDNJdEvu3A&oh=00_AYCU8MlDdnVvld7AYpRK6sh9o8RJ3brvO1FTmTB78UGI0w&oe=670992E6", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("4a4636f8-43b6-40e7-bebd-d6ff84ab9b25"), "https://pubcdn.ivymoda.com/files/product/thumab/400/2024/07/27/0e40ffa2da05eabf85ff48a5d0a7a55d.webp", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("4d9211fd-acfb-445b-a4ec-dccf6956eb88"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462134148_1190652628857785_5610872906669820628_n.jpg?stp=dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGXZBEvvCnmWEF4T5vf-BSWiFuuXWDGCS-IW65dYMYJL5Lxlf-pniFLzWFPN37GBxoQHFnTuwWU6GTAIhIJcxQC&_nc_ohc=u9ZCrP7x7goQ7kNvgHB7sSM&_nc_ht=scontent-sin6-3.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYBl6YNUW_xdrHZ4oaxZ2nrdXRhwP8qyAkuTQ9Xz_l72Cw&oe=6709A9BE", new Guid("0b3dd1c4-c067-4f63-868c-21862a49f60e") },
                    { new Guid("4e79bdf0-c9a9-4446-bb6e-eec763d154d9"), "https://product.hstatic.net/200000525243/product/image_trang_1_ao-thun-graphic-nu-cotton-ninomaxx-2402006_c2808c600ae640e59cb74a9f257ae4e7_1024x1024.jpg", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("4e96bb23-2419-4f72-a652-245224ff5a62"), "https://scontent-sin6-2.xx.fbcdn.net/v/t39.30808-6/460878517_1190652775524437_5707249290790477205_n.jpg?stp=dst-jpg_s600x600&_nc_cat=102&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHtHZZRGC2T91QNKuu7fKk8O6i_cy7ROx87qL9zLtE7HzOHoRAzgvCEkpO00VwzXupsJ_rpQEWe_pqJiCvfubzP&_nc_ohc=l3dZmfturMIQ7kNvgFkY8xg&_nc_ht=scontent-sin6-2.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYChBvBblrCqM4d_Ng47Hr6JdtOZlRPmVHZ9gCvcSTNYnA&oe=670993C0", new Guid("d13c732a-7b91-4acd-b169-5e3b2d74c806") },
                    { new Guid("53493b32-2df1-4ccb-a8d6-998a37a0497c"), "https://product.hstatic.net/1000284478/product/57_g3103j231309_5_d46e3a485e03418e80c067585e626dd0_large.jpg", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("5fad50bc-80f4-4d34-bfc4-009f4c9117f6"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462152769_1190650188858029_6584950977362597640_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=108&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGC3tTu112w6oSC4JolRVFOuP1PEKeIj8-4_U8Qp4iPz3E2_lreVt4wuAJgOHcLO1GGaJxEuUvVWCP7RLbicvBK&_nc_ohc=6hrVUKhgZCMQ7kNvgE1NKG8&_nc_ht=scontent-sin6-4.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYBVv2UYWBvI2vwLzCBf3WjRMQq0V3QgLoQyQNR_R4fxLw&oe=6709B086", new Guid("90414d7b-1e02-4303-a4d3-0990ac362010") },
                    { new Guid("69c4bcc8-6396-4eba-b734-118c9086b3ca"), "https://product.hstatic.net/200000525243/product/image_trang_2_ao-thun-graphic-nu-cotton-ninomaxx-2402006_25825badcda84c248e77b39c489cd5b4_1024x1024.jpg", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("6f940b12-1121-4204-87f2-45c190f67f0a"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462307048_1190649448858103_2246652908721678357_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=104&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEwsF3AF0dken9z0hYKxxTna_9TGLa1Mddr_1MYtrUx1xa8_TkATHivSW2Aq3eRbg9gMwmgJPX0GOjZmKd4kN3w&_nc_ohc=K5VXVbNADz0Q7kNvgH9QH-H&_nc_ht=scontent-sin6-3.xx&_nc_gid=AMPKQZmYAkK_rt1KZ8BRacV&oh=00_AYDfSWaqK7cD8k50DUCXUGncsOUlbKQpGr-T9oZbVHv1eQ&oe=67099B4A", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("77849e10-b897-4969-b139-4523d0fdba97"), "https://scontent-sin6-2.xx.fbcdn.net/v/t39.30808-6/462258591_1190651972191184_1061445056451356920_n.jpg?stp=dst-jpg_s600x600&_nc_cat=102&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeFwp7XUKVUDwu8QTL6ESXhX_OaicN5W7rr85qJw3lbuuiMjNum4vevDLQWpMNS6ro7F4i2SKAtBK7i-Y71GiARg&_nc_ohc=LB4XjQY2TnsQ7kNvgF8_XiE&_nc_ht=scontent-sin6-2.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYBItpmkOSgrWKZK266AIUQ4gJMfVr1iRx2PSdA0czltrw&oe=6709A661", new Guid("f5105221-88db-4f40-9eff-b533ec35cb60") },
                    { new Guid("84e2c08c-8efc-4948-9ba3-7bd773a08900"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462359275_1190650355524679_529689306130316365_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=101&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEqht4RRKP41C5GXEdInjk8sU5l2oskCtixTmXaiyQK2P3r78EmF1_ZtGh9VVVlxSmSj70dDGh6VCBdqNAh4Bx-&_nc_ohc=A41m0m7yPtUQ7kNvgGb_pCD&_nc_ht=scontent-sin6-4.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYB0LF1eTvwLV4FNbilxEiLePe9I-A3UJa2m4YHMIoEMFw&oe=670998C1", new Guid("90414d7b-1e02-4303-a4d3-0990ac362010") },
                    { new Guid("86afad57-850f-461f-982a-4de64142c97a"), "https://scontent-sin6-1.xx.fbcdn.net/v/t39.30808-6/462281513_1190652802191101_4951767478181194726_n.jpg?stp=dst-jpg_s600x600&_nc_cat=111&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHpTYxN5eaw-GdI4myxDbt6TqrerqtLPhZOqt6uq0s-FsMmKZfPjmRAWcyaMKk40Q64yrbfoCHZkIiJ8LNFmHFH&_nc_ohc=yDnq8qk-KwsQ7kNvgEVNKpx&_nc_ht=scontent-sin6-1.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYAKPLeTm9KllrFYObyMJ8_zRp8Vrl905-eIFtTu_oBqsA&oe=670993A2", new Guid("d13c732a-7b91-4acd-b169-5e3b2d74c806") },
                    { new Guid("87ce4358-35c0-4b9b-9975-7321643c99e4"), "https://scontent-sin6-3.xx.fbcdn.net/v/t1.15752-9/462087488_1448641485815846_8745299286179099985_n.jpg?stp=dst-jpg_s206x206&_nc_cat=110&ccb=1-7&_nc_sid=0024fc&_nc_eui2=AeHVv5s43jetCccfcBw2xYk6we5Fd9PDGobB7kV308MahsVsCnLDf4tDQSeLmyPurLogyEfPH-HXsN87uriRu6Wi&_nc_ohc=kpmtmKFl7TEQ7kNvgGbGbek&_nc_ht=scontent-sin6-3.xx&_nc_gid=A78XRwBRwnWIchQzK6E7Q0F&oh=03_Q7cD1QEP0NAQqR-OZKo598EMyEr-49dqkEiIKcQxu6VMuxEu0A&oe=672B417D", new Guid("0906effd-eace-457a-80b2-3f10f809d210") },
                    { new Guid("89373a86-fdad-4389-88e3-8099ac8a326e"), "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/39bc14e1fb5c425e88ead296cc502836_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_25_model.jpg", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("8d29fac3-ba70-4efc-a316-524f72b57dd9"), "https://scontent-sin6-2.xx.fbcdn.net/v/t39.30808-6/462432348_1190649388858109_1346206829344471116_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=109&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHxD8FdH08X3z9D4tjWIlIgbjPmsIjo1A9uM-awiOjUD9QbmdNNM4EzIU1LH5eiC_CeREzeDaHab60daFiAp0RK&_nc_ohc=baUqMWOfVKIQ7kNvgG1F4b9&_nc_ht=scontent-sin6-2.xx&_nc_gid=AMPKQZmYAkK_rt1KZ8BRacV&oh=00_AYDXc8K9vbbZk2Y4UiRvDh6gZbCNk3FF9H3CUU4AqpJCmw&oe=67098398", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("960cde23-4cba-446d-a217-a2c879f53367"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462468327_1190651248857923_5108233084125660578_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHqgSPZKONjuc3vt935JrF0G416HwPJk28bjXofA8mTb0QI3FphstP8qOR18LpgDB6TSeFK2oDNjigTr7pTxYxW&_nc_ohc=P4Jj7J_cjRMQ7kNvgGQ8trY&_nc_ht=scontent-sin6-4.xx&_nc_gid=A4DtD62MGpNqQ1YoDkNzYJM&oh=00_AYCiSKv8_NDWtFdpDYDvhlTLm8W8-RnyzDUTIlgsGeYWFg&oe=67099A7A", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("980117de-2682-49ae-ac74-6c6dc53d5071"), "https://product.hstatic.net/1000284478/product/57_g3103j231309_1_a7a35a73c0a5464083c945a4d5fa4254_large.jpg", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("9af33b36-60bf-4aba-a308-456f9a41879c"), "https://scontent-sin6-2.xx.fbcdn.net/v/t1.15752-9/461698758_1004567781424961_7751476277888925563_n.jpg?stp=dst-jpg_s206x206&_nc_cat=102&ccb=1-7&_nc_sid=0024fc&_nc_eui2=AeGlq-llVKPm-uKgnlCAqllgBQq8cA_njb8FCrxwD-eNv3tXTjLTIrHk_k-zM6RWWxMv6yncksW2S2NJQbWxdHj_&_nc_ohc=PIL-C3-AwV0Q7kNvgE37QDV&_nc_ht=scontent-sin6-2.xx&_nc_gid=A78XRwBRwnWIchQzK6E7Q0F&oh=03_Q7cD1QEFe3U6HJ_HI-YW3h8XshfUdAJpiOZY3BWNT-gO2a9KWQ&oe=672B3F48", new Guid("0906effd-eace-457a-80b2-3f10f809d210") },
                    { new Guid("9d3b1ab3-01ea-4638-82e2-99887ad3bead"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462188595_1190653755524339_2452491022402204320_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGKKeRZt5ioIZZLvYyXnb8hwVqiDFzGlaLBWqIMXMaVoph6z38LxC498AWgQtiLUk7O67259TTgbN-fGwbBlTDF&_nc_ohc=weVg00ugYlIQ7kNvgF4z5yg&_nc_ht=scontent-sin6-3.xx&_nc_gid=Akw1P5LvrIDN2cDNJdEvu3A&oh=00_AYBAvYg14n2bYvv09E6eopvlDwtKmc8tPlEZPqyJFbGJEA&oe=67097997", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") }
                });

            migrationBuilder.InsertData(
                table: "tblProductImages",
                columns: new[] { "productImageId", "imageUrl", "productId" },
                values: new object[,]
                {
                    { new Guid("9eb20983-7d6b-4d13-83b0-ca5f08a823b0"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462456836_1190653672191014_6521162009906945375_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=104&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEwc4mImbbW4tsGddQLP-OmXevwr_NxNild6_Cv83E2KbTsfpGG6pCA3jACufVrjlAFJNU5Y2Ujl5IljxmBaA3C&_nc_ohc=NVdtA3EBlt0Q7kNvgG1B1Vp&_nc_ht=scontent-sin6-3.xx&_nc_gid=Akw1P5LvrIDN2cDNJdEvu3A&oh=00_AYAwb8abImpL4TbQ86Ol2F9EDo5UcxxY9AyV-6q4NQttDQ&oe=67097AFD", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("a3bb3232-46cf-44b0-be7a-a10c062bbcf3"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462226760_1190652758857772_2086274927950977295_n.jpg?stp=dst-jpg_s600x600&_nc_cat=104&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEuT4K2u8Iao8rxyw7qDXJRjgUvdAgiLHKOBS90CCIscuSOEw-ILvd0-rXpvCAdd61vpMOPfA4fN-gbt844z4GU&_nc_ohc=dt-gG5a1RlIQ7kNvgHTQdLU&_nc_ht=scontent-sin6-3.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYAUQZ5-1enbD9s5Tfx2H6OllxEAUF7tjEpL78XOwGmsAQ&oe=670984B0", new Guid("d13c732a-7b91-4acd-b169-5e3b2d74c806") },
                    { new Guid("a3eaf856-2a8e-4325-b2b3-82b175bc6be9"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462317304_1190650758857972_2406743421779401641_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=100&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeG6bhxFztOlUX2iQoBigSLSPq-B-CcRIaI-r4H4JxEhokqilr61IGdjo16TcF5jJklpJfFJgSa5TP1LK7Uu5Zv1&_nc_ohc=r23Rn0u49cYQ7kNvgF27pXP&_nc_ht=scontent-sin6-4.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYBspDQohaEJ-PXkLS4dBirj_44vY4PZx-ZMY9qR6An2sg&oe=67098A45", new Guid("80bb1d76-a069-4d84-938c-093e69361edd") },
                    { new Guid("a86b91e1-9690-40ea-8d82-ab79a6d51b69"), "https://product.hstatic.net/1000284478/product/57_g3103j231309_3_6f0acd608f11472da115a27fd0da6a2d_large.jpg", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("b46e6b14-cc61-4801-ad2c-7b298d7c8db9"), "https://scontent-sin6-1.xx.fbcdn.net/v/t39.30808-6/462322697_1190650262191355_568598325132261124_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=111&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeH8hJR5BVBNfshgmRJScnR4U5ez1vtCn6VTl7PW-0KfpZhpJgp2zwQcXe947Y5NZQyO0ph8DA9X8R5BR9VahSi6&_nc_ohc=xhWKoaEMHGAQ7kNvgEg-CRR&_nc_ht=scontent-sin6-1.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYAIOn_PB2MP_jL1RBY39rneiUlnMt7rOxWy0OV01vdtcg&oe=6709A218", new Guid("90414d7b-1e02-4303-a4d3-0990ac362010") },
                    { new Guid("b558eea0-4f8d-40a8-b9ef-94d7363bcfe0"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462299819_864269192522628_4247925036611072932_n.jpg?stp=cp6_dst-jpg&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeG2KBu7P9FZIA0CIHifiC3e0ctMmqR4s0rRy0yapHizSiwN8KzdFvd9GVUEM-ewsoly332tFsfncfwBgEVT0tU0&_nc_ohc=MOuqQZ1gOxwQ7kNvgEl5tJO&_nc_ht=scontent-sin6-3.xx&_nc_gid=AsS7-cCgdF4v7zqrYCyzRzC&oh=00_AYBq9W8OSzEdlESXLq9Kjg0rvI8lNVk1mDw4nrkD64fN3w&oe=6709B4DD", new Guid("911c1d18-78d9-4048-b470-856965d03bc2") },
                    { new Guid("c1e777eb-6cdd-4637-8a38-1163a1322017"), "https://scontent-sin6-1.xx.fbcdn.net/v/t39.30808-6/462179202_1190648472191534_4093366170601171540_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=107&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeF2YwlaLRAN7ap0AfCbk2aioW2CnbUw1wChbYKdtTDXAEWt_B05cWHCdczhq2T19dKgDrTWVxSkqoUAGJQlUgIM&_nc_ohc=uJaRj7wAkMYQ7kNvgFd78Th&_nc_ht=scontent-sin6-1.xx&_nc_gid=AeeswRyuP4ByMMsg84EImIn&oh=00_AYCT-RpGDeAcClnxHP4gDkqB6E2GfHNzg7Zzgj1BL3RWew&oe=67098224", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("cccd4b47-fb61-4047-87c8-31279baedb8d"), "https://product.hstatic.net/200000525243/product/image_trang_4_ao-thun-graphic-nu-cotton-ninomaxx-2402006_287470c662a84f3298b69575843e3176_1024x1024.jpg", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("d0e13133-24ec-4f0f-9eaa-781367fc78d0"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462222319_1190651088857939_4794790430557999_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeG0ItDnI8TjCWrqcpCsSHbNWhl3vPEWBvhaGXe88RYG-OcX33g8WYjchX2HkpA2-LKb1899T4j8CY7aN5mnsvOA&_nc_ohc=QpGX_AIvQiQQ7kNvgGjTtxa&_nc_ht=scontent-sin6-4.xx&_nc_gid=A4DtD62MGpNqQ1YoDkNzYJM&oh=00_AYC207q6xjKl3V1r4MhMc8CUBJNwKeDFod204EDz3_Stpw&oe=670978F7", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("d1eae87e-7da5-4b2d-a9e7-7a0ba8363ccf"), "https://media.routine.vn/1200x1500/prod/media/10F22JACW022_-REAL-BLACK_ao-phao-nu-4-jslu.jpg", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("d595fda5-a074-44e4-976a-db4690f583c3"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462206491_1190653662191015_6111409767068771805_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGAPmfHO8qDQnVk1XTYrY9dcXIuZAmaPidxci5kCZo-J4HrBv1ooPv30W6-De5R6qxTEMdTY9u5PNS_kK68qub8&_nc_ohc=K51Y_qs1grYQ7kNvgGBYMeD&_nc_ht=scontent-sin6-4.xx&_nc_gid=Akw1P5LvrIDN2cDNJdEvu3A&oh=00_AYBj_00mGkxRGvgZU9AjycmB-3fDDlwT1mrQ0U3s76hukg&oe=6709983A", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("dd3e03c4-5173-47e0-976d-f7b69d4c5d19"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462181647_1190652378857810_868904211843041196_n.jpg?stp=dst-jpg_s600x600&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEahbZOr5E6pNY-JTXYKUKg_zlz62iLn4f_OXPraIufh34O7SCx5bfmjWT-i5RejJcmEwv6_8oTxJTf05RBl-Vw&_nc_ohc=2BydfTGngw8Q7kNvgH6g34s&_nc_ht=scontent-sin6-4.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYBAUkKNwgZYqnzSO0oclXuTcc6fUctjD44MZHU1CXmedg&oe=67099C08", new Guid("0b3dd1c4-c067-4f63-868c-21862a49f60e") },
                    { new Guid("ddb09da6-2d38-4dc3-b350-c45d421a3115"), "https://scontent-sin6-4.xx.fbcdn.net/v/t1.15752-9/461872772_528769236549356_291705731726501451_n.jpg?stp=dst-jpg_s206x206&_nc_cat=103&ccb=1-7&_nc_sid=0024fc&_nc_eui2=AeED9dIx3wesLR-u6fs08ifM6W95JsXe0VPpb3kmxd7RU0vHjuXdPjZRF3L1d4NlFZ_u4pndjDZ9zJnqBcHSZ0-s&_nc_ohc=u67V35JrxhEQ7kNvgFEeVBh&_nc_ht=scontent-sin6-4.xx&_nc_gid=A78XRwBRwnWIchQzK6E7Q0F&oh=03_Q7cD1QGE3QHlilL1qsnXq79Y8lYK0OMkvRm7nK6jry9trFzq3w&oe=672B2067", new Guid("0906effd-eace-457a-80b2-3f10f809d210") },
                    { new Guid("dddee5db-baea-430d-8a52-d5bee133e0ef"), "https://scontent-sin6-3.xx.fbcdn.net/v/t1.15752-9/461859585_8906815699337857_1045472133043513603_n.jpg?stp=dst-jpg_s206x206&_nc_cat=104&ccb=1-7&_nc_sid=0024fc&_nc_eui2=AeEmd6VFn8K2veJNFsiq6oVZfruX7IELvbt-u5fsgQu9u2zMpnmq7-WV9GLybCJAYbXy_WDry2rx8SSejnfR3BfM&_nc_ohc=eZQHkOiQj38Q7kNvgElOy0I&_nc_ht=scontent-sin6-3.xx&_nc_gid=A78XRwBRwnWIchQzK6E7Q0F&oh=03_Q7cD1QFqLceyvB8noF3tddO7ktVcgyenv4q4juQE0Jzo1JitOQ&oe=672B2CD4", new Guid("0906effd-eace-457a-80b2-3f10f809d210") },
                    { new Guid("ddf3bb64-957d-443b-b7c9-6142f0423eac"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462257865_1190650772191304_1392401977120547997_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=103&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeErLHf7ymM8uyesrfOXC24lvGnJU8lIQsa8aclTyUhCxmdsMgKE1TZSU36NRk3XohQUxDlhjgbXrTVOcGCbhMET&_nc_ohc=hwkHpKGrjMMQ7kNvgFiBnO1&_nc_ht=scontent-sin6-4.xx&_nc_gid=APb3_YKYzZw9_Pl9nf05khJ&oh=00_AYDqKV6O7JLdiak193d3cpk7ivxU8avHllVw7TZTPP592Q&oe=67099017", new Guid("80bb1d76-a069-4d84-938c-093e69361edd") },
                    { new Guid("e41be94e-3d33-48b5-ace0-b2b22fe82ff1"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462230345_1190651922191189_885011684073512957_n.jpg?stp=dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeG71WvMIRP0Dt4OGBor_hu_Y_X6Bt8a5Thj9foG3xrlOFBD2vhrJ0nfJ5fYVfV8lWnRzVJB75fhj1JCjCTyZPYC&_nc_ohc=fRvjqhddbqIQ7kNvgFRWg0N&_nc_ht=scontent-sin6-3.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYDzeGr_aAAnXsx8Et3O4F22MRkFt0p7HKJrnLBAVsyXCA&oe=6709A29A", new Guid("f5105221-88db-4f40-9eff-b533ec35cb60") },
                    { new Guid("e439ffea-f820-4b7c-8ce2-24800488e2f0"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462189155_1190651982191183_1598014521360324937_n.jpg?stp=dst-jpg_s600x600&_nc_cat=108&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEqxU9aPOT0LdzRnmeh76tpLske6HHX6y0uyR7ocdfrLYIWmxa1wF3Yb9cIxGLtrBkBW5xrASspfBZ2YJ1I1QZx&_nc_ohc=BtP7a6fDJ04Q7kNvgHXbhOX&_nc_ht=scontent-sin6-4.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYAHfq3xJUmyDDmtGa8082uVNxxYjK7bS0aDSpjpsnUjgg&oe=67099E28", new Guid("f5105221-88db-4f40-9eff-b533ec35cb60") },
                    { new Guid("eaf4082a-3877-4dae-89c5-15e23746d8f0"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462222542_1190651915524523_4219575148608521625_n.jpg?stp=dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeHgWXxVj1Lhj48CoqFkx6X5luplycg4yb2W6mXJyDjJvfs6cIRlI5LW_kmZHQIEK1MzWwGLzSUWXvjRoBovfDfm&_nc_ohc=vie0JbKkhGUQ7kNvgGU-qRm&_nc_ht=scontent-sin6-3.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYB2ki3hYk9GACyTN1eUFziCtP38pQPyKdSImuB6xuMWEA&oe=6709794B", new Guid("f5105221-88db-4f40-9eff-b533ec35cb60") },
                    { new Guid("f3402f68-a0d2-48ed-a2e0-1230f022b463"), "https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/00c35ab94a354b4287c8a1efb214af0f_9366/Ao_Thun_Ngan_Tay_Tie-Dye_2_Mau_vang_IZ0090_21_model.jpg", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("f4e02468-518f-4bb4-9663-9fa82885461f"), "https://scontent-sin6-4.xx.fbcdn.net/v/t39.30808-6/462146344_1190652368857811_5735034023772706504_n.jpg?stp=dst-jpg_s600x600&_nc_cat=108&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeFbcHk_Xiuzi4uipLgUFavNGzgrZxd-V-cbOCtnF35X5zEOTU3hse18FSzFZOfoCx4i8dsigeMK1Copw9ShMbgV&_nc_ohc=5yHoP5Ses7oQ7kNvgHtblV6&_nc_ht=scontent-sin6-4.xx&_nc_gid=AsHCIPHGEbCHpgPqEofqovV&oh=00_AYCw0E4ub0-gp8tKIwPgj-s0mE6jhxZgW_C6y_JxQzcP9g&oe=67097E0A", new Guid("0b3dd1c4-c067-4f63-868c-21862a49f60e") },
                    { new Guid("fd6ca857-587f-4075-838e-d33d0616be72"), "https://scontent-sin6-3.xx.fbcdn.net/v/t39.30808-6/462199610_1190651162191265_4722481028415352710_n.jpg?stp=cp6_dst-jpg_s600x600&_nc_cat=110&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeFAvhnoDktwvfOWN4YFna_UW7jMKstwuaVbuMwqy3C5pT8tYK1nJoNDS2jhuEihy3IQI7LEjTQWexjEt2VM1T0L&_nc_ohc=46TMj6Ks46MQ7kNvgFNvAT-&_nc_ht=scontent-sin6-3.xx&_nc_gid=A4DtD62MGpNqQ1YoDkNzYJM&oh=00_AYDI891vKvek8bqRWSZRrsWiosLK9jP_6pDJ-rDF89oDsg&oe=67098257", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetails_cartId",
                table: "tblCartDetails",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetails_productId",
                table: "tblCartDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarts_userId",
                table: "tblCarts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavorites_productId",
                table: "tblFavorites",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavorites_userId",
                table: "tblFavorites",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderHistories_cartId",
                table: "tblOrderHistories",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductImages_productId",
                table: "tblProductImages",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_categoryId",
                table: "tblProducts",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_genderCategoryId",
                table: "tblProducts",
                column: "genderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_shopOwnerId",
                table: "tblProducts",
                column: "shopOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_sizeId",
                table: "tblProducts",
                column: "sizeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_shopId",
                table: "tblReviews",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_TblProductproductId",
                table: "tblReviews",
                column: "TblProductproductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_userId_shopId",
                table: "tblReviews",
                columns: new[] { "userId", "shopId" },
                unique: true,
                filter: "[userId] IS NOT NULL AND [shopId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_roleId",
                table: "tblUsers",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartDetails");

            migrationBuilder.DropTable(
                name: "tblFavorites");

            migrationBuilder.DropTable(
                name: "tblOrderHistories");

            migrationBuilder.DropTable(
                name: "tblProductImages");

            migrationBuilder.DropTable(
                name: "tblReviews");

            migrationBuilder.DropTable(
                name: "tblCarts");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCategories");

            migrationBuilder.DropTable(
                name: "tblGenderCategories");

            migrationBuilder.DropTable(
                name: "tblSizes");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblRoles");
        }
    }
}
