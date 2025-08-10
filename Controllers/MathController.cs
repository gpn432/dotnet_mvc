using Microsoft.AspNetCore.Mvc;
using Demo4.Models;

namespace Demo4.Controllers
{
    public class MathController : Controller
    {
        [HttpGet]
        public IActionResult ShowSum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowSum(AddNumberModel model)
        {
            model.Result = model.Number1 + model.Number2;
            return View(model);
        }
    }
}