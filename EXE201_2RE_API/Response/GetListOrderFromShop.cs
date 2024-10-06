namespace EXE201_2RE_API.Response
{
    public class GetListOrderFromShop
    {
        public class CartShopModel
        {
            public Guid id { get; set; }
            public int totalQuantity { get; set; }
            public decimal totalPrice { get; set; }
            public string nameUser { get; set; }
        }
    }
}
