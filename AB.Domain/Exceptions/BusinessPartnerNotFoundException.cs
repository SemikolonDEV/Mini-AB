using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Domain.Exceptions;

public class BusinessPartnerNotFoundException : NotFoundException
{

    public BusinessPartnerNotFoundException(Guid businessPartnerId)
    : base ($"The BusinessPartner with the indetifier {businessPartnerId} was not found.")
        { }

}
