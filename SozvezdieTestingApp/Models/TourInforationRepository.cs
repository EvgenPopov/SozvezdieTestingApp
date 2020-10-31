using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SozvezdieTestingApp.Models
{
    public class TourInforationRepository : IDeserializeJson
    {
        public TourInformation[] TourInfo { get; private set; }



        public TourInformation[] GetInformation()
        {
            string json = File.ReadAllText(@"C:\Users\Евгений\Downloads\demo_offers.json");

            var pageInfo = JsonConvert.DeserializeObject<ICollection<TourInformation>>(json).ToArray();

            return pageInfo;
        }
    }
}
