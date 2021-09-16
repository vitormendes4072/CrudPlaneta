using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPlaneta.Models
{
    public class Planet
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Discovery { get; set; }
        public bool Habitable { get; set; }
        [Display(Name = "Kind of Planet")]
        public KindOfPlanet KindOfPlanet { get; set; }
        public string Atmosphere { get; set; }
        public string Galaxy { get; set; }
        [Display(Name = "Translation Time")]
        public int TranslationTime { get; set; }

    }
}
