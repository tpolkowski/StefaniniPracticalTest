using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace App.Models.Dal
{
    /// <summary>
    /// the class makes a communication between the application and the db
    /// </summary>
    public class DbInterface
    {
        //database connection string
        const string _conect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Miguel\Desktop\Stefanini\App\App\App_Data\Database.mdf;Integrated Security=True";
            
        //sets sql connection instance
        SqlConnection conn = new SqlConnection(_conect);

        //execute the query on db and return the result
        public List<Dictionary<string, string>> Find(string query)
        {
            conn.Open();

            //criando o select e o objeto de consulta
            string sql = query;
            SqlCommand cmd = new SqlCommand(sql, conn);

            //Pegando valores e colocando no DataTable 
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dados = ds.Tables[0];

            Dictionary<string, string> columns = new Dictionary<string, string>();
            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

            foreach (DataRow row in dados.Rows)
            {
                columns = new Dictionary<string, string>();
                foreach (DataColumn column in dados.Columns)
                {
                    columns.Add(column.ColumnName, row[column.Ordinal].ToString());
                }
                rows.Add(columns);
            }
            conn.Close();

            return rows;
        }
    }
}
