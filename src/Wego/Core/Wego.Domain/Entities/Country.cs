using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wego.Domain.Entities;

[Table("Countries", Schema = "config")]
public partial class Country
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Country")]
    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
