using Demo5.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace Demo5.Controllers.SumofThreeController
{
    public class SumofThreeController : Controller
    {
        public IActionResult AddThree(AddtheNumbersModel model)
        {
            model.Result = model.Number1 + model.Number2 + model.Number3;
            return View(model);
        }
    }
}