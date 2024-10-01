using EXE201_2RE_API.Models;

namespace EXE201_2RE_API.Model
{
    public class ProductModel
    {
        public int Id { get; set; }

        public int? ShopOwnerId { get; set; }

        public int? CategoryId { get; set; }

        public int? GenderCategoryId { get; set; }

        public int? SizeId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
