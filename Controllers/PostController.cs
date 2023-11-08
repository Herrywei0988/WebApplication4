using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApplication4.Models;

namespace WebApplication3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost("post1")]
        public Student Post1([FromBody] Student student)
        {
            string name = student.name;
            int age = student.age;

            Student newStudent = new Student();
            newStudent.name = name;
            newStudent.age = age;
            return newStudent;

        }

        [HttpPost("post2")]
        public IActionResult Post2([FromBody] Student student)
        {
            string name = student.name;
            int age = student.age;

            Student newStudent = new Student();
            newStudent.name = name + "_server";
            newStudent.age = age + 15;
            return Ok(newStudent);

        }

        [HttpPost("post3")]
        public IActionResult Post3([FromBody] Student student)
        {
            try
            {
                string name = student.name;
                if (name.Length == 0) throw new Exception("It's not a valid name");
                int age = student.age;
                if (age < 18) throw new Exception("not adult yet");
                Student newStudent = new Student();
                newStudent.name = name + "_server";
                newStudent.age = age + 10;
                return Ok(newStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("post4")]
        public IActionResult Post4([FromBody] Student student)
        {
            try
            {
                string name = student.name;
                if (name.Length == 0) throw new Exception("Please enter a valid name");
                int age = student.age;
                if (age > 18) throw new Exception("Welcome. Yor are an adult");


                Student newStudent = new Student();
                newStudent.name = name + "_server";
                newStudent.age = age + 15;
                return Ok(newStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
