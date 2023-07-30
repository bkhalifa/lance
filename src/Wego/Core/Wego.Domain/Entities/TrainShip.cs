using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("TrainShip", Schema = "profile")]
public partial class TrainShip
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; }

    [StringLength(100)]
    public string Diploma { get; set; }

    public int? Year { get; set; }

    public long UserProfileId { get; set; }

    [ForeignKey("UserProfileId")]
    [InverseProperty("TrainShips")]
    public virtual UserProfile UserProfile { get; set; }
}
