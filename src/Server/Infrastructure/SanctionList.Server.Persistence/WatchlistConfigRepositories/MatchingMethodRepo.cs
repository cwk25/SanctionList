using Dapper;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Domain.WatchlistConfig;
using SanctionList.Server.Persistence.Configurations;

namespace SanctionList.Server.Persistence.WatchlistConfigRepositories;

public class MatchingMethodRepo : WatchlistConfigRepo, IMatchingMethodRepo
{
    public MatchingMethodRepo(DbConfig dbConfig) : base(dbConfig)
    {
    }

    public Task<IEnumerable<MatchingMethod>> Get()
    {
        const string sql = @"
            SELECT id, method
            FROM [dbo].[MatchingMethod] WITH (NOLOCK)";

        return Connection.QueryAsync<MatchingMethod>(sql);
    }
}