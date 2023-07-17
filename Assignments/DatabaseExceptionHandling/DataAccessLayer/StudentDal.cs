using DatabaseExceptionHandling.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExceptionHandling.DataAccessLayer
{
    public class StudentDal
    {
        private readonly IConfiguration _configuration;
       
        public StudentDal(IConfiguration configuration)
        {
            this._configuration = configuration;
     
        }

        public List<Student> GetAllStudents()
        {
            var lstStudents = new List<Student>();
            var configuration = new ConfigurationBuilder()
                                             .AddJsonFile("appsetting.json")
                                             .Build();
            string connectionstring = configuration.GetConnectionString("con");
            SqlConnection con = new SqlConnection(connectionstring);
            try
            {
                
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Student]", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstStudents.Add(new Student
                        {
                            StudentID = rdr.GetInt32("StudentID"), //trying to convert int32 to int16
                            Name = rdr.GetString("Name"),
                            GroupName = rdr.GetString("GroupName"),
                            ModifiedDate = rdr.GetDateTime("ModifiedDate")
                        });
                    }
                    con.Close();
                
            }
            catch (SqlException ex)
            {
                //If we not provide proper connection.
                //The server not found exception and it is related to network related.
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Database Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            
            return lstStudents;
        }
    }
}
