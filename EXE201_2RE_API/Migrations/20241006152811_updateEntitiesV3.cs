using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_2RE_API.Migrations
{
    public partial class updateEntitiesV3 : Migration
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
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), "address", new DateTime(2024, 10, 6, 22, 28, 10, 763, DateTimeKind.Local).AddTicks(9747), "user1@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123456", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "shop1address", "shop1des", "shop1logo", "shop1", new DateTime(2024, 10, 6, 22, 28, 10, 763, DateTimeKind.Local).AddTicks(9761), "user1" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), "address", new DateTime(2024, 10, 6, 22, 28, 10, 763, DateTimeKind.Local).AddTicks(9787), "admin@gmail.com", false, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0912398765", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), null, null, null, null, new DateTime(2024, 10, 6, 22, 28, 10, 763, DateTimeKind.Local).AddTicks(9787), "admin" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "productId", "brand", "categoryId", "condition", "createdAt", "description", "genderCategoryId", "name", "price", "shopOwnerId", "sizeId", "status", "updatedAt" },
                values: new object[,]
                {
                    { new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), "Puma", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "89%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(113), "Quần jeans ôm thời trang cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Quần Jeans Ôm Nữ", 350000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(114) },
                    { new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(60), "Áo thun cổ điển dành cho nam, có nhiều kích cỡ", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Cổ Điển Nam", 200000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(62) },
                    { new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), "Adidas", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "80%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(142), "Áo thun cotton mềm mại dành cho trang phục thường ngày", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Cotton Nữ", 340000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(143) },
                    { new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), "Puma", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "85%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(130), "Quần jeans regular fit cổ điển", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Regular Fit Nam", 440000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(131) },
                    { new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), "Adidas", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "96%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(74), "Áo khoác thường cho ngày thường", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Thường Nam", 400000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(74) },
                    { new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), "Nike", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "70%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(136), "Áo khoác da cao cấp dành cho nam", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Da Nam", 280000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(136) },
                    { new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(68), "Quần jeans slim fit với kiểu dáng hiện đại", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Slim Fit Nam", 300000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(68) },
                    { new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), "Adidas", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "99%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(119), "Áo khoác thời trang và ấm áp cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Khoác Thường Nữ", 500000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(119) },
                    { new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "99%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(125), "Áo thun họa tiết thời trang với thiết kế đẹp", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Họa Tiết Nam", 290000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(125) },
                    { new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), "Adidas", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(80), "Áo thun ôm thoải mái cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Ôm Nữ", 250000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 6, 22, 28, 10, 764, DateTimeKind.Local).AddTicks(81) }
                });

            migrationBuilder.InsertData(
                table: "tblProductImages",
                columns: new[] { "productImageId", "imageUrl", "productId" },
                values: new object[,]
                {
                    { new Guid("04532d17-85a2-47d7-83a2-b02e5e3e3ebd"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("104aadb9-6959-4aa1-b65f-04d1ef1f44a2"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("2167698f-f8ff-4a9d-bd2f-a58ed41a41ad"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("29b2dc39-b569-40a1-a18d-d6e41d0ce41a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("2b6eaaff-461c-434b-924f-512ce694c355"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("38ccadab-c7af-4aad-bc47-9c6e837caeec"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("452d2be4-7938-4d62-81af-f9f5eb68d37f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("4ce22b57-4aaf-4b6f-a0ff-e8f8a7fa902a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("5ae5a993-94e5-4316-bf86-2c61845538d6"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("5d00778c-e9dd-4793-a7a3-c87a6a58c63c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("5da8bc27-fc84-4779-9fb7-afd6cf0f5a7b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("60811964-3995-483c-8d80-d579d93def36"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("64e9dcd4-23f8-4866-84c7-356184ea9269"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("6c03c3bf-921d-48c4-a1c6-a2a97f87e01a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("6da7e8af-ce71-4bdf-bdab-5f91a4bd6c23"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("771467bf-9b39-4757-b133-b20452251096"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("7c1d90ef-cecd-4a78-994b-99fdf11d6730"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("84cbd5dc-de88-4813-b8fb-338c220fadf9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("8d5d8321-1ab8-454b-9261-072adfcd576d"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("902cedb1-5c00-4de5-a634-dd7d54595101"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("90cf103a-28e6-4a0c-a23e-f25ab7a36b94"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("916682fa-26d4-4ada-a2e2-df2b18de481a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("97c63aab-0089-418f-b045-e23cb0c9170c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("9805e741-dd5d-488f-a62a-63adaedb52c6"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("99094f86-125b-4460-a6a6-3b05a3029461"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("99ac65cd-ecbc-4e8a-a7aa-32f1452a3499"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("a5ad539c-6853-445a-a2ce-60609af173fa"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("a65b89ac-fbb9-41c9-aab0-c26c03d182b9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("a85f1a67-02d2-47ec-8bfd-83a3ef14404a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("b3844fdd-bef6-4986-985d-55e2798cba66"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("b45ada09-1647-4d78-832d-1709562b742a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("b7b0ecfb-79b3-405b-9a9b-c7ddb354f759"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("b7fd0300-51eb-4cef-bbee-c35ab2b1c4a0"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("ba5ed8c7-aeb2-4e6a-80cf-3d706d1b4371"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("bf7677e1-86cf-4ca9-973c-53d3fbea8086"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("c89b09fa-1318-4448-863f-1297f8237f3c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("d28887d5-ef91-41a8-aa7a-0622bda186d9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("d60b428a-3fa9-4463-b6b4-f4f40f5482c6"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("fdc47d46-e5cf-438d-8bf5-b644b2b9f151"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("fdf50997-3421-4c35-a35d-c2e236ec0b3c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") }
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
                name: "IX_tblReviews_userId",
                table: "tblReviews",
                column: "userId");

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
