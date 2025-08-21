using Demo10.Data; // IMport Context namespace
using Demo10.Models.DB_Models.ActionPageModel; //Import Model namespace
using Microsoft.AspNetCore.Mvc;

namespace Demo10.Controllers
{
    public class ActionController : Controller
    {
        private readonly Demo10_db_Context _context; // DB COntext class name form the Context file

        // Inject the DbContext using Dependency Injection
        public ActionController(Demo10_db_Context context)
        {
            _context = context; // the values are given to _content variable to be used later to add and save data.
        }

        // Show the Book Enter form
        [HttpGet]
        public IActionResult BookEnter()
        {
            return View();
        }

        // Save Book data into SQL
        [HttpPost]
        public IActionResult Book_Data_Input(BookModel book) //BookModel is the name of the model class from the model page and book is just an object
        {
            if (ModelState.IsValid)
            {
                _context.Book_Table.Add(book);   // Add to EF change tracker
                _context.SaveChanges();          // Commit to DB

                TempData["SuccessMessage"] = "Book added successfully!"; // if the above is true then pass to here
                return RedirectToAction("BookEnter"); // Redirect to form again (or change to another view)
            }

            return View("BookEnter", book); // If validation fails, reload form with data
        }
    }
}
