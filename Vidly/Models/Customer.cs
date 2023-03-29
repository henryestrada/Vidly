using System.ComponentModel.DataAnnotations;

namespace Vidly.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(150)]
    public string LastName { get; set; }

    [Display(Name = "Date of Birth")]
    public DateTime? Birthdate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }

    [Display(Name = "Membership Type")]
    public byte MembershipTypeId { get; set; }

    public virtual MembershipType MembershipType { get; set; }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}
