using Dapper;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Domain.DowJones;
using SanctionList.Server.Persistence.Configurations;
using SanctionList.Server.Shared.Caching.Services;

namespace SanctionList.Server.Persistence.Repositories;

public class DowJonesIdentityNameRepo : DowJonesRepo, IDowJonesIdentityNameRepo
{
    private readonly ICacheService _cache;
    public DowJonesIdentityNameRepo(DbConfig dbConfig, ICacheService cache) : base(dbConfig)
    {
        _cache = cache;
    }

    public async Task<IEnumerable<DowJonesIdentityName>> GetByPartition(char partition)
    {
        var partitionedIdentityNames = await _cache.GetOrCreate($"names_{partition}", async () =>
        {
            return (await Get()).Where(n => n.Name[0] == partition);
        });

        return partitionedIdentityNames;
    }

    private async Task<IEnumerable<DowJonesIdentityName>> Get()
    {
        const string sql = @"
            SELECT identityId, name, t.nameType
            FROM [dbo].[DowJonesIdentityName] n LEFT JOIN [dbo].[NameType] t
            ON n.nameTypeId = t.id";

        var result = await Connection.QueryAsync<DowJonesIdentityName>(sql);
        
        return result;
    }
}