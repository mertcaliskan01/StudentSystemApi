using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentSystemAPI.Data;
using StudentSystemAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentSystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private Context _context;

        public StudentController(Context context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public List<Student> Get()
        {
            return _context.students.ToList();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public  Student GetStudent(int id)
        {
            var student = _context.students.Find(id);
            return student;
        }


        // PUT: api/Test/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(long id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.students.Update(student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool StudentExists(long id)
        {
            return _context.students.Any(e => e.Id == id);
        }

        private bool StudentExists(Student student)
        {
            return _context.students.Any(e => e.Name == student.Name && e.SurName == student.SurName);
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model!");
            }

            if (StudentExists(student))
            {
                return BadRequest("Already Exist");
            }

            _context.students.Add(student);

            try
            {
                 await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(student.Id + student.Name + student.SurName + student.Phone + student.Address + student.Class );
                Console.WriteLine(e);
            }

            return Ok();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}