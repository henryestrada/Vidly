using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vidly.Validations;

namespace Vidly.DTO;

public class CustomerDto
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [DataMember]
    [Required]
    [StringLength(150)]
    public string LastName { get; set; }

    [DataMember]
    [Min18YearsIfAMember]
    public DateTime? Birthdate { get; set; }

    [DataMember]
    public bool IsSubscribedToNewsletter { get; set; }

    [DataMember]
    [Required(ErrorMessage = "The Membership Type field is required.")]
    public byte? MembershipTypeId { get; set; }

    [DataMember]
    public MembershipTypeDto MembershipType { get; set; }

    [DataMember]
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}