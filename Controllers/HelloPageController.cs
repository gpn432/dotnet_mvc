using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class HelloPageController : Controller
    {
        public IActionResult Hello()  // Create a view file, name it Hello.cshtml
        {
            return View();
        }
    }
}