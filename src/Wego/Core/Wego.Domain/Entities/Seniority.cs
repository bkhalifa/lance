using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Seniorities", Schema = "config")]
public partial class Seniority
{
    [Key]
    public short Id { get; set; }

    [StringLength(50)]
    public string Code { get; set; }

    [StringLength(50)]
    public string Name { get; set; }
}
