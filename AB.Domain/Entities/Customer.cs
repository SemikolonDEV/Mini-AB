using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Domain.Entities;

public class Customer
{ 

    public Guid CustomerId { get; set; }

    public string Salutation { get; set; }

    public string Name1 { get; set; }

    public string Name2 { get; set; }

    public string Email { get; set; }

    public string Iban { get; set; }

    public string PhoneNumber { get; set; }

}
