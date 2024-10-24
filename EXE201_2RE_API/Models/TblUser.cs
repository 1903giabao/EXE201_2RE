﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EXE201_2RE_API.Models;

public partial class TblUser
{
    [Key]
    public Guid? userId { get; set; }

    public string? userName { get; set; }

    public string? passWord { get; set; }

    public string? email { get; set; }

    public string? address { get; set; }

    public string? phoneNumber { get; set; }
                 
    public Guid? roleId { get; set; }
                 
    public bool? isShopOwner { get; set; }
                 
    public string? shopName { get; set; }
                 
    public string? shopAddress { get; set; }
                 
    public string? shopDescription { get; set; }
                 
    public string? shopLogo { get; set; }

    public string? shopBankId { get; set; }

    public string? shopBank { get; set; }

    public DateTime? createdAt { get; set; }

    public DateTime? updatedAt { get; set; }

    public virtual TblRole? role { get; set; }

    public virtual ICollection<TblCart>? tblCarts { get; set; } = new List<TblCart>();

    public virtual ICollection<TblProduct>? tblProducts { get; set; } = new List<TblProduct>();

    public virtual ICollection<TblReview>? reviewsWritten { get; set; } = new List<TblReview>();
    public virtual ICollection<TblReview>? reviewsReceivedAsShop { get; set; } = new List<TblReview>();
    public virtual ICollection<TblFavorite>? tblFavorites { get; set; } = new List<TblFavorite>();

}