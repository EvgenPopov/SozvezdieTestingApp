using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SozvezdieTestingApp.Models;

namespace SozvezdieTestingApp.Controllers
{
    public class TourController : Controller
    {
        private readonly IDeserializeJson deserialize;

        public TourController(IDeserializeJson deserialize)
        {
            this.deserialize = deserialize;
        }




        public IActionResult Index()
        {
            var Tours = deserialize.GetInformation();

            return View(Tours);

        }
    }
}
