using Cw6_APBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw6_APBD.Services
{
    public interface IStudentDbService
    {
        public IEnumerable<Student> GetStudents();

        public Student GetStudent(string index);
    }
}
