namespace EXE201_2RE_API.DTOs
{
    public class CreateProductModel
    {
        public Guid? shopOwnerId { get; set; }

        public Guid? categoryId { get; set; }

        public Guid? genderCategoryId { get; set; }

        public Guid? sizeId { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public IFormFile imgUrl { get; set; }

        public string description { get; set; }

        public DateTime createdAt { get; set; }

    }
}
