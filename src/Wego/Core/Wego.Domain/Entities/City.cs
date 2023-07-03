using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Cities", Schema = "config")]
public partial class City
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Code { get; set; }

    [StringLength(10)]
    public string? ZipCode { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? PrincipalCityCode { get; set; }

    public int? RegionId { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("City")]
    public virtual ZipCode IdNavigation { get; set; } = null!;

    [ForeignKey("RegionId")]
    [InverseProperty("Cities")]
    public virtual Region? Region { get; set; }
}
