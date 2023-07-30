using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[Table("Documents", Schema = "profile")]
[Index("UserProfileId", Name = "UQ__Document__9E267F63FD55440F", IsUnique = true)]
public partial class Document
{
    [Key]
    public long Id { get; set; }

    public long UserProfileId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ContentType { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string DocName { get; set; }

    public byte[] FileData { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Extension { get; set; }

    [Required]
    public bool? IsVisible { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdateDate { get; set; }

    [Required]
    [StringLength(450)]
    public string UserId { get; set; }

    [StringLength(250)]
    public string FirstName { get; set; }

    [StringLength(250)]
    public string LastName { get; set; }

    [ForeignKey("UserProfileId")]
    [InverseProperty("Document")]
    public virtual UserProfile UserProfile { get; set; }
}
