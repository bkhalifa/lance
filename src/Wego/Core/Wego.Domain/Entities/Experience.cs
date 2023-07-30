using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Experiences", Schema = "profile")]
public partial class Experience
{
    [Key]
    public long Id { get; set; }

    [StringLength(450)]
    public string Subject { get; set; }

    [StringLength(250)]
    public string Role { get; set; }

    [StringLength(250)]
    public string CompanyName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public long UserProfileId { get; set; }

    public string Skills { get; set; }

    public int StartYear { get; set; }

    public int? EndYear { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string StartMounth { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EndMounth { get; set; }

    [ForeignKey("UserProfileId")]
    [InverseProperty("Experiences")]
    public virtual UserProfile UserProfile { get; set; }
}
