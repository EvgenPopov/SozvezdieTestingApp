using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SozvezdieTestingApp.Models
{
    public class TourInformation
    {
        public int id { get; set; }
        public string title { get; set; }
        public string header { get; set; }
        public string description { get; set; }
        public List<string> route { get; set; }
        public DateTime periodStart { get; set; }
        public DateTime periodEnd { get; set; }
        public double minPrice { get; set; }
        public PhotoCard photoCard { get; set; }
        public List<PhotoAlbum> photoAlbum { get; set; }

    }
}
