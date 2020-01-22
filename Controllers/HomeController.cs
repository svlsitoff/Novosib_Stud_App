using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        StudDbContext db;
        public HomeController(StudDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["LastNameSort"] = String.IsNullOrEmpty(sortOrder) ? "LastName" : "";
            ViewData["FirstNameSort"] = String.IsNullOrEmpty(sortOrder) ? "FirstName" : "";
            ViewData["MidNameSort"] = String.IsNullOrEmpty(sortOrder) ? "MidName" : "";
            ViewData["CallNameSort"] = String.IsNullOrEmpty(sortOrder) ? "CallName" : "";
            ViewData["Sex_Sort"] = String.IsNullOrEmpty(sortOrder) ? "Sex" : "";


            var students = db.Students.AsQueryable<Student>();
            ViewBag.Count = students.Count();
            switch (sortOrder)
            {
                case "LastName":
                    students = students.OrderByDescending(s => s.LastNAme);
                    break;
                case "MidName":
                    students = students.OrderBy(s => s.MiddleName);
                    break;
                case "FirstName":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "CallName":
                    students = students.OrderBy(s => s.CallName);
                    break;
                case "Sex":
                    students = students.OrderBy(s => s.Sex);
                    break;
                default:
                    students = students.OrderBy(s => s.LastNAme);
                    break;
            }
            return View(await students.AsNoTracking().ToListAsync());
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckCallName(string callName)
        {
            var students = db.Students.AsQueryable<Student>();
            foreach(var item in students)
            {
                if (item.CallName == callName)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            try
            {
                db.Students.Add(student);
                db.SaveChanges();
                return Redirect("~/Home/Index");
            }
            catch
            {
                return View();
            }
            
        }

        public IActionResult EditStudent(int? id)
        {
            if (id != null)
            {
                Student student = db.Students.FirstOrDefault(s => s.Id == id);
                if(student!=null)
                return View(student);

            }
           
                return NotFound();
            

        }
        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            db.Students.Update(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Student student = db.Students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                    return View(student);

            }

            return NotFound();


        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Student student = await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (student != null)
                    return View(student);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Student student = await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (student != null)
                {
                    db.Students.Remove(student);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
