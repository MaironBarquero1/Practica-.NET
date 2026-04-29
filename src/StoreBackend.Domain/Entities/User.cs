using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace StoreBackend.Domain.Entities;

[Table("User")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

    [Required]
    public Guid ExternalId { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Required]
    [MaxLength(256)]
    public required string Passwordhash { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("Name")]
    public required string Name{get; set;}



}
