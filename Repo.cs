using Microsoft.Data.SqlClient;
using System.Data;
using common.commonfol;
using System.Linq.Expressions;
namespace StudentsqlRepo
{
    public class Repo :IRepo
    {
        private readonly IDbConnection _connection;
        public Repo(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<List<Students>> GetAll()
        {
            List<Students> students = new List<Students>();

            try
            {
                _connection.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in DB connection",ex.Message);
            }
                        
            string query = "Select * from Students";

            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            try
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Students student = new Students()
                        {
                            roll_no = Convert.ToString(reader["Roll_no"]),
                            name = Convert.ToString(reader["Name"]),
                            email = Convert.ToString(reader["email"])


                        };
                        Console.WriteLine("reading the table succussfully");
                        students.Add(student);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Errorn in reading the data base", ex.Message);
            }
            finally { _connection.Close(); }

            _connection.Close();
            return students;

        }

        public async Task<bool> PostStudents(Students student)
        {
            try
            {
                _connection.Open();
                Console.WriteLine("opening the db connection ");

            }
            catch(Exception ex)
            {
                Console.WriteLine("error in opening the db connection ", ex.Message);
            }
            string query = "Insert into Students (Name,Roll_no,email) values (@value1,@value2,@value3) ";



            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            command.Parameters.AddWithValue("@value1", student.name); // Replace with actual property name from Students class
            command.Parameters.AddWithValue("@value2", student.roll_no); // Replace with actual property name from Students class
            command.Parameters.AddWithValue("@value3", student.email);


            try
            {
                Console.WriteLine("Data item are",command.CommandText);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Data inserted successfully");
                return true;

            }
            catch( Exception ex)
            {
                Console.WriteLine("error while inserting the query", ex.Message);
                return false;
            }
            finally { _connection.Close(); }

        }






        public async Task<bool> update(string studentid,string studentemail)
        {
            try
            {
                _connection.Open();
                Console.WriteLine("opening the db connection ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("error in opening the db connection ", ex.Message);
            }
            string query = "update Students set email=@value1 where Roll_no=@value2 ";



            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            command.Parameters.AddWithValue("@value1",studentemail); // Replace with actual property name from Students class
            command.Parameters.AddWithValue("@value2", studentid); // Replace with actual property name from Students class
            try
            {
                Console.WriteLine("Data item are", command.CommandText);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Data inserted successfully");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("error while inserting the query", ex.Message);
                return false;
            }
            finally { _connection.Close(); }

        }




        //delecing function
        public async Task<bool> Delete(string studentid)
        {
            try
            {
                _connection.Open();
                Console.WriteLine("connection opened successfully");
            }
            catch(Exception ex) {
                Console.WriteLine("error at connetion in delete function", ex.Message);
            }

            string query = "Delete from students where Roll_no=@value1 ";



            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            command.Parameters.AddWithValue("@value1", studentid);
            try
            {
                Console.WriteLine("deleting query");
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("deletd succesfully");
                return true;
            }
            catch( Exception ex)
            {
                Console.WriteLine("error while deleting ");
                return false;
            }
            finally
            {
                _connection.Close();
            }


        }










    }




}

