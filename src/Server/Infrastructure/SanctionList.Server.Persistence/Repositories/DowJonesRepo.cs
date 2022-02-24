using System.Data.SqlClient;
using Dapper;
using SanctionList.Server.Domain.DowJones;
using SanctionList.Server.Persistence.Configurations;

namespace SanctionList.Server.Persistence.Repositories;

public abstract class DowJonesRepo
{
    protected readonly SqlConnection Connection;

    protected DowJonesRepo(DbConfig dbConfig)
    {
        Connection = new SqlConnection(dbConfig.DowJonesConnectionStr);
    }
}