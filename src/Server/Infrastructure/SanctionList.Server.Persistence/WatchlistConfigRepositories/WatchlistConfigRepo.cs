using System.Data.SqlClient;
using SanctionList.Server.Persistence.Configurations;

namespace SanctionList.Server.Persistence.WatchlistConfigRepositories;

public abstract class WatchlistConfigRepo
{
    protected readonly SqlConnection Connection;

    protected WatchlistConfigRepo(DbConfig dbConfig)
    {
        Connection = new SqlConnection(dbConfig.WatchlistConfigConnStr);
    }
}