﻿namespace EXE201_2RE_API.Response
{
    public class GetAllProductFromShopResponse
    {
        public Guid productId { get; set; }
        public Guid categoryId { get; set; }
        public Guid genderCategoryId { get; set; }
        public Guid sizeId { get; set; }
        public string categoryName { get; set; }
        public string genderCategoryName { get; set; }
        public string sizeName { get; set; }    
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string brand {  get; set; }
       
    }
}