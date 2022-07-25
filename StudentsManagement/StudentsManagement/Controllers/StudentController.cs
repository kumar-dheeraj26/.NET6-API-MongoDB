using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Models;
using StudentsManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return _studentService.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);
            if(student == null)
            {
                return NotFound($"Student with id {id} is not found");
            }
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            _studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var exsistingStudent = _studentService.Get(id);
            if (exsistingStudent == null)
            {
                return NotFound($"Student with id {id} not found");
            }
            _studentService.Update(id, student);
            return NoContent();

        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var exsistingStudent = _studentService.Get(id);
            if (exsistingStudent == null)
            {
                return NotFound($"Student with id {id} not found");
            }
            _studentService.Remove(id);
            return Ok($"Student with id {id} is deleted");

        }
    }
}
