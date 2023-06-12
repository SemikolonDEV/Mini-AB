using System.Runtime.Serialization;

namespace AB.Contracts;

public class SupplierDto
{

    public Guid Id { get; set; }

    public string Salutation { get; set; }

    public string Name1 { get; set; }

    public string Name2 { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string TaxId { get; set; }

    [DataMember(Name = "PreferredCommunication", EmitDefaultValue = true)]
    public CommunicationType PreferredCommunication { get; set; }

    public IEnumerable<ContactPersonDto> ContactPersons { get; set; }

}
