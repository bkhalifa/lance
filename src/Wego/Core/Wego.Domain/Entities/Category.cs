using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Categories", Schema = "config")]
[Index("Code", Name = "AK_Unique_Code", IsUnique = true)]
public partial class Category
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(100)]
    public string Code { get; set; }

    public short? Type { get; set; }

    [InverseProperty("Catgeory")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
