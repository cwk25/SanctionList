using System.Text.Json.Serialization;

namespace SanctionList.Server.Domain.DowJones;

public class DowJonesIdentityName
{
    public int IdentityId { get; set; }
    public string Name { get; set; }
    public string NameType { get; set; }

}