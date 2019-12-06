using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CrudBookApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=.;Initial Catalog=Homeworks9;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //UpdateBook(conenction);
        }
    }


    private static void UpdateBook(SqlConnection connection)
    {
        try
        {
            Console.WriteLine("Enter bookid to update: ");
            var bookid = Console.ReadLine();

            var command = "update Book set Title = 'New Title' where BookId = @BookIdParam";

            SqlParameter param = new SqlParameter("@BookIdParam", bookid);

            SqlCommand updateCommand = new SqlCommand(command, connection);

            updateCommand.Parameters.Add(param);

            updateCommand.ExecuteNonQuery();

        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void DeleteBook(SqlConnection connection)
    {
        try
        {
            Console.WriteLine("Enter id to delete: ");
            var bookid = Console.ReadLine();

            var command = "delete from Book where BookId = @BookIdParam";

            SqlParameter param = new SqlParameter("@BookIdParam", bookid);

            SqlCommand deleteCommand = new SqlCommand(command, connection);

            deleteCommand.Parameters.Add(param);

            deleteCommand.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }



}
