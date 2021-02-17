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
        public IActionResult Delete(int ID)
        {
            Superhero superheroToRemove = _context.Superheroes.First(s => s.ID == ID);
            _context.Superheroes.Remove(superheroToRemove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int ID)
        {
            return View(_context.Superheroes.First(s => s.ID == ID));
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int ID)
        {
            Superhero superheroToEdit = _context.Superheroes.First(s => s.ID == ID);
            _context.Superheroes.Update(superheroToEdit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
