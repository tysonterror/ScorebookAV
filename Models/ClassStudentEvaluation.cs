﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScorebookAV.Models;

public partial class ClassStudentEvaluation
{
    public int ClassStudentEvaluationId { get; set; }

    public int? ClassEvaluationId { get; set; }

    public int? EvaluationTypeId { get; set; }

    public int? StudentId { get; set; }

    public double? Score { get; set; }

    public string Remarks { get; set; }

    public virtual ClassEvaluation ClassEvaluation { get; set; }

    public virtual PEvaluationType EvaluationType { get; set; }

    public virtual Student Student { get; set; }
}