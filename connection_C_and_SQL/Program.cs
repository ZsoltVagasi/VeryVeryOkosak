using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace TestApplication
{
    class Program
    {
		
		static string connectionString = "SERVER = DESKTOP-9A2J9E7\\SQLEXPRESS; DATABASE = MatematikApp; USER ID = Vagasi; PASSWORD = 123; Trusted_Connection=True;";
		SqlConnection sqlcon = new SqlConnection(connectionString);
		static void Main(string[] args)
        {

            string my_query;
			string query1, query2;
			// Console.WriteLine("Olvasson be SQL utasitasokat * vegjelig: ", '\n');
			//Console.WriteLine("Olvasson be egy SQL utasitast: ", '\n');
			Console.WriteLine("Valassza ki az utasitast \n Login \n Register \n User \n Insert");
				string Command;
				Command = Console.ReadLine();
				switch(Command)
				{
					case "Login":
					string query1, query2;
					Console.WriteLine("Felhasznalonev");
							query1 = Console.ReadLine();
						Console.WriteLine("\n Jelszo");
							query2 = Console.ReadLine();

					SqlCommand cmd = new SqlCommand(my_query, sqlcon);
					break;
				case "Register":
					
					Console.WriteLine("Felhasznalonev");
					string query1, query2, query3, query4, query5, query6, query7, query8;
					Console.WriteLine("\n Felhasznalo: ");
					query1 = Console.ReadLine();
					Console.WriteLine("\n Jelszo: ");
					query2 = Console.ReadLine();
					Console.WriteLine("\n Jelszo Megerosites: ");
					query3 = Console.ReadLine();
					Console.WriteLine("\n Szerep: ");
					query4 = Console.ReadLine();
					Console.WriteLine("\n Szak: ");
					query5 = Console.ReadLine();
					Console.WriteLine("\n Evfolyam: ");
					query6 = Console.ReadLine();
					Console.WriteLine("\n T.Szam: ");
					query7 = Console.ReadLine();
					Console.WriteLine("\n Tantargy: ");
					query8 = Console.ReadLine();
					if (query2 = query3)
						my_query = "Insert Into Regisztracio (Nev,Jelszo,Jelszo_Megerosites,Role,Szak,Evfolyam,TantargySzam,Tantargy) Values (query1,query2,query3,query4,query5,query6,query7,query8)";
					else
						Console.WriteLine("A jelszavak nem egyeznek meg");
					SqlCommand cmd = new SqlCommand(my_query, sqlcon);
					break;


			}

                my_query = Console.ReadLine();

                /*if (my_query.Equals("*")) {

                    break;
                }*/

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