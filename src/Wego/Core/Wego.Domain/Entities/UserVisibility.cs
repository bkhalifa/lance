using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("UserVisibility", Schema = "profile")]
public partial class UserVisibility
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("isVisble")]
    public bool IsVisble { get; set; }

    [Column("userProfileId")]
    public long? UserProfileId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdateDate { get; set; }

    [ForeignKey("UserProfileId")]
    [InverseProperty("UserVisibilities")]
    public virtual UserProfile UserProfile { get; set; }
}
