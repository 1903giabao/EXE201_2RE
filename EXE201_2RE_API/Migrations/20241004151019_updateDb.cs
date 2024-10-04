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
                    { new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "Jackets" },
                    { new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "Jeans" },
                    { new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "T-Shirts" }
                });

            migrationBuilder.InsertData(
                table: "tblGenderCategories",
                columns: new[] { "genderCategoryId", "name" },
                values: new object[,]
                {
                    { new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Female" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Male" }
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
                values: new object[] { new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), "address", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8542), "user1@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123456", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "shop1address", "shop1des", "shop1logo", "shop1", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8550), "user1" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "userId", "address", "createdAt", "email", "isShopOwner", "passWord", "phoneNumber", "roleId", "shopAddress", "shopDescription", "shopLogo", "shopName", "updatedAt", "userName" },
                values: new object[] { new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), "address", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8584), "admin@gmail.com", false, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0912398765", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), null, null, null, null, new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8585), "admin" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "productId", "brand", "categoryId", "condition", "createdAt", "description", "genderCategoryId", "name", "price", "shopOwnerId", "sizeId", "status", "updatedAt" },
                values: new object[,]
                {
                    { new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a"), "Puma", new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "89%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8883), "Fashionable skinny jeans for women", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Women's Skinny Jeans", 34.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8883) },
                    { new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e"), "Nike", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "90%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8854), "Classic men's t-shirt in various sizes", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Men's Classic T-Shirt", 19.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8855) },
                    { new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e"), "Adidas", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "80%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8913), "Soft cotton t-shirt for casual wear", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Women's Cotton Tee", 18.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8914) },
                    { new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a"), "Puma", new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "85%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8901), "Classic regular fit jeans", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Men's Regular Fit Jeans", 44.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8901) },
                    { new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7"), "Adidas", new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "96%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8869), "Casual jacket for everyday wear", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Men's Casual Jacket", 49.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8870) },
                    { new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b"), "Nike", new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "70%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8907), "Premium leather jacket for men", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Men's Leather Jacket", 99.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8908) },
                    { new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d"), "Nike", new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "90%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8862), "Slim-fit jeans with a modern look", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Men's Slim Fit Jeans", 39.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8863) },
                    { new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10"), "Adidas", new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "99%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8889), "Stylish and warm jacket for women", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Women's Casual Jacket", 59.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8889) },
                    { new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f"), "Nike", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "99%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8895), "Trendy graphic t-shirt with cool design", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Men's Graphic Tee", 29.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8895) },
                    { new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f"), "Adidas", new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "90%", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8876), "Comfortable fitted t-shirt for women", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Women's Fitted T-Shirt", 24.99m, new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "Available", new DateTime(2024, 10, 4, 22, 10, 19, 299, DateTimeKind.Local).AddTicks(8876) }
                });

            migrationBuilder.InsertData(
                table: "tblProductImages",
                columns: new[] { "productImageId", "imageUrl", "productId" },
                values: new object[,]
                {
                    { new Guid("03e01310-5856-4a93-ac95-87763233cc8b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("0488dff5-bda3-42ca-8018-9cff649584de"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("0594097f-d341-4b48-8ffa-7465444a0ad5"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("07329016-67d5-4059-b1a6-9f3fa1d155c4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("18d3cf85-7586-488a-8960-1fa216999fcf"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("1b5f5eb9-cbd8-476b-b4c0-719b164cb884"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("1d10ba81-2afa-4787-a74f-f2f99d89d8aa"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("2222ba45-bc56-49e8-90d8-b286b1a84073"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("2854140f-ab5f-452e-9804-d9d064f60a03"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("2c5d2bb1-17ba-4c2f-9c19-c8e47bf0fc52"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("2f5d955b-536d-4597-850b-1496612fd53f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("382d7e43-3c56-493a-ae72-885185b195b9"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("413e2ca8-c88f-4402-800f-9b7a32a35502"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("4426d8b0-b024-4f26-87f9-b9e4b8f715bd"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("4d1d37d7-e91c-413f-8d59-29dc3a523933"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("4d362937-11f0-4d2d-b655-d6a31dc9365c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("600f9fdd-11e8-4f43-843e-cedb33098b9f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("616631be-d973-4f1f-bda7-930b51508834"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("68e224ae-3707-43c1-b8e0-26398ad1625c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("6f725601-2c98-462a-b6c1-11a911ba2223"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("72e7ab7e-a828-4123-8218-f1d27f7aa2f1"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("732f7960-8fe0-452a-a134-e72354f32656"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("7e602260-ead8-427e-a0e0-85b940ee1a0a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("8157f726-6df3-4e32-a39b-115283d862f4"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("5a6e2f3e-9c3e-4f87-9e8c-ea1d4f6e8b0e") },
                    { new Guid("8b965b0e-7cc7-4fb5-92be-2f7947927714"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("98f62ec8-a632-4113-a314-8dbeb0d90c0b"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("9c2b3e7d-4a8a-4b1c-9e3f-2f6e8a5d9b4e") },
                    { new Guid("9ac7eef3-029e-4775-83f9-68389396fd56"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("d1e7a8d2-1c34-4e91-bc1f-1a4e5f9a8e10") },
                    { new Guid("9bec261f-2d91-4d6a-8116-b66b93040913"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("c28c2e4e-2e0a-4a4f-b3e7-8c9a9b8d5c5d") },
                    { new Guid("9ec4b31a-d51b-4d06-b7d9-45100e434bca"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("abff0575-59af-4035-83a9-747f78e71801"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("e6b8f3b5-a4c5-4a2d-8e38-6d4c1e2a9a8f") },
                    { new Guid("c10d49bc-5f6d-40e5-ab51-e5b5f28bc0dd"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("cc237e0d-064f-4353-9bb9-15dd58f75eef"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("df8ceadb-2324-4324-9528-2826b77b674f"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("0b6c1c6c-2f3f-4d3a-9e1b-1d5e3e9b2c3a") },
                    { new Guid("e2cd81ef-aa0d-4b3a-a01f-3b75810e122c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("e7c16bfc-f353-49cf-9134-1981660c595a"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("a7c2d1f4-2b6e-4e18-bf7f-8d5e3f1b9c4a") },
                    { new Guid("e8204a60-7a6b-43d1-94ae-524ba92c1e4c"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b1f8c9e3-3e2b-4c4d-8e1a-2e6f5c3d8e0b") },
                    { new Guid("ef3e8157-431e-4ac6-ac4a-01ce255cfa37"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") },
                    { new Guid("f032bf6f-0d3e-4ba4-a2f0-e06fb0f391ad"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("f8439c4b-5605-4c19-a0bb-25a989c010d8"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("f2b7f7a4-6a34-43b0-bc18-4e8e3e8a7c8f") },
                    { new Guid("fb099a50-9c2f-4a2c-89bb-b80fe96a51ad"), "https://down-vn.img.susercontent.com/file/c7db377b177fc8e2ff75a769022dcc23", new Guid("b12cc9b8-4a9d-44e9-bf40-8b3e8e5cc8c7") }
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
