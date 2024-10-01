﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EXE201_2RE_API.Models;

public partial class TblReview
{
    [Key]
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Rating { get; set; }

    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual TblProduct Product { get; set; }

    public virtual TblUser User { get; set; }
}