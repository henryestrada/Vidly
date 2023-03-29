using System.Runtime.Serialization;
using Vidly.Models;

namespace Vidly.ViewModels;

[DataContract]
public class NewCustomerViewModel
{
    [DataMember]
    public IEnumerable<MembershipType> MembershipTypes { get; set; }

    [DataMember]
    public Customer Customer { get; set; }
}
