using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Vidly.Models;

[DataContract]
public class Customer
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "First Name")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [DataMember]
    [Required]
    [Display(Name = "Last Name")]
    [StringLength(150)]
    public string LastName { get; set; }

    [DataMember]
    [Display(Name = "Date of Birth")]
    public DateTime? Birthdate { get; set; }

    [DataMember]
    public bool IsSubscribedToNewsletter { get; set; }

    [DataMember]
    [Display(Name = "Membership Type")]
    public byte MembershipTypeId { get; set; }

    [DataMember]
    public virtual MembershipType MembershipType { get; set; }

    [DataMember]
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}
