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

    }
}
