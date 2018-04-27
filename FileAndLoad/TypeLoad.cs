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
            DataTable dt = LoadDataTable(FileName);

            //Load database
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LoadTable";
                SqlParameter p = new SqlParameter();
                p.ParameterName = "@data";
                p.SqlDbType = SqlDbType.Structured;
                p.Value = dt;
                cmd.Parameters.Add(p);

                cmd.ExecuteScalar();
            }
        }

        public void LoadBulkCopy(string FileName)
        {
            DataTable dt = LoadDataTable(FileName);

            //Load database
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlBulkCopy bc = new SqlBulkCopy(ConnString);
                bc.DestinationTableName= "DataTable";
                SqlBulkCopyColumnMapping s1 = new SqlBulkCopyColumnMapping("S1", "S1");
                SqlBulkCopyColumnMapping s2 = new SqlBulkCopyColumnMapping("S2", "S2");
                SqlBulkCopyColumnMapping d1 = new SqlBulkCopyColumnMapping("Dt1", "Dt1");
                SqlBulkCopyColumnMapping d2 = new SqlBulkCopyColumnMapping("Dt2", "Dt2");
                SqlBulkCopyColumnMapping n1 = new SqlBulkCopyColumnMapping("N1", "N1");
                SqlBulkCopyColumnMapping n2 = new SqlBulkCopyColumnMapping("N2", "N2");
                bc.ColumnMappings.Add(s1);
                bc.ColumnMappings.Add(s2);
                bc.ColumnMappings.Add(d1);
                bc.ColumnMappings.Add(d2);
                bc.ColumnMappings.Add(n1);
                bc.ColumnMappings.Add(n2);
                bc.WriteToServer(dt);
            }
        }

        private static DataTable LoadDataTable(string FileName)
        {
            DataTable dt = new DataTable("records");
            dt.Columns.Add("S1");
            dt.Columns.Add("S2");
            dt.Columns.Add("Dt1");
            dt.Columns.Add("Dt2");
            dt.Columns.Add("N1");
            dt.Columns.Add("N2");

            //Load file into datatable
            using (StreamReader r = new StreamReader(FileName))
            {
                while (r.Peek() != -1)
                {
                    string[] line = r.ReadLine().Split(',');
                    DataRow row = dt.NewRow();
                    row["s1"] = line[0];
                    row["s2"] = line[1];
                    row["dt1"] = DateTime.Parse(line[2]);
                    row["dt2"] = DateTime.Parse(line[3]);
                    row["n1"] = line[4];
                    row["n2"] = line[5];

                    dt.Rows.Add(row);
                }
            }

            return dt;
        }
    }
}
