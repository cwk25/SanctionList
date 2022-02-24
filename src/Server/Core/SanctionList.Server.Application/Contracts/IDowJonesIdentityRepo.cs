using SanctionList.Server.Domain.DowJones;

namespace SanctionList.Server.Application.Contracts;

public interface IDowJonesIdentityRepo
{
    Task<IEnumerable<DowJonesIdentity>> Get(IEnumerable<int> identityIds);
}