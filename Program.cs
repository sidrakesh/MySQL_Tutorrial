using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    class Program
    {

        static String connString = "server=localhost;uid=root;pwd=;database=test;";
        static MySqlConnection connection;
        
        static void Main(string[] args)
        {
            connect();
            Console.WriteLine("Connected successfully");
            readTable();
            insert(3, "sid2");
            Console.WriteLine("Insert done");
            readTable();
            delete(3);
            Console.WriteLine("Delete done");
            readTable();

            Console.ReadKey();
        }

        public static void connect()
        {
            connection = new MySqlConnection(connString);
            connection.Open();
        }

        public static void insert(int id, string name)
        {
            string query = "INSERT INTO USERS(id,name) VALUES(" + id + ", \"" + name + "\");";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void readTable()
        {
            String query = "SELECT * FROM USERS;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row.Field<int>(0));
                Console.WriteLine(row.Field<string>(1));
            }
        }

        public static void delete(int id)
        {
            string query = "DELETE FROM USERS WHERE id=" + id + ";";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
