using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public class re_insert_data_teacher
{
    static string connectionString = "SERVER = .\\SQLEXPRESS; DATABASE = MathAppDB; USER ID = zsolt; PASSWORD = 12345678; Trusted_Connection=True;";
    public void insert_info()
    {
        string fname, lname, mclass, usern, pass, cpass;

        Console.WriteLine("Teacher Sign Up Selected \n");
        Console.WriteLine("Please type the following informations :\n");

        Console.WriteLine("First Name: "); fname = Console.ReadLine();
        Console.WriteLine("Last Name: "); lname = Console.ReadLine();
        Console.WriteLine("Subject: "); mclass = Console.ReadLine();
        Console.WriteLine("Username: "); usern = Console.ReadLine();
        Console.WriteLine("Password: "); pass = Console.ReadLine();
        Console.WriteLine("Confirm Password: "); cpass = Console.ReadLine();

        if (fname == "" || lname == "" || mclass == "" || usern == "" || pass == "" || cpass == "")
        {
            Console.WriteLine("Please fill mandatory fields");

            re_insert_data_teacher mdata = new re_insert_data_teacher();

            mdata.insert_info();

        }
        else if (pass != cpass)
        {

            Console.WriteLine("Wrong password!");
            re_insert_data_teacher mdata = new re_insert_data_teacher();
            mdata.insert_info();

        }
        else
        { 
            string commandText = "INSERT INTO Teacher (" +
                                "[First Name]," +
                                "[Last Name]," +
                                "Subject," +
                                "Username," +
                                "Password," +
                                "[Confirm Password])" +
                                " VALUES (" +
                                "@fname," +
                                "@lname," +
                                "@mclass," +
                                "@usern," +
                                "@pass," +
                                "@cpass);";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@mclass", mclass);
                command.Parameters.AddWithValue("@usern", usern);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@cpass", cpass);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Registration is sucessfull!");
        }
    }
}

public class re_insert_data_student
{
    static string connectionString = "SERVER = .\\SQLEXPRESS; DATABASE = MathAppDB; USER ID = zsolt; PASSWORD = 12345678; Trusted_Connection=True;";
    public void insert_info()
    {
        string fname, lname, mclass, year, usern, pass, cpass;

        Console.WriteLine("Student Sign Up Selected \n");
        Console.WriteLine("Please type the following informations :\n");

        Console.WriteLine("First Name: "); fname = Console.ReadLine();
        Console.WriteLine("Last Name: "); lname = Console.ReadLine();
        Console.WriteLine("Class: "); mclass = Console.ReadLine();
        Console.WriteLine("Year: "); year = Console.ReadLine();
        Console.WriteLine("Username: "); usern = Console.ReadLine();
        Console.WriteLine("Password: "); pass = Console.ReadLine();
        Console.WriteLine("Confirm Password: "); cpass = Console.ReadLine();

        if (fname == "" || lname == "" || mclass == "" || year == "" || usern == "" || pass == "" || cpass == "")
        {
            Console.WriteLine("Please fill mandatory fields");

            re_insert_data_student mdata = new re_insert_data_student();

            mdata.insert_info();
        }
        else if (pass != cpass)
        {
            Console.WriteLine("Wrong password!");

            re_insert_data_student mdata = new re_insert_data_student();
            mdata.insert_info();
        }
        else
        {

            string commandText = "INSERT INTO Student (" +
                               "[First Name]," +
                               "[Last Name]," +
                               "Class," +
                               "Year," +
                               "Username," +
                               "Password," +
                               "[Confirm Password])" +
                               " VALUES (" +
                               "@fname," +
                               "@lname," +
                               "@mclass," +
                               "@year," +
                               "@usern," +
                               "@pass," +
                               "@cpass);";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@mclass", mclass);
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@usern", usern);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@cpass", cpass);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Registration is sucessfull!");
        }
    }
}

public class show_login
{
    static string connectionString = "SERVER = .\\SQLEXPRESS; DATABASE = MathAppDB; USER ID = zsolt; PASSWORD = 12345678; Trusted_Connection=True;";
    public void teacher_login()
    {

        string uname, pass, cpass;
        bool my_teach = false, my_pass = false, my_cpass = false;

        Console.WriteLine("Please enter the followings: \n");

        Console.WriteLine("Username: "); uname = Console.ReadLine();
        Console.WriteLine("Password: "); pass = Console.ReadLine();
        Console.WriteLine("Confirm Password: "); cpass = Console.ReadLine();

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Teacher WHERE ([Username] = @user)", connection);
        SqlCommand check_password = new SqlCommand("SELECT * FROM Teacher WHERE ([Password] = @pass)", connection);
        SqlCommand check_confirm_password = new SqlCommand("SELECT * FROM Teacher WHERE ([Confirm Password] = @cpass)", connection);

        check_User_Name.Parameters.AddWithValue("@user", uname);
        check_password.Parameters.AddWithValue("@pass", pass);
        check_confirm_password.Parameters.AddWithValue("@cpass", cpass);

        connection.Open();
        using (SqlDataReader reader_user = check_User_Name.ExecuteReader())
        {

            if (reader_user.HasRows)
            {
                //Console.WriteLine("User exist");
                my_teach = true;
            }
            else
            {
                Console.WriteLine("User doesnt exist");
                show_login teach = new show_login();
                teach.teacher_login();
            }
        }
        connection.Close();

        connection.Open();
        using (SqlDataReader reader_pass = check_password.ExecuteReader())
        {

            if (reader_pass.HasRows)
            {
                //Console.WriteLine("Password exist");
                my_pass = true;
            }
            else
            {
                Console.WriteLine("Wrong Password or doesnt exist");
                show_login teach = new show_login();
                teach.teacher_login();
            }
        }
        connection.Close();

        connection.Open();
        using (SqlDataReader reader_cpass = check_confirm_password.ExecuteReader())
        {

            if (reader_cpass.HasRows)
            {
                //Console.WriteLine("Confirm Password exist");
                my_cpass = true;
            }
            else
            {
                Console.WriteLine("Wrong Confirm Password or doesnt exist");
                show_login teach = new show_login();
                teach.teacher_login();
            }
        }
        connection.Close();

        if (my_teach || my_pass || my_cpass)
        {
            Console.WriteLine("\n");
            SqlCommand cmd = new SqlCommand("Select * From Teacher WHERE Password = @pass", connection);
            using (connection)
            {

                try
                {
                    connection.Open();

                    cmd.Parameters.AddWithValue("@pass", pass);

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

                    connection.Close();

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

    public void student_login()
    {
        string uname, pass, cpass;
        bool my_stud = false, my_pass = false, my_cpass = false;

        Console.WriteLine("Please enter the followings: \n");

        Console.WriteLine("Username: "); uname = Console.ReadLine();
        Console.WriteLine("Password: "); pass = Console.ReadLine();
        Console.WriteLine("Confirm Password: "); cpass = Console.ReadLine();

        SqlConnection connection = new SqlConnection(connectionString);

        SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Student WHERE ([Username] = @user)", connection);
        SqlCommand check_password = new SqlCommand("SELECT * FROM Student WHERE ([Password] = @pass)", connection);
        SqlCommand check_confirm_password = new SqlCommand("SELECT * FROM Student  WHERE ([Confirm Password] = @cpass)", connection);

        check_User_Name.Parameters.AddWithValue("@user", uname);
        check_password.Parameters.AddWithValue("@pass", pass);
        check_confirm_password.Parameters.AddWithValue("@cpass", cpass);

        connection.Open();
        using (SqlDataReader reader_user = check_User_Name.ExecuteReader())
        {

            if (reader_user.HasRows)
            {
                //Console.WriteLine("User exist");
                my_stud = true;
            }
            else
            {
                Console.WriteLine("User doesnt exist");
                show_login stud = new show_login();
                stud.student_login();
            }
        }
        connection.Close();

        connection.Open();
        using (SqlDataReader reader_pass = check_password.ExecuteReader())
        {

            if (reader_pass.HasRows)
            {
                //Console.WriteLine("Password exist");
                my_pass = true;
            }
            else
            {
                Console.WriteLine("Wrong Password or doesnt exist");
                show_login stud = new show_login();
                stud.student_login();
            }
        }
        connection.Close();

        connection.Open();
        using (SqlDataReader reader_cpass = check_confirm_password.ExecuteReader())
        { 

            if (reader_cpass.HasRows)
            {
                //Console.WriteLine("Confirm Password exist");
                my_cpass = true;
            }
            else
            {
                Console.WriteLine("Wrong Confirm Password or doesnt exist");
                show_login stud = new show_login();
                stud.student_login();
            }
        }
        connection.Close();

        if (my_stud || my_pass || my_cpass)
        {
            Console.WriteLine("\n");
            SqlCommand cmd = new SqlCommand("Select * From Student WHERE Password = @pass", connection);
            using (connection)
            {

                try
                {
                    connection.Open();

                    cmd.Parameters.AddWithValue("@pass", pass);

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

                    connection.Close();

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
public class my_login_sign_up
{
    //static string connectionString = "SERVER = .\\SQLEXPRESS; DATABASE = MathAppDB; USER ID = zsolt; PASSWORD = 12345678; Trusted_Connection=True;";
    public void my_select()
    {

        string my_select, my_select2, my_select3;
        

        Console.WriteLine("\n\tMathApp\n");

        Console.WriteLine("Select between [1] - [2] - [3] \n");
        Console.WriteLine("[1] - Login \t [2] - Sign Up \t   [3] - Exit");

        my_select =Console.ReadLine();

        switch (my_select)
        {

            case "1":

                Console.WriteLine("Select between [A] and [B] \n");
                Console.WriteLine("[A] - Student Login \t [B] - Teacher Login");
                my_select2 = Console.ReadLine();

                switch (my_select2)
                {

                    case "A":

                        Console.WriteLine("Student Login Selected \n");

                        show_login stud = new show_login();
                        stud.student_login();

                        break;

                    case "B":

                        Console.WriteLine("Teacher Login Selected \n");

                        show_login teach = new show_login();
                        teach.teacher_login();

                        break;

                    default:
                        Console.WriteLine("Wrong character! \n");
                        my_login_sign_up my_try = new my_login_sign_up();
                        my_try.my_select();
                        break;
                }

                break;

            case "2":

                Console.WriteLine("Select between [A] and [B] \n");
                Console.WriteLine("[A] - Student Sign Up \t [B] - Teacher Sign Up");
                my_select3 = Console.ReadLine();

                
                switch (my_select3)
                {

                    case "A":

                        re_insert_data_student mdata = new re_insert_data_student();

                        mdata.insert_info();

                        break;    

                    case "B":

                        re_insert_data_teacher mdata1 = new re_insert_data_teacher();

                        mdata1.insert_info();

                        break;

                    default:

                        Console.WriteLine("Wrong character! \n");
                        my_login_sign_up my_try2 = new my_login_sign_up();
                        my_try2.my_select();
                        break;
                }

                break;

            case "3":
                Environment.Exit(0);
                break;

            default:

                Console.WriteLine("Wrong number! \n");
                my_login_sign_up my_try3 = new my_login_sign_up();
                my_try3.my_select();
                break;
        }
    }

}
class Program
{
    static void Main(string[] args){

        my_login_sign_up b = new my_login_sign_up();
        b.my_select();
    }
}

