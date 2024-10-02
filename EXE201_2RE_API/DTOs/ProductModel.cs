using EXE201_2RE_API.Models;

namespace EXE201_2RE_API.DTOs
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }

        public Guid? ShopOwnerId { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? GenderCategoryId { get; set; }

        public Guid? SizeId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
