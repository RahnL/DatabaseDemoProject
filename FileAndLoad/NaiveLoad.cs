using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace FileAndLoad
{
    /// <summary>
    /// Demo of loading data to DB naively
    /// </summary>
    public class NaiveLoad
    {
        public string ConnString;

        #region Constructors
        public NaiveLoad()
        {
            ConnString = "";
        }
        public NaiveLoad(string DBConnectionString)
        {
            ConnString = DBConnectionString;
        }
        #endregion

        /// <summary>
        /// Simplest Naive method - Load record one at a time
        /// </summary>
        /// <param name="FileName"></param>
        public void LoadFileByRecord(string FileName)
        {
            string sql = "insert into DataTable(S1, S2, Dt1, Dt2, N1, N2) Values (@s1, @s2, @d1, @d2,@n1,@n2)";

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (StreamReader r = new StreamReader(FileName))
                {
                    while (r.Peek() != -1)
                    {
                        string[] line = r.ReadLine().Split(',');

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@s1", line[0]);
                        cmd.Parameters.AddWithValue("@s2", line[0]);
                        cmd.Parameters.AddWithValue("@d1", line[0]);
                        cmd.Parameters.AddWithValue("@d2", line[0]);
                        cmd.Parameters.AddWithValue("@n1", line[0]);
                        cmd.Parameters.AddWithValue("@n2", line[0]);
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }



    }
}
