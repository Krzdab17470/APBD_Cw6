using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6_APBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw6_APBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetStudent()
        {

            var list = new List<Student>();

            try 
            {
                //Tutaj uruchamiamy nasz serwis, np"
                //dbService.GetStudents();


                new Student { IdStudent = 1, FirstName = "Jan", LastName = "Kowalski" };
                new Student { IdStudent = 2, FirstName = "Andrzej", LastName = "Malewicz" };
                new Student { IdStudent = 3, FirstName = "Krzysztof", LastName = "Andrzejewicz" };

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.GetType().ToString());
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            return Ok(new Student { IdStudent = 2, FirstName = "Andrzej", LastName = "Malewski" });
        }

    }
}
