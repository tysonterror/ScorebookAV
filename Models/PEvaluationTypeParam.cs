﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ScorebookAV.Models;

public partial class PEvaluationTypeParam
{
    public int EvaluationTypeParamId { get; set; }

    public int EvaluationTypeId { get; set; }

    public double Score { get; set; }

    public string Description { get; set; }

    public virtual PEvaluationType EvaluationType { get; set; }
}