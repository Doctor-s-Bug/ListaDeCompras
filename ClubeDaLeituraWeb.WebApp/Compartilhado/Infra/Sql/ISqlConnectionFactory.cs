using Microsoft.Data.SqlClient;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Sql;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}
