﻿namespace EXE201_2RE_API.Request
{
    public class UpdateProfileRequest
    {
        public string passWord { get; set; } = null!;
        public string address { get; set; } = null!;
        public string phoneNumber { get; set; }
        public string shopName { get; set; }
        public string shopAddress { get; set; }
        public string shopDescription { get; set; }
        public string shopLogo { get; set; }
    }
}