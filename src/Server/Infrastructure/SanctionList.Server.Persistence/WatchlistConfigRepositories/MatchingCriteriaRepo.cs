using Dapper;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Domain.WatchlistConfig;
using SanctionList.Server.Persistence.Configurations;

namespace SanctionList.Server.Persistence.WatchlistConfigRepositories;

public class MatchingCriteriaRepo : WatchlistConfigRepo, IMatchingCriteriaRepo
{
    public MatchingCriteriaRepo(DbConfig dbConfig) : base(dbConfig)
    {
    }

    public Task<MatchingCriteria> Get()
    {
        const string sql = @"
            SELECT matchingMethodId, returnOnMatchRatio, method MatchingMethod
            FROM [dbo].[MatchingCriteria] c WITH (NOLOCK) LEFT JOIN [dbo].[MatchingMethod] m
            ON c.matchingMethodId = m.id
            ";

        return Connection.QuerySingleAsync<MatchingCriteria>(sql);
    }

    public Task Update(MatchingCriteria criteria)
    {
        const string sql = @"
            UPDATE [dbo].[MatchingCriteria]
            SET matchingMethodId = @matchingMethodId, returnOnMatchRatio = @returnOnMatchRatio;";

        return Connection.QueryAsync(sql, criteria);
    }
}