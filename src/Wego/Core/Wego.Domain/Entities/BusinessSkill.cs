using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("BusinessSkills", Schema = "config")]
[Index("Code", Name = "NonClusteredIndex-20221014-011723", IsUnique = true)]
public partial class BusinessSkill
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Code { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; }
}
