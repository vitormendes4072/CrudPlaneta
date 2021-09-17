using CrudPlaneta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPlaneta.Controllers
{
    public class PlanetController : Controller
    {
        private static int _index = 0;
        private static List<Planet> _base = new List<Planet>();

        private void LoadData()
        {
            //Send the options of select of galaxies
            var list = new List<string>(new string[] { "MilkyWay", "Andromeda", "Sombrero", "Messier 81", "Messier 87"});
            //Select a list of galaxies
            ViewBag.galaxies = new SelectList(list);

            //Radio
            ViewBag.atmospheres = new List<string>(new string[] { "Co2, N2", "N2, O2", "H2, HE, Ch4" });
        }

        [HttpGet]
        public IActionResult ToRegister()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public IActionResult ToRegister(Planet planet) 
        {
            planet.Id = ++_index;
            _base.Add(planet);
            ViewBag._base = _base;
            TempData["msg"] = "Registered planet!";
            return RedirectToAction("ToRegister");
        }

        public IActionResult ToList()
        {
            return View(_base);
        }

        [HttpGet]
        public IActionResult ToEdit(int id)
        {
            LoadData();
            //Find the planet by Id
            var planet = _base.Find(planet => planet.Id == id);
            
            //Send the planet to View
            return View(planet);
        }

        [HttpPost]
        public IActionResult ToEdit(Planet planet)
        {
            //Update the planet in the list, find the element position in the list 
            _base[_base.FindIndex(item => item.Id == planet.Id)] = planet;

            //Success message
            TempData["msg"] = "Planet updated!";

            //Redirect to page of List
            return RedirectToAction("ToList");
        }

        [HttpPost]
        public IActionResult ToDelete(int id)
        {
            _base.RemoveAll(planet => planet.Id == id);

            TempData["msg"] = "Planet removed!";

            return RedirectToAction("ToList");
        }
    }
}
