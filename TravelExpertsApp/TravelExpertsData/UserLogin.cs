using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData;

[Table("UserLogin")]
public partial class UserLogin
{
    [Key]
    public int AgentId { get; set; }

    [MaxLength(64)]
    public byte[] HashedPassword { get; set; } = null!;

    [Column("isAdmin")]
    public bool IsAdmin { get; set; }

    [ForeignKey("AgentId")]
    [InverseProperty("UserLogin")]
    public virtual Agent Agent { get; set; } = null!;
}
