namespace EXE201_2RE_API.Enums
{
    public class SD
    {
        private static SD instance;
        private SD()
        {
        }
        public static SD getInstance()
        {
            if (instance == null) instance = new SD();
            return instance;
        }
        public class GeneralStatus
        {
            public static string ACTIVE = "ACTIVE";
            public static string INACTIVE = "INACTIVE";
        }        
        
        public class CartStatus
        {
            public static string PENDING = "CHƯA THANH TOÁN";
            public static string PAID = "ĐANG VẬN CHUYỂN";
            public static string FINISHED = "ĐÃ HOÀN THÀNH";
            public static string CANCEL = "ĐÃ HỦY";
        }

        public class ProductStatus
        {
            public static string SOLDOUT = "SOLD OUT";
            public static string AVAILABLE = "AVAILABLE";
        }
}
}
