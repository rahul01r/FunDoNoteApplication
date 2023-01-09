using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace Student.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("GetStudent")]
        public ActionResult GetStudent()
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Student;Integrated Security=True;";
            using (var con = new SqlConnection(cs))
            {
                string query = "Select *from Student";
                SqlCommand command = new SqlCommand(query, con);
                con.ConnectionString = cs;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                // while there is another record present
                while (reader.Read())
                {
                    // write the data on to the screen    
                    Console.WriteLine(String.Format("{0} \t | {1} ",
                        // call the objects from their index    
                        reader[0], reader[1]));
                }
                return Ok();
            }
        }
    }
}

