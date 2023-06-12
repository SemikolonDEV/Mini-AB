using System.Runtime.Serialization;

namespace AB.Contracts
{
    public enum CommunicationType
    {
        [EnumMember(Value = "Email")]
        Email,

        [EnumMember(Value = "Postal")]
        Postal,

        [EnumMember(Value = "Phone")]
        Phone,

        [EnumMember(Value = "Fax")]
        Fax
    }
}
