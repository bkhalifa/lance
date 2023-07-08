using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Wego.Domain.Entities;

[PrimaryKey("ProfileId", "OfferId")]
[Table("OfferProfileFavorite")]
public partial class OfferProfileFavorite
{
    [Key]
    public long ProfileId { get; set; }

    [Key]
    public long OfferId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
