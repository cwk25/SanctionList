using SanctionList.Server.Domain.DowJones;

namespace SanctionList.Server.Application.Contracts;

public interface IDowJonesIdentityNameRepo
{
    Task<IEnumerable<DowJonesIdentityName>> GetByPartition(char partition);
}