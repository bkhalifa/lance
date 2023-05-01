using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Languages", Schema = "profile")]
public partial class Language
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string? Laguage { get; set; }

    [StringLength(50)]
    public string? Level { get; set; }

    public long UserProfileId { get; set; }

    [ForeignKey("UserProfileId")]
    [InverseProperty("Languages")]
    public virtual UserProfile UserProfile { get; set; } = null!;
}
