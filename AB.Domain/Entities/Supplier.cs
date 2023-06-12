using AB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Domain.Entities;

public class Supplier
{

    public Guid SupplierId { get; set; }

    public string Salutation { get; set; }

    public string Name1 { get; set; }

    public string Name2 { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string TaxId { get; set; }

    public CommunicationType PreferredCommunication { get; set; }

    public List<ContactPerson> ContactPersons { get; set; }
}
