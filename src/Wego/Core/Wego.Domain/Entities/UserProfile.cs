using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wego.Domain.Entities;

[Table("UserProfiles", Schema = "profile")]
[Index("UsId", Name = "unqiue_usid", IsUnique = true)]
public partial class UserProfile
{
    [Key]
    public long Id { get; set; }

    [StringLength(450)]
    public string UserId { get; set; } = null!;

    [StringLength(250)]
    public string? FirstName { get; set; }

    [StringLength(250)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string? InitialUserName { get; set; }

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(250)]
    public string? Adress { get; set; }

    public int? PhoneNumber { get; set; }

    public bool IsActif { get; set; }

    [Required]
    public bool? IsVisible { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [StringLength(100)]
    public string? UsId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Country { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Region { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Position { get; set; }

    public string? Skills { get; set; }

    public string? Comment { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Category { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContractType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CategoryType { get; set; }

    public byte[]? Picture { get; set; }

    public int Completion { get; set; }

    [InverseProperty("UserProfile")]
    public virtual Document? Document { get; set; }

    [InverseProperty("UserProfile")]
    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    [InverseProperty("UserProfile")]
    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    [InverseProperty("UserProfile")]
    public virtual ICollection<TrainShip> TrainShips { get; set; } = new List<TrainShip>();
}
