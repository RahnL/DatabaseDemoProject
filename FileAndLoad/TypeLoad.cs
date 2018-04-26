using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace FileAndLoad
{

    /// <summary>
    /// Demo of loading data using SQL types
    /// Much more efficient than naive load
    /// </summary>
    public class TypeLoad
    {
        public string ConnString;

        #region constructor
        public TypeLoad()
        {
            ConnString = null;
        }
        public TypeLoad(string DBConnectionString)
        {
            ConnString = DBConnectionString;
        }
        #endregion

        public void LoadByType(string FileName)
        {
            DataTable dt = new DataTable("records");
            dt.Columns.Add("s1");
            dt.Columns.Add("s2");
            dt.Columns.Add("d1");
            dt.Columns.Add("d2");
            dt.Columns.Add("n1");
            dt.Columns.Add("n2");

            //Load file into datatable
            using (StreamReader r = new StreamReader(FileName))
            {
                while (r.Peek() != -1)
                {
                    string[] line = r.ReadLine().Split(',');
                    DataRow row = dt.NewRow();
                    row["s1"] = line[0];
                    row["s2"] = line[0];
                    row["d1"] = line[0];
                    row["d2"] = line[0];
                    row["n1"] = line[0];
                    row["n2"] = line[0];
                }
            }

            //Load database
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertType";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@type";
                p.SqlDbType = SqlDbType.Structured;
                p.Value = dt;
                cmd.Parameters.Add(p);

                cmd.ExecuteScalar();
            }
        }
    }
}
