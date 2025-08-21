using Demo11.Data; // IMport Context namespace
using Demo11.Models.DB_Models.Action; //Import Model namespace
using Microsoft.AspNetCore.Mvc;

namespace Demo11.Controllers
{
    public class ActionController : Controller
    {
        private readonly Demo11_db_Context _context; // DB COntext class name form the Context file

        // Inject the DbContext using Dependency Injection
        public ActionController(Demo11_db_Context context)
        {
            _context = context; // the values are given to _content variable to be used later to add and save data.
        }

        // Show the Book Enter form
        [HttpGet]
        public IActionResult StudentPage()
        {
            return View();
        }

        // Save Book data into SQL
        [HttpPost]
        public IActionResult Student_Data_Input(StudentModel book) //BookModel is the name of the model class from the model page and book is just an object
        {
            if (ModelState.IsValid)
            {
                _context.Student_Table.Add(book);   // Add to EF change tracker
                _context.SaveChanges();          // Commit to DB

                TempData["SuccessMessage"] = "Student added successfully!"; // if the above is true then pass to here
                return RedirectToAction("StudentPage"); // Redirect to form again (or change to another view)
            }

            return View("StudentPage", book); // If validation fails, reload form with data
        }
    }
}