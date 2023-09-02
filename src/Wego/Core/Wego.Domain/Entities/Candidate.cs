using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wego.Domain.Entities;

[Table("Candidates", Schema = "chat")]
public partial class Candidate
{
    [Key]
    public long ProfileId { get; set; }

    [Required]
    [StringLength(250)]
    public string CandidateName { get; set; }

    [Required]
    [StringLength(250)]
    public string CandidateEmail { get; set; }

    public bool IsConnected { get; set; }

    [StringLength(50)]
    public string ConnectionId { get; set; }
}
