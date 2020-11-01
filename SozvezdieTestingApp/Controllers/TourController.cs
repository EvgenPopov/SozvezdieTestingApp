using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SozvezdieTestingApp.Models;
using SozvezdieTestingApp.Models.Extensions;

namespace SozvezdieTestingApp.Controllers
{
    public class TourController : Controller
    {
        private readonly IDeserializeJson deserialize;

        const int pagesize = 2;

       


        public TourController(IDeserializeJson deserialize)
        {
            this.deserialize = deserialize;
        }

       



        public IActionResult Index(int? id)
        {
            int page = id ?? 0;

            

            if(Request.IsAjaxRequest())
            {
                return PartialView("_tours", GetItemsPage(page));
            }
            return View(GetItemsPage(page));

            //return View(Tours);

        }

        private TourInformation[] GetItemsPage(int page=1)
        {
            var Tours = deserialize.GetInformation();

            var itemsToSkip = page * pagesize;

            return Tours.OrderBy(t => t.id).Skip(itemsToSkip).Take(pagesize).ToArray();
        }

        public IActionResult SingleTour(int id)
        {
            var Tour = deserialize.GetInformation().SingleOrDefault(tour => tour.id == id);

            return View(Tour);


        }

     




    }
}
