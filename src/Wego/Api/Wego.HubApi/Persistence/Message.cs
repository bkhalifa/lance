using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.HubApi.Persistence;

[Table("Messages", Schema = "chat")]
public partial class Message
{
    [Key]
    public long Id { get; set; }

    public int ProfileFromId { get; set; }

    public int ProfileToId { get; set; }

    [StringLength(100)]
    public string Code { get; set; }

    [Required]
    [StringLength(500)]
    public string MsgContent { get; set; }

    public bool IsOpen { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }
}
