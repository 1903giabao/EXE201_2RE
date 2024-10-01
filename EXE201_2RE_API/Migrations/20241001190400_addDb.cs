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
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    GenderCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
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
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
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
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopOwnerId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    GenderCategoryId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
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
                    OrderHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
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
                    CartDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
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
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
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
