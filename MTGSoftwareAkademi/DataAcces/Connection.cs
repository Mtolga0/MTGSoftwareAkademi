using System.Data.SqlClient;
namespace DataAcces
{
    public class Connection
    {
        public static SqlConnection bgl = new SqlConnection(@"Data Source=MTG;Initial Catalog=Db_MTGSoft;Integrated Security=True;");

    }
}
