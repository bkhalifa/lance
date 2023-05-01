using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

public partial class Log
{
    [Key]
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? Level { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeStamp { get; set; }

    public string? Exception { get; set; }

    public string? LogEvent { get; set; }

    [StringLength(200)]
    public string? UserName { get; set; }

    [Column("IP")]
    [StringLength(100)]
    public string? Ip { get; set; }

    [StringLength(100)]
    public string? Application { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Environment { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? StackTrace { get; set; }
}
