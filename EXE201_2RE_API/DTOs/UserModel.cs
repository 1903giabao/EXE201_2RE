using EXE201_2RE_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201_2RE_API.DTOs
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Guid? RoleId { get; set; }

        public bool? IsShopOwner { get; set; }

        public string ShopName { get; set; }

        public string ShopAddress { get; set; }

        public string ShopDescription { get; set; }

        public string ShopLogo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
