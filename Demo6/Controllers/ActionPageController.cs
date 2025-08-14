using Microsoft.AspNetCore.Mvc;
using Demo6.Models;

namespace Demo6.Controllers.ActionPageController
{
    public class ActionPageController : Controller
    {
        public IActionResult StringCounter(StringStoreModel model)
        {
            int count = 0;

            if (!string.IsNullOrEmpty(model.Mystring))
            {
                for (int i = 0; i < model.Mystring.Length; i++)
                {
                    count++;
                }
            }
            model.Result = count;
            return View(model);
        }
    }
} 