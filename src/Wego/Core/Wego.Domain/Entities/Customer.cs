using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

public partial class Customer
{
    [Key]
    public long Id { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public int? ImageId { get; set; }

    [StringLength(10)]
    public string? Code { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
