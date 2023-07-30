using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wego.HubApi.Persistence;

[Table("Recruiters", Schema = "chat")]
public partial class Recruiter
{
    [Key]
    public long ProfileId { get; set; }

    [Required]
    [StringLength(250)]
    public string RecruiterName { get; set; }

    [Required]
    [StringLength(250)]
    public string RecruiterEmail { get; set; }

    [Required]
    [StringLength(250)]
    public string RecruiterCompany { get; set; }

    public bool IsConnected { get; set; }
}
