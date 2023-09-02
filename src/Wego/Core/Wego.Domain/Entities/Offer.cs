using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

public partial class Offer
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; }

    public string Description { get; set; }

    [StringLength(250)]
    public string ShortDescription { get; set; }

    public long? CustomerId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? SalaryMin { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? SalaryMax { get; set; }

    public int? Duration { get; set; }

    public int? ZipCodeId { get; set; }

    public long? ContractTypeId { get; set; }

    public long? CatgeoryId { get; set; }

    public long? WorkTypeId { get; set; }

    public long? ExperienceYearId { get; set; }

    [StringLength(100)]
    public string SearchPreference { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [StringLength(450)]
    public string CreatedUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [StringLength(450)]
    public string UpdatedUserId { get; set; }

    [ForeignKey("CatgeoryId")]
    [InverseProperty("Offers")]
    public virtual Category Catgeory { get; set; }

    [ForeignKey("CatgeoryId")]
    [InverseProperty("Offers")]
    public virtual ContractType CatgeoryNavigation { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Offers")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("ExperienceYearId")]
    [InverseProperty("Offers")]
    public virtual ExperienceYear ExperienceYear { get; set; }

    [ForeignKey("WorkTypeId")]
    [InverseProperty("Offers")]
    public virtual WorkType WorkType { get; set; }

    [ForeignKey("ZipCodeId")]
    [InverseProperty("Offers")]
    public virtual ZipCode ZipCode { get; set; }

    [ForeignKey("OfferId")]
    [InverseProperty("Offers")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
