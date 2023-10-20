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
            string insertQuery = "INSERT INTO Person (Fornavn, Efternavn, Fødselsdato) VALUES (@Fornavn, @Efternavn, @Fødselsdato)";

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
                        Console.WriteLine("Ny data er blevet gemt.");
                    }
                    else
                    {
                        Console.WriteLine("Det lykkedes ikke at gemme!");
                    }
                    conn.Close();
                }
            }
        }

        public void UpdatePersonIRegister(string nytFornavn, string nytEfternavn, DateTime nyFødselsdato, int id)
        {
            string updateQuery = $"UPDATE Person SET Fornavn = @NytFornavn, Efternavn = @NytEfternavn, Fødselsdato = @NyFødselsdato WHERE Id = {id}";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@NytFornavn", nytFornavn);
                    sqlCommand.Parameters.AddWithValue("@NytEfternavn", nytEfternavn);
                    sqlCommand.Parameters.AddWithValue("@NyFødselsdato", nyFødselsdato);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Person opdateret.");
                    }
                    else
                    {
                        Console.WriteLine("Fejl. Person blev ikke opdateret.");
                    }
                }
            }
        }
    }
}
