using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201_2RE_API.Request
{
    public class SignupRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public bool IsShopOwner { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopDescription { get; set; }
        public string ShopLogo { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }
}
