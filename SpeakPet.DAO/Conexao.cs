using System.Data.SqlClient;

namespace SpeakPet.DAL
{
    public static class Conexao
    {
        private static SqlConnection _conn;
        private static SqlConnection ObterConexao()
        {
            if (_conn == null)
                _conn = new SqlConnection("Data Source=LAPTOP-C57HCDC0\\SQLEXPRESS;Initial Catalog=SpeakPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return _conn;
        }

        public static SqlConnection GetConnection()
        {
            return ObterConexao();
        }
    }
}
