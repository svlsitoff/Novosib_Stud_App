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
        public IActionResult Index()
        {
            return View(db.Students.ToList());
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Redirect("~/Home/Index");
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
