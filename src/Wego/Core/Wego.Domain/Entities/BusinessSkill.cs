using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wego.Domain.Entities;

[Table("BusinessSkills", Schema = "config")]
public partial class BusinessSkill
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }
}
