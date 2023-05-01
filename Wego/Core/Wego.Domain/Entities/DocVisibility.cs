using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("DocVisibility", Schema = "profile")]
[Index("DocId", Name = "UQ__DocVisib__3EF188ACE3774004", IsUnique = true)]
public partial class DocVisibility
{
    [Key]
    public long Id { get; set; }

    public bool? IsNowVisible { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long UserProfileId { get; set; }

    public long? DocId { get; set; }

    [ForeignKey("DocId")]
    [InverseProperty("DocVisibility")]
    public virtual Document? Doc { get; set; }
}
