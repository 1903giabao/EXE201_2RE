namespace EXE201_2RE_API.Response
{
    public class GetShopDetailResponse
    {
        public string shopName {  get; set; }
        public string shopLogo { get; set; }
        public string shopDescription { get; set; }
        public string shopAddress { get; set; }
        public int totalRating { get; set; }
        public int quantityRating { get; set; }
    }
}
