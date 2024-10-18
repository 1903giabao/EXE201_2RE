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
        
        public class CartStatus
        {
            public static string PENDING = "CHƯA THANH TOÁN";
            public static string PAID = "ĐANG VẬN CHUYỂN";
            public static string FINISHED = "ĐÃ HOÀN THÀNH";
            public static string CANCEL = "ĐÃ HỦY";
        }

        public class ProductStatus
        {
            public static string SOLDOUT = "HẾT HÀNG";
            public static string AVAILABLE = "CÓ SẴN";
        }

        public class TransactionStatus
        {
            public static string PAID = "ĐÃ THANH TOÁN";
            public static string RECEIVED = "ĐÃ NHẬN";
            public static string PENDING = "CHƯA THANH TOÁN";
        }
    }
}
