using System;
using System.Data.SqlClient;

namespace ValamiApp
{
	class Program
	{
		static string connectionString = "SERVER = DESKTOP-9A2J9E7\\SQLEXPRESS; DATABASE= asd; USER ID = Vagasi; PASSWORD = 123; Trusted_Connection=True";
		static SqlConnection  sqlcon= new SqlConnection(connectionString);
		static void Main(string[] args)
		{
			SqlCommand cmd = new SqlCommand("Select * From proba Where name = @course",sqlcon);
			using (sqlcon)
			{

				try
				{
					sqlcon.Open();
					cmd.Parameters.AddWithValue("@course","Pityu");
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while(reader.Read())
						{
							for(int i=0;i<reader.FieldCount;i++)
							{
								Console.WriteLine(reader.GetValue(i));
							}
							Console.WriteLine();
						}
					}
					sqlcon.Close();
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				finally
				{
					Console.ReadKey();
				}
			}
				Console.WriteLine("Hello World!");
		}
	}
}
