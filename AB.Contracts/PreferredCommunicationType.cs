using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AB.Contracts
{
    public enum PreferredCommunicationType
    {
        [EnumMember(Value = "Email")]
        Email,

        [EnumMember(Value = "Postal")]
        Postal,
        
        [EnumMember(Value = "Phone")]
        Phone,

        [EnumMember(Value = "Phone")]
        Fax
    }
}
