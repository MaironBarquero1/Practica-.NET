using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities;

[Table("User")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public Guid UserResourceId { get; set; }

    [Required]
    public Guid ExternalId { get; set; }

    [Column("Name")]
    [StringLength(50)]
    [Required]
    public required string Name { get; set; }

    [Column("Username")]
    [StringLength(50)]
    [Required]
    public required string Username { get; set; }

    [Column("Email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("PasswordHash")]
    [StringLength(256)]
    public string? PasswordHash { get; set; } = string.Empty;

    public List<UserRole> UserRoles { get; set; } = [];
    public void ClearRoles()
    {
        UserRoles.Clear();
    }
}