namespace AB.Domain.Entities;

public class ContactPerson
{

    public Guid ContactPersonId { get; set; }

    public Guid SupplierId { get; set; }

    public string Salutation { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Notes { get; set; }

}
