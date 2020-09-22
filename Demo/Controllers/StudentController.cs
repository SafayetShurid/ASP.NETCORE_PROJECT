using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    
    
    public class StudentController : Controller
    {

        private readonly ApplicationDbContext _db;


        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            try
            {
                
                IEnumerable<Student> objList = _db.Student;
                return View(objList);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        
        public IActionResult Register(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Student.Add(obj);
                _db.SaveChanges(); //It makes the call to database
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Student.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Update(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Student.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
        
        /*public IActionResult Delete(int? id)
        {

            return View();
        }*/

        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Student.Find(id);
            _db.Student.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        

    }
}
