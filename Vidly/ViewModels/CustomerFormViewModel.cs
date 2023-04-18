using System.Runtime.Serialization;
using Vidly.Models;

namespace Vidly.ViewModels;

[DataContract]
public class CustomerFormViewModel
{
    [DataMember]
    public IEnumerable<MembershipType> MembershipTypes { get; set; }

    [DataMember]
    public Customer Customer { get; set; }
}
