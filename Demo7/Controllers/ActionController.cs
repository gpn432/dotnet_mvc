using Microsoft.AspNetCore.Mvc;
using Demo7.Models.ActionPage;

namespace Demo7.Controllers.ActionController
{
    public class ActionController : Controller
    {
        [HttpGet]
        public IActionResult CheckNum()  // Create a view file, name it Hello.cshtml
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckNum(CheckNumberModel model)
        {
            if (model.Num1 > model.Num2)
            {
                model.Result = true;
            }
            else
            {
                model.Result = false;
            }
            return View(model);
        }
    }
}