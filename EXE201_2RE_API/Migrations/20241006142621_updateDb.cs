using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_2RE_API.Migrations
{
    public partial class updateDb : Migration
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
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReviews", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_tblReviews_tblProducts_productId",
                        column: x => x.productId,
                        principalTable: "tblProducts",
                        principalColumn: "productId");
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
                values: new object[] { new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), "address", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7236), "user1@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123456", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "shop1address", "shop1des", "shop1logo", "shop1", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7248), "user1" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), "address", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7350), "admin@gmail.com", false, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0912398765", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), null, null, null, null, new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7351), "admin" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "address", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7320), "shop2@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123123", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "shop2address", "shop2des", "shop2logo", "shop2", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7321), "shop2" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "productId", "brand", "categoryId", "condition", "createdAt", "description", "genderCategoryId", "name", "price", "shopOwnerId", "sizeId", "status", "updatedAt" },
                values: new object[,]
                {
                    { new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), "Puma", new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "89%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7644), "Quần jeans ôm thời trang cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Quần Jeans Ôm Nữ", 350000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7644) },
                    { new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), "Nike", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "90%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7615), "Áo thun cổ điển dành cho nam, có nhiều kích cỡ", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Cổ Điển Nam", 200000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7617) },
                    { new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), "Adidas", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "80%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7676), "Áo thun cotton mềm mại dành cho trang phục thường ngày", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Cotton Nữ", 340000m, new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7677) },
                    { new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), "Puma", new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "85%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7665), "Quần jeans regular fit cổ điển", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Regular Fit Nam", 440000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7665) },
                    { new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), "Adidas", new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "96%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7632), "Áo khoác thường cho ngày thường", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Thường Nam", 400000m, new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7632) },
                    { new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), "Nike", new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "70%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7670), "Áo khoác da cao cấp dành cho nam", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Da Nam", 280000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7671) },
                    { new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), "Nike", new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "90%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7626), "Quần jeans slim fit với kiểu dáng hiện đại", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Slim Fit Nam", 300000m, new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7626) },
                    { new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), "Adidas", new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "99%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7651), "Áo khoác thời trang và ấm áp cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Khoác Thường Nữ", 500000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7652) },
                    { new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), "Nike", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "99%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7658), "Áo thun họa tiết thời trang với thiết kế đẹp", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Họa Tiết Nam", 290000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7659) },
                    { new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), "Adidas", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "90%", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7637), "Áo thun ôm thoải mái cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Ôm Nữ", 250000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 6, 21, 26, 21, 14, DateTimeKind.Local).AddTicks(7638) }
                });

            migrationBuilder.InsertData(
                table: "tblProductImages",
                columns: new[] { "productImageId", "imageUrl", "productId" },
                values: new object[,]
                {
                    { new Guid("047aa3a9-1479-47e9-8f77-6ccf35f07a0c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("0481c515-5fb4-46d5-89d1-f2a07e9075dd"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("068534a9-ea90-4227-b969-0e3cdf612736"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("0b02f17f-65d5-4894-9f34-860f1c0327fc"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("10e5cfd8-1d15-4e08-8bdd-afd8fc49a622"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("125c0e2c-7d06-4d88-a681-d9b4edb3e222"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("174f3e29-82c3-49e7-b0f6-a8179dc0d256"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("268ddac1-f2bd-4a7e-b568-62995b24977f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("2861560c-d9c2-4e95-991d-8a0ad062f24f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("290befb5-2c30-4159-9e75-4f18cd2a7da9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("33478450-5088-4980-aedc-e433ce33bb91"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("41754043-05e7-4673-9f30-a6a4870b920e"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("418f39b3-e3ba-4d65-b9a6-1edf6acd64c4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("504b2f21-4ad0-40a2-bace-3920231762cb"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("5371f5db-d27e-4d34-a156-b24455a89386"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("5c8f0147-e288-4dc0-9df3-5af5ec64eb5d"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("64c6d15d-d9d6-4864-af10-047356981462"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("6eae6770-7f72-46da-86f2-97141da26211"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("7571fbf6-6afb-49c0-8f9a-90a19950d5d3"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("82e9aa95-065a-4368-8de4-3a8623c4ea46"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("8a7a32df-c720-44e5-87fc-9cdae8933d1d"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("9fa4c63d-6a45-45c3-9d85-ac8c6cd24687"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("a0ae380a-8985-43c0-812e-dcbc08daa500"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("a65aa6e6-e344-4be5-afbc-8cf5dd7e0503"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("ad3baeb0-b6bd-4d71-8409-4846dbab8413"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("b5f6552e-bdff-41bc-a6e0-2f60f39d4f5d"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("b922c4a7-1aca-4ed7-86f1-f6fd73926828"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("c022a63a-0831-4395-9d81-d6efcb193713"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("c2eee380-90a5-4c97-8044-d4c0bcb0c835"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("c374a3ec-bfdd-42cc-a658-d0f116a95a12"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("c4b23605-765d-4c6d-b74d-8006157b5524"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("c51f1244-32d0-4cc2-8b10-e7702a9acb06"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("cc514a41-832a-49a5-8df0-e49d72e72e2b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("cc7da5e1-f97c-4eac-a401-11ad18c13c33"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("d1613990-b95b-4d0c-8b95-883b929e3801"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("da49f2c8-fff9-434d-9108-64db01b702e4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("dce55007-ab78-461c-a692-b2ddd7ae389a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("dd75582e-b01e-4a36-9829-559d83a28521"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("f10a5e03-e30f-4f94-b973-77e2f3cb7446"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("f4be140f-d11b-484f-81a8-feaeba6471c1"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") }
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
                name: "IX_tblReviews_productId",
                table: "tblReviews",
                column: "productId");

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
