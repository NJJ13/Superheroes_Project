using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
