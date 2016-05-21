using System;
using System.Data;
using System.Data.SqlClient;

namespace Statistics.Classes
{
    public static class SQLController
    {
        public static DataRowCollection GetTable(string query)
        {
            DataTable resultTable = new DataTable();
            char c = Convert.ToChar(92);
            string connString = "Server=tcp:he0n0wlbsj.database.windows.net,1433;Data Source=he0n0wlbsj.database.windows.net;Initial Catalog=Sweedish;Persist Security Info=False;User ID=Alexander;Password=REDACTED_CREDENTIAL;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(resultTable);
            conn.Close();
            da.Dispose();
            return resultTable.Rows;
        }
        public static DataTable GetDataTable(string query)
        {
            DataTable resultTable = new DataTable();
            char c = Convert.ToChar(92);
            string connString = "Server=tcp:he0n0wlbsj.database.windows.net,1433;Data Source=he0n0wlbsj.database.windows.net;Initial Catalog=Sweedish;Persist Security Info=False;User ID=Alexander;Password=REDACTED_CREDENTIAL;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(resultTable);
            conn.Close();
            da.Dispose();
            return resultTable;
        }


    }
}