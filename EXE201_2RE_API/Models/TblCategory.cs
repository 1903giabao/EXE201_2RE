﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EXE201_2RE_API.Models;

public partial class TblCategory
{
    [Key]
    public Guid? categoryId { get; set; }

    public string? name { get; set; }

    public virtual ICollection<TblProduct>? tblProducts { get; set; } = new List<TblProduct>();
}