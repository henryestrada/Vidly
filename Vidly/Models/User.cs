using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models;

public class User : IdentityUser
{
    [Required]
    [StringLength(255)]
    public string? DrivingLicense { get; set; }

    [Required]
    [StringLength(15)]
    public override string? PhoneNumber { get; set; }
}
