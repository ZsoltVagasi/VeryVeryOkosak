using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace TestApplication
{
    class Program
    {
        static string connectionString = "SERVER = .\\SQLEXPRESS; DATABASE = Customers; USER ID = zsolt; PASSWORD = 12345678; Trusted_Connection=True;";
        static void Main(string[] args)
        {

            string my_query;

            Console.WriteLine("Olvasson be SQL utasitasokat * vegjelig: ", '\n');

           for(int j = 0; ; ++j)
            {
                SqlConnection sqlcon = new SqlConnection(connectionString);

                Console.WriteLine("Olvasson be egy SQL utasitast: ", '\n');

                my_query = Console.ReadLine();

                if (my_query.Equals("*")) {

                    break;
                }

                SqlCommand cmd = new SqlCommand(my_query, sqlcon);

                using (sqlcon)
                {
                    try
                    {
                        sqlcon.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.WriteLine(reader.GetValue(i));
                                }
                                Console.WriteLine();
                            }
                        }

                        sqlcon.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.ReadKey();
                    }

                }

            }
        }
    }
}