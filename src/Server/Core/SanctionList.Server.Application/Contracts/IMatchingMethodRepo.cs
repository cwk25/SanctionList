using SanctionList.Server.Domain.WatchlistConfig;

namespace SanctionList.Server.Application.Contracts;

public interface IMatchingMethodRepo
{
    Task<IEnumerable<MatchingMethod>> Get();
}