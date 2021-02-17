using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var superheroes = _context.Superheroes;
            return View(superheroes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Superhero superhero)
        {
            _context.Superheroes.Add(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Superhero superhero)
        {
            _context.Superheroes.Remove(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Read()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Read(Superhero superhero)
        {
            _context.Superheroes.Find(superhero);
            return RedirectToAction("Details");
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Superhero superhero)
        {
            _context.Superheroes.Update(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
