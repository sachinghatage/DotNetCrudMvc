using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicatinDbContext dbContext;

        public StudentsController(ApplicatinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddStudentViewModel viewModel)
        {
            var student = new Student 
            { 
                Name=viewModel.Name,
                Email=viewModel.Email,
                Phone=viewModel.Phone,
                Subscribed=viewModel.Subscribed
            };
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult List() 
        {
            var students=dbContext.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var student=dbContext.Students.Find(id);
            return View(student);
        
        }

        [HttpPost]
        public IActionResult Edit(Student viewModel)
        {
            var student=dbContext.Students.Find(viewModel.Id);
            if(student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                dbContext.SaveChanges();
            }

            return RedirectToAction("List");
        }


        [HttpPost]
        public IActionResult Delete(Student viewModel)
        {
            var student = dbContext.Students.AsNoTracking().FirstOrDefault(x => x.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                dbContext.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}
