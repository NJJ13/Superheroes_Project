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
        public IActionResult Delete(int ID)
        {
            Superhero superhero = _context.Superheroes.Find(ID);
            return View(superhero);
        }
        [HttpPost]
        public IActionResult Delete(int ID, Superhero superheroToDelete)
        {
            superheroToDelete = _context.Superheroes.Find(ID);
            _context.Superheroes.Remove(superheroToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int ID)
        {
            return View(_context.Superheroes.Find(ID));
        }
        public IActionResult Edit(int ID)
        {
            return View(_context.Superheroes.Find(ID));
        }
        [HttpPost]
        public IActionResult Edit(int ID, Superhero editedHero)
        {
            Superhero superheroToEdit = _context.Superheroes.Find(ID);
            superheroToEdit.Name = editedHero.Name;
            superheroToEdit.AlterEgo = editedHero.AlterEgo;
            superheroToEdit.PrimaryAbility = editedHero.PrimaryAbility;
            superheroToEdit.SecondaryAbility = editedHero.SecondaryAbility;
            superheroToEdit.Catchphrase = editedHero.Catchphrase;
            _context.Superheroes.Update(superheroToEdit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
