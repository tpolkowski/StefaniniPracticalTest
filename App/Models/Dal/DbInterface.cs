using System;
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
        private static readonly string Conect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ AppDomain.CurrentDomain.BaseDirectory + @"App_Data\Database.mdf;Integrated Security=True";
            
        //sets sql connection instance
        readonly SqlConnection _conn = new SqlConnection(Conect);

        //execute the query on db and return the result
        public List<Dictionary<string, string>> Find(string query)
        {
            _conn.Open();

            //criando o select e o objeto de consulta
            string sql = query;
            SqlCommand cmd = new SqlCommand(sql, _conn);

            //Pegando valores e colocando no DataTable 
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dados = ds.Tables[0];

            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

            foreach (DataRow row in dados.Rows)
            {
                var columns = new Dictionary<string, string>();
                foreach (DataColumn column in dados.Columns)
                {
                    columns.Add(column.ColumnName, row[column.Ordinal].ToString());
                }
                rows.Add(columns);
            }
            _conn.Close();

            return rows;
        }
    }
}
