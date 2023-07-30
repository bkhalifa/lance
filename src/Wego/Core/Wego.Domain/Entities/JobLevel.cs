using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("JobLevel", Schema = "config")]
public partial class JobLevel
{
    [Key]
    public short Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Code { get; set; }
}
