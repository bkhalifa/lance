using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("ZipCodes", Schema = "config")]
public partial class ZipCode
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Code { get; set; }

    [Column("ZipCode")]
    [StringLength(10)]
    public string? ZipCode1 { get; set; }

    [StringLength(10)]
    public string? ZipCodeSecondary { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? NameSecondary { get; set; }

    [StringLength(50)]
    public string? Gps { get; set; }

    public long? CityId { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual City? City { get; set; }

    [InverseProperty("ZipCode")]
    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
