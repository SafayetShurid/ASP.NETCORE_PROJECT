using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/Students")]
    public class ApiController :ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ApiController(ApplicationDbContext db)
        {
            _db = db;
        }


        //GET api/Students
        //Returns the list of all students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            
            var objList = _db.Student.ToList<Student>();
            if(objList==null)
            {
                return NotFound();
            }
                return Ok(objList);
                       
            
        }

       //GET api/Students/{id}
       //Returns a specific student
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentByID(int? id)
        {
            var obj = _db.Student.Find(id);
            if(id==null || obj==null)
            {
                return NotFound();
            }
            return Ok(obj);
            
        }

        //DELETE api/Students/{id}
        //Deletes a student with his id
        [HttpDelete("{id}")]
        public ActionResult DeletePost(int? id)
        {
            
            var obj = _db.Student.Find(id);
            if(id==null || obj==null)
            {
                return NotFound();
            }
            _db.Student.Remove(obj);
            _db.SaveChanges();
            return Ok();
        }

        
        //POST api/Students
        //Registers a new student with a body

        [HttpPost]
        public ActionResult RegisterStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student != null)
                {
                    _db.Student.Add(student);
                    _db.SaveChanges(); //It makes the call to database
                    return Ok();
                }
            }

            return BadRequest();
        }

        //PUT api/Students
        //Updates an existing student's data

        [HttpPut("{id}")]
        public ActionResult Update(int? id,[FromBody] Student student)
        {
           
           /* var obj = _db.Student.Find(id);
            if(obj!=null)
            {
                obj.Name = student.Name!=null ? student.Name : obj.Name;
                obj.Age = student.Age != 0 ? student.Age : obj.Age;
                obj.Department = student.Department != null ? student.Department : obj.Department;
            }*/
           

            if (id!=null && id!=0 && ModelState.IsValid)
            {
                var obj = _db.Student.Find(id);
                obj.Name = student.Name;
                obj.Age = student.Age ;
                obj.Department = student.Department ;

                _db.Student.Update(obj);
                _db.SaveChanges();
                return Ok();
            }

            return NotFound();
            
            
        }
    }
}
