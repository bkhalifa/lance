using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("OffersSearch")]
public partial class OffersSearch
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [StringLength(100)]
    public string? CustomerName { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? AmountMin { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? AmountMax { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? AmountUnit { get; set; }

    public int? Duration { get; set; }

    [StringLength(100)]
    public string? LocationCode { get; set; }

    [StringLength(50)]
    public string? LocationName { get; set; }

    [StringLength(50)]
    public string? ContractTypeCode { get; set; }

    [StringLength(50)]
    public string? ContractTypeName { get; set; }

    [StringLength(100)]
    public string? CategoryCode { get; set; }

    [StringLength(100)]
    public string? CatgeoryName { get; set; }

    [StringLength(100)]
    public string? BusinessSkillCode { get; set; }

    [StringLength(100)]
    public string? BusinessSkillName { get; set; }

    [StringLength(100)]
    public string? JobLevelCode { get; set; }

    [StringLength(100)]
    public string? JobLevelName { get; set; }

    [StringLength(100)]
    public string? WorkTypeCode { get; set; }

    [StringLength(100)]
    public string? WorkTypeName { get; set; }

    public short? RemoteDays { get; set; }

    public int? ExperienceYear { get; set; }

    [StringLength(500)]
    public string? SkillCodes { get; set; }

    [StringLength(500)]
    public string? SkillNames { get; set; }

    [StringLength(100)]
    public string? SearchKeys { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }
}
