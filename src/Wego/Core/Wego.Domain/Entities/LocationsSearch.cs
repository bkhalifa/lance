using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("LocationsSearch")]
public partial class LocationsSearch
{
    [Key]
    public int Id { get; set; }

    public int IdRef { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string ZipCode { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Code { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; }

    public short LocationType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ParentName { get; set; }

    public bool? IsPriority { get; set; }

    public bool? DefaultOrder { get; set; }
}
