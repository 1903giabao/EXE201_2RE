﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EXE201_2RE_API.Models;

public partial class TblProduct
{
    public int Id { get; set; }

    public int? ShopOwnerId { get; set; }

    public int? CategoryId { get; set; }

    public int? GenderCategoryId { get; set; }

    public int? SizeId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string ImgUrl { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual TblCategory Category { get; set; }

    public virtual TblGenderCategory GenderCategory { get; set; }

    public virtual TblUser ShopOwner { get; set; }

    public virtual TblSize Size { get; set; }

    public virtual ICollection<TblCartDetail> TblCartDetails { get; set; } = new List<TblCartDetail>();

    public virtual ICollection<TblReview> TblReviews { get; set; } = new List<TblReview>();
}