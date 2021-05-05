using System;
using System.Data;
using System.Data.SqlClient;

namespace AddExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = @"server=DESKTOP-VFQK3GO\SQLEXPRESS;Integrated security=true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }
        void FetchMoviesFromDatabase()
        {
            string strCmd = " select * from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : "+ drMovies[0]); //like aarrays
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2]);
                    Console.WriteLine("--------------------------");
                }
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
            }
            finally //will get executed if there is a exception or not
            {
                con.Close();
            }
        }
        void Addmovie()
        {
            Console.WriteLine("Please enter the movie name");
            string mName = Console.ReadLine();
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd="insert into tblMovie(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result>0)
                    Console.WriteLine("Movie Inserted");
                else
                    Console.WriteLine("No no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally //will get executed if there is a exception or not
            {
                con.Close();
            }
        }
        void FetchOneMovieFromDatabase()
        {
            string strCmd = " select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                Console.WriteLine("Please enter the id");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : " + drMovies[0]); //like aarrays
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2]);
                    Console.WriteLine("--------------------------");
                }
            }
            catch (SqlException sqlException)
            {

                Console.WriteLine(sqlException.Message);
            }
            finally //will get executed if there is a exception or not
            {
                con.Close();
            }
        }
        void UpdateMovieDuration()
        {
            //Update tblMovie set duration=@mduration where id=@mid
            Console.WriteLine("Please enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set duration = @mdur where id = @mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Inserted");
                else
                    Console.WriteLine("No no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally //will get executed if there is a exception or not
            {
                con.Close();
            }
        }
        void UpdateMovieName()
        {
            Console.WriteLine("Please enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Movie Name");
            string name = Console.ReadLine();
            string strCmd = "Update tblMovie set name=@mname where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mname", name);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Inserted");
                else
                    Console.WriteLine("No no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally //will get executed if there is a exception or not
            {
                con.Close();
            }
        }
    
        void DeleteMovie()
        {
            Console.WriteLine("Please enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            string strCmd = "delete from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);


            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Deleted");
                else
                    Console.WriteLine("No no not done");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally //will get executed if there is a exception or not
            {
                con.Close();
            }
        }
        void Menu()
        {
            int choice = 0;
            do
            {
                
            Console.WriteLine("Select what do you want to do..");
            Console.WriteLine("1. Create a new movie");
            Console.WriteLine("2. Print all the Movies");
            Console.WriteLine("3. Update a Movie Name");
            Console.WriteLine("4. Update a Movie duration");
            Console.WriteLine("5. Delete a Movie");
            Console.WriteLine("6. Exit");
            Console.WriteLine("-----------------------------------------");
            choice = Convert.ToInt32(Console.ReadLine());
            
                switch (choice)
                {
                    case 1:
                        Addmovie();
                        break;
                    case 2:
                        FetchMoviesFromDatabase();
                        break;
                    case 3:
                        UpdateMovieName();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovie();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!!!!");
                        break;
                }
            } while (choice!=6);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Addmovie();
            // program.FetchMoviesFromDatabase();
            //program.FetchOneMovieFromDatabase();
            //program.UpdateMovieDuration();
            //program.DeleteMovie();
            //program.FetchMoviesFromDatabase();
            program.Menu();
        }
        
    }
}
