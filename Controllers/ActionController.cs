using Microsoft.AspNetCore.Mvc;
using Demo8.Data;
using Demo8.Models.DB_Models;

namespace Demo8.Controllers
{
    public class ActionController : Controller
    {
        private readonly Demo8dbContext _context;

        public ActionController(Demo8dbContext context)
        {
            _context = context;
        }

        // Display form
        public IActionResult MysqlInput()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult MysqlInput(Emp emp)
        {
            if (ModelState.IsValid)
            {
                // ✅ Use DbSet name (Emp), not the table name
                _context.Emp_table.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(emp);
        }
    }
}
