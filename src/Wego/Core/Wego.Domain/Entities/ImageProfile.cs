using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wego.Domain.Entities;

[Table("ImageProfile", Schema = "profile")]
public partial class ImageProfile
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string ImageData { get; set; }

    public Byte? Width { get; set; }

    public Byte? Height { get; set; }

    public long? PorifleId { get; set; }

    [ForeignKey("PorifleId")]
    [InverseProperty("ImageProfiles")]
    public virtual UserProfile Porifle { get; set; }
}
