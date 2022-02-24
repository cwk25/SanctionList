using Dapper;
using SanctionList.Server.Application.Contracts;
using SanctionList.Server.Domain.DowJones;
using SanctionList.Server.Persistence.Configurations;

namespace SanctionList.Server.Persistence.Repositories;

public class DowJonesIdentityRepo : DowJonesRepo, IDowJonesIdentityRepo
{
    public DowJonesIdentityRepo(DbConfig dbConfig) : base(dbConfig)
    {
    }

    public Task<IEnumerable<DowJonesIdentity>> Get(IEnumerable<int> identityIds)
    {
        const string sql = @"
            SELECT i.id, 
	               dowJonesId,
	               idNo,
	               idType.idType,
	               identityType.identityType,
	               gender,
	               dob,
	               hasSanction,
	               hasOccupation,
	               hasRelationship,
	               hasOtherList,
	               isActive,
	               citizenship
            FROM [dbo].[DowJonesIdentity] i LEFT JOIN [dbo].IdNoType idType
            ON i.idTypeId = idType.id LEFT JOIN [dbo].[IdentityType] identityType
            ON i.indOrgTypeId = identityType.id LEFT JOIN [dbo].[DateType] dateType
            ON i.dobTypeId = dateType.id
            WHERE i.id IN @identityIds";

        return Connection.QueryAsync<DowJonesIdentity>(sql, new { identityIds = identityIds.ToArray()});
    }
}