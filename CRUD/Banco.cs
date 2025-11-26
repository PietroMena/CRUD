using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal class Banco
    {
        private string stringConnection =
    "Data Source=\"Data Source=localhost; Initial Catalog=FinanceiroDB; User ID=usuario; password=senha; language=Portuguese; TrustServerCertificate=true;";

        private SqlConnection cn;
        public SqlConnection Cn { get => cn; set => cn = value; }

        private void Connection()
        {
            cn = new SqlConnection(stringConnection);
        }

        public SqlConnection openConnection()
        {
            try
            {
                Connection();
                cn.Open();

                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void closeConnection()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public DataTable executeQuery(string sql)
        {
            try
            {
                openConnection();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
