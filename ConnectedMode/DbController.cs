using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;

namespace ConnectedMode
{
    public class DbController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        private string _query;

        public DbController(string querry) 
        { 
            this._query = querry;
        }

        public DbController()
        {
            this._query = null;
        }

        public void Add(Dictionary<string, object> addValues)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_query, connection);
                connection.Open();
                Console.WriteLine("Connection open");

                foreach (var kvp in addValues)
                {
                    command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }

                int rows = command.ExecuteNonQuery();
                Console.WriteLine("Db successfully changed");

                connection.Close();
            }
        }

        public void Update(Dictionary<string, object> updateValues, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_query, connection);
                connection.Open();
                Console.WriteLine("Connection open");

                foreach (var kvp in updateValues)
                {
                    command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }

                command.Parameters.AddWithValue("@id", id);

                int rows = command.ExecuteNonQuery();
                Console.WriteLine("Db successfully updated");

                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                Console.WriteLine("Connection open");

                int rows = command.ExecuteNonQuery();
                Console.WriteLine("Row(s) deleted: " + rows);

                connection.Close();
            }
        }

        public void Print(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"{reader.GetName(i)}: {reader[i]}");
                    }
                    Console.WriteLine();
                }

                reader.Close();
            }
        }

    }
}
