using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_2RE_API.Migrations
{
    public partial class updateEntities : Migration
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
                values: new object[] { new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), "address", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(898), "user1@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123456", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "shop1address", "shop1des", "shop1logo", "shop1", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(917), "user1" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), "address", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(954), "admin@gmail.com", false, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0912398765", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), null, null, null, null, new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(955), "admin" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "productId", "brand", "categoryId", "condition", "createdAt", "description", "genderCategoryId", "name", "price", "shopOwnerId", "sizeId", "status", "updatedAt" },
                values: new object[,]
                {
                    { new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), "Puma", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "89%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1250), "Quần jeans ôm thời trang cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Quần Jeans Ôm Nữ", 350000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1250) },
                    { new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1225), "Áo thun cổ điển dành cho nam, có nhiều kích cỡ", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Cổ Điển Nam", 200000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1226) },
                    { new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), "Adidas", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "80%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1308), "Áo thun cotton mềm mại dành cho trang phục thường ngày", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Cotton Nữ", 340000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1308) },
                    { new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), "Puma", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "85%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1295), "Quần jeans regular fit cổ điển", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Regular Fit Nam", 440000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1296) },
                    { new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), "Adidas", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "96%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1238), "Áo khoác thường cho ngày thường", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Thường Nam", 400000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1239) },
                    { new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), "Nike", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "70%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1301), "Áo khoác da cao cấp dành cho nam", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Khoác Da Nam", 280000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1302) },
                    { new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1232), "Quần jeans slim fit với kiểu dáng hiện đại", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Quần Jeans Slim Fit Nam", 300000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1233) },
                    { new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), "Adidas", new Guid("c5e1f2b8-2f4c-4b3d-b7a8-4c5e6f7d8b9a"), "99%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1255), "Áo khoác thời trang và ấm áp cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Khoác Thường Nữ", 500000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1256) },
                    { new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), "Nike", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "99%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1262), "Áo thun họa tiết thời trang với thiết kế đẹp", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Áo Thun Họa Tiết Nam", 290000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1262) },
                    { new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), "Adidas", new Guid("f8a8e1c5-4b3c-4e8f-b8ea-3f3f6e9c2f1a"), "90%", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1244), "Áo thun ôm thoải mái cho nữ", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Áo Thun Ôm Nữ", 250000m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Có sẵn", new DateTime(2024, 10, 6, 21, 41, 43, 660, DateTimeKind.Local).AddTicks(1245) }
                });

            migrationBuilder.InsertData(
                table: "tblProductImages",
                columns: new[] { "productImageId", "imageUrl", "productId" },
                values: new object[,]
                {
                    { new Guid("040d4bc4-bf62-46cd-bf11-db40fe29666b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("0f9435b2-627c-47d7-9ed7-024df4bd0e73"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("13034738-4373-4cc7-b3a4-3955a097a1f4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("18a5b7e5-0a9e-4813-a822-78a106b880ea"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("23394f2b-af2b-4bbf-8ab6-f82b56a2c8ec"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("2bf3cd11-2527-4b1a-94eb-71f79788a961"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("329f44c4-05d0-4cfd-a29e-9df939aaaee1"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("35d2bb64-a141-4572-8e5f-805723859a5a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("3c0bf920-16d5-4391-9463-460c067e66af"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("40a7182c-8bbb-45cb-b967-18220990f3bd"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("43e56a62-3be8-4126-8d80-fb77acef635c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("47547702-d01b-4eb7-9c3c-4c04934bca2f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("65c5a04c-9c54-45ff-9f44-8b7a48d1df1a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("6748689c-b9a6-40f7-9609-bad5c4ecef90"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("68b75258-4aea-497a-857b-d972b783c1fc"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("6a9e9c65-fd3b-46cd-ada7-10317ff986d8"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("738de10f-b987-40d6-883d-1562388c890e"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("78ad4454-bf28-489d-80bc-e933248cd24b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("78e1d543-81a1-4f4f-a624-a1bd29365620"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("8050d085-80c5-4a8f-9ac8-294871297d3b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("9f60d560-ae52-4a88-8623-fa9ede2bf4f7"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("a2b770b9-283a-47f7-89c2-03821b1d5c80"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("a7566b21-f160-4456-8a05-77002da4f7a9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("b4fb287c-2c78-4a7e-995c-8ba2492560f9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("b5301688-7a41-4e42-a54c-5ef7a2acf832"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("b63695ed-15d3-4664-847f-f259a5ff54e4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("b6d33659-a328-4385-a34b-4ec8f2d98b5d"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("ba49b96d-4fb1-460e-91a3-fd0247d977b0"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("be9d94dd-c198-4566-b734-8970d3d37947"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("c0b19fe7-5a29-4699-832c-cfe369314cb5"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("d4711190-456a-42b1-ae6d-d88b2d9187e4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("d5bdfae8-8697-4063-83bb-377dd9fec551"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("d74ef2a8-16b7-4bd3-b09f-a01844489b95"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("d773674c-6e85-4f05-bddd-c5a0260c5866"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("df86adf4-9c90-4690-8a66-9d3b0f71ea79"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("e20430b2-cfd9-4cb6-8ff6-1b70f8f291ce"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("e3ebb4e8-bb1d-4da1-874a-34594c749288"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("ed5caff0-b521-4bd0-bc40-6c93d673790c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("fe024b71-563b-447d-a573-3c9ef43aaef4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("fedb06d0-04e2-4128-aa7a-ad53bbe62e21"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") }
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
