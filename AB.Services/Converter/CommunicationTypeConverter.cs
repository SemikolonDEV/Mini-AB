using AB.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Services.Converter;

internal class CommunicationTypeConverter
{

    public static CommunicationType ConvertFromBusinessValue
        (Domain.Enums.CommunicationType communicationType)
    {
        switch (communicationType)
        {
            case Domain.Enums.CommunicationType.Email:
                return CommunicationType.Email;
            case Domain.Enums.CommunicationType.Phone:
                return CommunicationType.Phone;
            case Domain.Enums.CommunicationType.Postal:
                return CommunicationType.Postal;
            case Domain.Enums.CommunicationType.Fax:
                return CommunicationType.Fax;
            default:
                var ex = new ArgumentException(
                $"Invalid Type of {nameof(Domain.Enums.CommunicationType)}: {communicationType}",
                nameof(communicationType));
                throw ex;
        }
    }

    public static Domain.Enums.CommunicationType ConvertToBusinessValue
        (CommunicationType communicationType)
    {
        switch (communicationType)
        {
            case CommunicationType.Email:
                return Domain.Enums.CommunicationType.Email;
            case CommunicationType.Postal:
                return Domain.Enums.CommunicationType.Postal;
            case CommunicationType.Fax:
                return Domain.Enums.CommunicationType.Fax;
            case CommunicationType.Phone:
                return Domain.Enums.CommunicationType.Phone;
            default:
                var ex = new ArgumentException(
                $"Invalid Type of {nameof(Domain.Enums.CommunicationType)}: {communicationType}",
                nameof(communicationType));
                throw ex;
        }
    }
}
