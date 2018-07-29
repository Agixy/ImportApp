using System.Configuration;

namespace ImportApp
{
    public static class Connections
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
    }
}
