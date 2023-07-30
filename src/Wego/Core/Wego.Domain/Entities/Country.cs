using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Countries", Schema = "config")]
public partial class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string Code { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
