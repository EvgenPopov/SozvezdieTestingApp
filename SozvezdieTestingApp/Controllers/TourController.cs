using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SozvezdieTestingApp.Models;
using SozvezdieTestingApp.Infostructure;

namespace SozvezdieTestingApp.Controllers
{
    public class TourController : Controller
    {
        private readonly IDeserializeJson deserialize;

        public int pagesize = 4;

        public TourController(IDeserializeJson deserialize)
        {
            this.deserialize = deserialize;
        }

        public IActionResult Catalog(int? id)
        {
            int page = id ?? 0;

            if(Request.IsAjaxRequest())
            {
                return PartialView("_tours", GetItemsPage(page));
            }
            return View(GetItemsPage(page));

        }

        public TourInformationModel[] GetItemsPage(int page=1)
        {
            var itemsToSkip = page * pagesize;

            return deserialize.TourInformation.OrderBy(t => t.id).Skip(itemsToSkip).Take(pagesize).ToArray();
        }

        public IActionResult SingleTour(int id)
        {
            return View(deserialize.TourInformation.SingleOrDefault(tour => tour.id == id));
        }

     




    }
}
