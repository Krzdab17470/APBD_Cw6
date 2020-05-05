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
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();

            return new Student {IdStudent = 1, FirstName = "Jan", LastName = "Kowalski", Index="s1111"};

        }

        public IEnumerable<Student> GetStudents()
        {
            //..
            return null; //tutaj zwrocimy..
        }
    }
}
