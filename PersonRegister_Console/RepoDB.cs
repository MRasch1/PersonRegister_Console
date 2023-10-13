using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister_Console
{
    internal class RepoDB
    {
        string _connectionString = "Data Source=192.168.23.123;Initial Catalog=PersonRegister;User ID=sa;Password=Ab1234";

        public void InsertPersonIRegister(string fornavn, string efternavn, DateTime fødselsdato)
        {
            string insertQuery = "INSERT INTO Person (Fornavn, Efternavn, Fødselsdato) VALUES (@Fornavn, @Efternavn, @Fødselsdato";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(insertQuery, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@Fornavn", fornavn);
                    sqlCommand.Parameters.AddWithValue("@Efternavn", efternavn);
                    sqlCommand.Parameters.AddWithValue("@Fødselsdato", fødselsdato);

                    conn.Open();

                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Row inserted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert the row");
                    }
                    conn.Close();
                }
            }
        }
    }
}
