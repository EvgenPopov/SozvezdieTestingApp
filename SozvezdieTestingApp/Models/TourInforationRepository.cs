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


        public TourInformationModel[] TourInformation => GetInformation();


        public TourInformationModel[] GetInformation()
        {
            string json = File.ReadAllText(@"Files\demo_offers.json");

            var pageInfo = JsonConvert.DeserializeObject<ICollection<TourInformationModel>>(json).ToArray();

            return pageInfo;
        }
    }
}
