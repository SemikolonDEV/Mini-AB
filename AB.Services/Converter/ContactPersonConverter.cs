using AB.Contracts;
using AB.Domain.Entities;

namespace AB.Services.Converter;

internal static class ContactPersonConverter
{

    public static ContactPersonDto ConvertToDto(this ContactPerson contactPerson)
    {
        var dto = new ContactPersonDto
        {
            Salutation = contactPerson.Salutation,
            Name = contactPerson.Name,
            Email = contactPerson.Email,
            PhoneNumer = contactPerson.PhoneNumber,
            Notes = contactPerson.Notes,
        };
        return dto;
    }

    public static ContactPerson ConvertToBusinessType(this ContactPersonDto dto)
    {
        var contactPerson = new ContactPerson
        {
            Salutation = dto.Salutation,
            Name = dto.Name,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumer,
            Notes = dto.Notes,
        };
        return contactPerson;
    }

    public static List<ContactPerson> ConvertToContactPersonList(this IEnumerable<ContactPersonDto> contactPersons)
    {
        return contactPersons.Select(x => x.ConvertToBusinessType()).ToList();
    }

    public static IEnumerable<ContactPersonDto> ConvertToContactPersonDtoList(this List<ContactPerson> contactPersons)
    {
        return contactPersons.Select(x => x.ConvertToDto());
    }
}
