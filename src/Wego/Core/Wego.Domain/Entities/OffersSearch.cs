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
    public string? Description { get; set; }

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
    public string? SeniorityCode { get; set; }

    [StringLength(100)]
    public string? WorkTypeCode { get; set; }

    [StringLength(500)]
    public string? SkillCodes { get; set; }

    [StringLength(500)]
    public string? SkillNames { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PublicationDate { get; set; }
}
