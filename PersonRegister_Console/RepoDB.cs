﻿using System;
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

        public void UpdatePersonIRegister(string nytFornavn, string nytEfternavn, DateTime? nyFødselsdato, int id)
        {
            //string updateQuery = $"UPDATE Person SET Fornavn = @NytFornavn, Efternavn = @NytEfternavn, Fødselsdato = @NyFødselsdato WHERE Id = {id}";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string updateSql = "UPDATE Person SET";
                bool updateRequired = false;

                if (!string.IsNullOrEmpty(nytFornavn))
                {
                    updateSql += " Fornavn = @NytFornavn,";
                    updateRequired = true;
                }

                if (!string.IsNullOrEmpty(nytEfternavn))
                {
                    updateSql += " Efternavn = @NytEfternavn,";
                    updateRequired = true;
                }

                if (nyFødselsdato != null)
                {
                    updateSql += " Fødselsdato = @NyFødselsdato,";
                    updateRequired = true;
                }

                if (updateRequired)
                {
                    updateSql = updateSql.TrimEnd(',');
                    updateSql += $" WHERE Id = {id}";

                    using (SqlCommand sqlCommand = new SqlCommand(updateSql, conn))
                    {
                        if (!string.IsNullOrEmpty(nytFornavn))
                        {
                            sqlCommand.Parameters.AddWithValue("@NytFornavn", nytFornavn);
                        }

                        if (!string.IsNullOrEmpty(nytEfternavn))
                        {
                            sqlCommand.Parameters.AddWithValue("@NytEfternavn", nytEfternavn);
                        }

                        if (nyFødselsdato != null)
                        {
                            sqlCommand.Parameters.AddWithValue("@NyFødselsdato", nyFødselsdato);
                        }

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
                else
                {
                    Console.WriteLine("Ingen opdateringer blev gjort på person.");
                }
            }
        }

        public void DeletePersonIRegister(int id)
        {
            string dropQuery = $"DELETE FROM Person WHERE Id = {id}";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(dropQuery, conn))
                {
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                        Console.WriteLine($"Række med id:({id}) er blevet fjernet fra databasen.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Fejl: " + ex.Message);
                    }
                }
            }
        }

        public void SelectAllPersonsFromDB()
        {
            string selectQuery = "SELECT * FROM Person";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime fødselsdato;

                            string id = reader["Id"].ToString();
                            string fornavn = reader["Fornavn"].ToString();
                            string efternavn = reader["Efternavn"].ToString();
                            fødselsdato = Convert.ToDateTime(reader["Fødselsdato"]);
                            string fødsesldatoString = fødselsdato.ToShortDateString();

                            Console.WriteLine($"Person ID: {id}");
                            Console.WriteLine($"Person Fornavn: {fornavn}");
                            Console.WriteLine($"Person Efternavn: {efternavn}");
                            Console.WriteLine($"Person Fødseldato: {fødsesldatoString}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

    }
}
