using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("WorkTypes", Schema = "config")]
public partial class WorkType
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Code { get; set; }

    [InverseProperty("WorkType")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
