using SanctionList.Server.Domain.WatchlistConfig;

namespace SanctionList.Server.Application.Contracts;

public interface IMatchingCriteriaRepo
{
    Task<MatchingCriteria> Get();
    Task Update(MatchingCriteria criteria);
}