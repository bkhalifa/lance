using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Regions", Schema = "config")]
public partial class Region
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Code { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public int? CountryId { get; set; }

    [InverseProperty("Region")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    [ForeignKey("CountryId")]
    [InverseProperty("Regions")]
    public virtual Country? Country { get; set; }
}
