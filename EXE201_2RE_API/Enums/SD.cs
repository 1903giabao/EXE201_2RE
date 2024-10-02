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

    }
}
