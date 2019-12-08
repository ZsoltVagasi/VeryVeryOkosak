using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace TestApplication
{
    class Program
    {

		static string connectionString = "SERVER = DESKTOP-3T8JJJB\\SQLEXPRESS; DATABASE = MatematikApp; USER ID = Vagasi; PASSWORD = 123; Trusted_Connection=True;";

		static void Main(string[] args)
        {
			SqlConnection sqlcon = new SqlConnection(connectionString);
			string my_query=" ";
			string query1, query2, query3, query4, query5, query6, query7, query8;
			// Console.WriteLine("Olvasson be SQL utasitasokat * vegjelig: ", '\n');
			//Console.WriteLine("Olvasson be egy SQL utasitast: ", '\n');
			Console.WriteLine("Valassza ki az utasitast \n Login \n Register \n User \n Insert");
				string Command;
				Command = Console.ReadLine();
				switch(Command)
				{
					case "Login":
					
					Console.WriteLine("Felhasznalonev");
							query1 = Console.ReadLine();
						Console.WriteLine("\n Jelszo");
							query2 = Console.ReadLine();

					
					break;
				case "Register":
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
					bool result = query2.Equals(query3);
					if (result)
					{
						using (sqlcon)
						{
							string Command1 = "INSERT INTO Regisztracio (" +
								"[Nev]," +
								"[Jelszo]," +
								"Jelszo_Megerosites," +
								"Role," +
								"Szak," +
								"Evfolyam," +
								"TantargySzam," +
								"Tantargy)" +
								" VALUES (" +
								"@query1," +
								"@query2," +
								"@query3," +
								"@query4," +
								"@query5," +
								"@query6," +
								"@query7," +
								"@query8);";
							SqlCommand cmda = new SqlCommand(Command1, sqlcon);

							cmda.Parameters.AddWithValue("@query1", query1);
							cmda.Parameters.AddWithValue("@query2", query2);
							cmda.Parameters.AddWithValue("@query3", query3);
							cmda.Parameters.AddWithValue("@query4", query4);
							cmda.Parameters.AddWithValue("@query5", query5);
							cmda.Parameters.AddWithValue("@query6", query6);
							cmda.Parameters.AddWithValue("@query7", query7);
							cmda.Parameters.AddWithValue("@query8", query8);

							try
							{
								sqlcon.Open();
								Int32 rowsAffected = cmda.ExecuteNonQuery();
								Console.WriteLine("RowsAffected: {0}", rowsAffected);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}

						}
					}
					else
						Console.WriteLine("A jelszavak nem egyeznek meg"); 
					
					Console.WriteLine("Registration is sucessfull!");
					break;
				default:
					Console.WriteLine("Nincs parancs");
					my_query = " ";
					break;

				}
				//SqlCommand cmd = new SqlCommand(my_query, sqlcon);
				//my_query = Console.ReadLine();

                /*if (my_query.Equals("*")) {

                    break;
                }*/

              

               /* using (sqlcon)
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

                }*/

            
        }
    }
}