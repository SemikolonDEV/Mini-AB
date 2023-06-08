using System.ComponentModel.DataAnnotations;

namespace AB.Contracts;

public class CustomerForCreationDto
{
    [Required]
    public string Salutaion { get; set; }

    [Required]
    public string Name1 { get; set; }

    public string? Name2 { get; set; }

    public string? Email { get; set; }

    public string? Iban { get; set; }

    public string? PhoneNumber { get; set; }


}
