﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScorebookAV.Models;

public partial class ClassStudent
{
    public int ClassStudentId { get; set; }

    public int ClassId { get; set; }

    public int? StudentId { get; set; }

    public virtual Class Class { get; set; }

    public virtual Student Student { get; set; }
}