using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6_APBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw6_APBD.Controllers

        //https://localhost:44316/api/students  (z 'Index' w headerze)

{
    [Route("api/students")]
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


                list.Add(new Student { Index = "1", FirstName = "Jan", LastName = "Kowalski" });
                list.Add(new Student { Index = "2", FirstName = "Andrzej", LastName = "Malewicz" });
                list.Add(new Student { Index = "3", FirstName = "Krzysztof", LastName = "Andrzejewicz" });

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
            return Ok(new Student { Index = "2", FirstName = "Andrzej", LastName = "Malewski" });
        }

    }
}
