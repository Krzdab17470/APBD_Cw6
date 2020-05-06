using Cw6_APBD.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6_APBD.Services
{
    public class SqlStudentDbService : IStudentDbService
    {
        public Student GetStudent(string index)
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17470;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();

                com.CommandText = "SELECT * FROM STUDENT WHERE INDEXNUMBER = @index";
                com.Parameters.AddWithValue("index", index);
                var dr = com.ExecuteReader();

                if (!dr.Read())
                {
                    dr.Close();
                    return null;
                }

                return new Student { FirstName = dr["FirstName"].ToString(), LastName = dr["LastName"].ToString(), Index = dr["IndexNumber"].ToString()  };

            }

            //return new Student {IdStudent = 1, FirstName = "Jan", LastName = "Kowalski", Index="s1111"};

        }

        public IEnumerable<Student> GetStudents()
        {
            //..
            return null; //tutaj zwrocimy..
        }
    }
}
