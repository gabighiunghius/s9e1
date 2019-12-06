using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsertPublisherApp
{
    class Program
    {
        static void Main(string[] args)

        {
            string connectionString = "Data Source=.;Initial Catalog=Homeworks9;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            InsertPublisher(connection);
            
        }

        private static void InsertPublisher(SqlConnection connection)
        {
            

            try
            {
                Console.WriteLine("Insert new name here:");
                string name = Console.ReadLine();

                var commandQuery = "insert into Publisher (Name) values (@NameParam); select scope_identity();";

                SqlParameter nameParam = new SqlParameter("@NameParam", name);

                SqlCommand insertCommand = new SqlCommand(commandQuery, connection);

                insertCommand.Parameters.Add(nameParam);

                var id = insertCommand.ExecuteScalar();

                Console.WriteLine($"ID:{id} - {name}");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    
  


}
