using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("ExperienceYears", Schema = "config")]
public partial class ExperienceYear
{
    [Key]
    public long Id { get; set; }

    public int? Years { get; set; }

    [InverseProperty("ExperienceYear")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
