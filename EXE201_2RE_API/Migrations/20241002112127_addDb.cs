using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_2RE_API.Migrations
{
    public partial class addDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblGenderCategories",
                columns: table => new
                {
                    GenderCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenderCategories", x => x.GenderCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblSizes",
                columns: table => new
                {
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsShopOwner = table.Column<bool>(type: "bit", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblRoles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "tblCarts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCarts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_tblCarts_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GenderCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_tblProducts_tblGenderCategories_GenderCategoryId",
                        column: x => x.GenderCategoryId,
                        principalTable: "tblGenderCategories",
                        principalColumn: "GenderCategoryId");
                    table.ForeignKey(
                        name: "FK_tblProducts_tblSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "tblSizes",
                        principalColumn: "SizeId");
                    table.ForeignKey(
                        name: "FK_tblProducts_tblUsers_ShopOwnerId",
                        column: x => x.ShopOwnerId,
                        principalTable: "tblUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "tblOrderHistories",
                columns: table => new
                {
                    OrderHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderHistories", x => x.OrderHistoryId);
                    table.ForeignKey(
                        name: "FK_tblOrderHistories_tblCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCarts",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateTable(
                name: "tblCartDetails",
                columns: table => new
                {
                    CartDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartDetails", x => x.CartDetailId);
                    table.ForeignKey(
                        name: "FK_tblCartDetails_tblCarts_CartId",
                        column: x => x.CartId,
                        principalTable: "tblCarts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_tblCartDetails_tblProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "tblFavorites",
                columns: table => new
                {
                    FavoriteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFavorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_tblFavorites_tblProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFavorites_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblReviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_tblReviews_tblProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tblProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_tblReviews_tblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("a5e1d2b3-2f3c-4b3d-b7a8-4c5e6f7d8b9a"), "Jackets" },
                    { new Guid("d9b4c8c3-3a2e-4b9b-b9f7-5e6a7c8e9f0b"), "Jeans" },
                    { new Guid("f1aee1c7-6d5e-4e87-a5ea-3a5d6e7c8f9a"), "T-Shirts" }
                });

            migrationBuilder.InsertData(
                table: "tblGenderCategories",
                columns: new[] { "GenderCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Female" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Male" }
                });

            migrationBuilder.InsertData(
                table: "tblRoles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), "Admin" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "User" }
                });

            migrationBuilder.InsertData(
                table: "tblSizes",
                columns: new[] { "SizeId", "SizeName" },
                values: new object[,]
                {
                    { new Guid("a7c3f9b8-8e6f-4f0e-bc9f-4b85b6c5f4a5"), "XL" },
                    { new Guid("d4f1c0e1-2d41-4f0e-bc9f-4b85b6c5f4a2"), "S" },
                    { new Guid("e5a1b4d6-5c4c-4f0e-bc9f-4b85b6c5f4a3"), "M" },
                    { new Guid("f6b2e8a7-7d5f-4f0e-bc9f-4b85b6c5f4a4"), "L" }
                });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "IsShopOwner", "Password", "PhoneNumber", "RoleId", "ShopAddress", "ShopDescription", "ShopLogo", "ShopName", "UpdatedAt", "Username" },
                values: new object[] { new Guid("b1a3e477-9f5e-4bff-ae0a-5e8b42e0f8a0"), "address", new DateTime(2024, 10, 2, 18, 21, 27, 347, DateTimeKind.Local).AddTicks(6603), "user1@gmail.com", true, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0909123456", new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "shop1address", "shop1des", "shop1logo", "shop1", new DateTime(2024, 10, 2, 18, 21, 27, 347, DateTimeKind.Local).AddTicks(6613), "user1" });

            migrationBuilder.InsertData(
                table: "tblUsers",
                columns: new[] { "UserId", "Address", "CreatedAt", "Email", "IsShopOwner", "Password", "PhoneNumber", "RoleId", "ShopAddress", "ShopDescription", "ShopLogo", "ShopName", "UpdatedAt", "Username" },
                values: new object[] { new Guid("e2c3c2b1-5a1f-4c4f-b1ea-6b2c4f8e1a0b"), "address", new DateTime(2024, 10, 2, 18, 21, 27, 347, DateTimeKind.Local).AddTicks(6649), "admin@gmail.com", false, "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "0912398765", new Guid("c9ebf5d5-d6b4-4c1d-bc12-fc4b8f1f4c61"), null, null, null, null, new DateTime(2024, 10, 2, 18, 21, 27, 347, DateTimeKind.Local).AddTicks(6649), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetails_CartId",
                table: "tblCartDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetails_ProductId",
                table: "tblCartDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCarts_UserId",
                table: "tblCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavorites_ProductId",
                table: "tblFavorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavorites_UserId",
                table: "tblFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderHistories_CartId",
                table: "tblOrderHistories",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_GenderCategoryId",
                table: "tblProducts",
                column: "GenderCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_ShopOwnerId",
                table: "tblProducts",
                column: "ShopOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_SizeId",
                table: "tblProducts",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_ProductId",
                table: "tblReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblReviews_UserId",
                table: "tblReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_RoleId",
                table: "tblUsers",
                column: "RoleId");
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
