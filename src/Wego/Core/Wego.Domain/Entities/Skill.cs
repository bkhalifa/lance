using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Skills", Schema = "config")]
public partial class Skill
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? Code { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("Skills")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
