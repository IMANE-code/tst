using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using tst.Models;

namespace tst.Controllers
{
    public class StudentController : Controller
    {
        public List<student> students { get; set; }
        private readonly DatabaseContext db;
        public student stud;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public StudentController(DatabaseContext _db)
        {
            this.db = _db;
        }
        //SELECT
        public IActionResult Student()
        {
           
            return View(db.students.ToList());

        }

        // ADD
        [HttpPost]
        public IActionResult AddStudent()
        {
            stud = new student();
            db.students.Add(stud);
            db.SaveChanges();
            return View();
        }

        //EDIT
        public IActionResult EditStudent()
        {
            //db.Entry(stud).State = EntityState.Modified;
            //db.SaveChanges();
            return View();
        }

        //DELETE
        public IActionResult DeleteStudent(int id)
        {
            var st = db.students.Find(id);
            db.Remove(st);
            db.SaveChanges();
            return View();
        }
        //Recherche
        public async Task OnGetAsync()
        {
            var stud = from m in db.students
                       select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                stud = (stud.Where(s => s.cin.Contains(SearchString)));
            }

            students = await stud.ToListAsync();
        }

    }
}
