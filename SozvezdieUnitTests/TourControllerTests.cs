using System;
using Xunit;
using SozvezdieTestingApp.Controllers;
using SozvezdieTestingApp.Models;
using Moq;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using SozvezdieTestingApp.Infostructure;
using Microsoft.Extensions.Logging;

namespace SozvezdieUnitTests
{
    public partial class TourControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IDeserializeJson> mock = new Mock<IDeserializeJson>();

            mock.Setup(m => m.TourInformation).Returns((new TourInformationModel[]
                {
                new TourInformationModel{id=1, title="Titel1" },
                new TourInformationModel{id=2, title="Titel2" },
                new TourInformationModel{id=3, title="Titel3" },
                new TourInformationModel{id=4, title="Titel4" },
                new TourInformationModel{id=5, title="Titel5" },
                new TourInformationModel{id=6, title="Titel6" },
                new TourInformationModel{id=7, title="Titel7" },
                new TourInformationModel{id=8, title="Titel8" },
                }));

            TourController controller = new TourController(mock.Object)
            {
                pagesize = 4
            };

            Assert.Equal(4, controller.GetItemsPage(1).Length);
            Assert.Empty(controller.GetItemsPage(2));

        }


        [Fact]
        public void Can_Send_List_Of_Tours()
        {
            var mock = new Mock<IDeserializeJson>();

            mock.Setup(m => m.TourInformation).Returns((new TourInformationModel[]
                {
                new TourInformationModel{id=1, title="Titel1" },
                new TourInformationModel{id=2, title="Titel2" },
                new TourInformationModel{id=3, title="Titel3" },
                new TourInformationModel{id=4, title="Titel4" },
                new TourInformationModel{id=5, title="Titel5" },
                new TourInformationModel{id=6, title="Titel6" },
                new TourInformationModel{id=7, title="Titel7" },
                new TourInformationModel{id=8, title="Titel8" },
                }));

            TourController controller = new TourController(mock.Object)  {pagesize = 4};

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
           

            TourInformationModel[] result = ((ViewResult)controller.Catalog(1)).ViewData.Model as TourInformationModel[];

            Assert.Equal(4, result.Length);
            Assert.Equal("Titel5", result[0].title);

        }




        [Fact]
        public void Can_Send_SingleTour()
        {
            Mock<IDeserializeJson> mock = new Mock<IDeserializeJson>();

            mock.Setup(m => m.TourInformation).Returns((new TourInformationModel[]
                {
                new TourInformationModel{id=1, title="Titel1" },
                new TourInformationModel{id=2, title="Titel2" },
                new TourInformationModel{id=3, title="Titel3" },
                new TourInformationModel{id=4, title="Titel4" },
                new TourInformationModel{id=5, title="Titel5" },
                new TourInformationModel{id=6, title="Titel6" },
                new TourInformationModel{id=7, title="Titel7" },
                new TourInformationModel{id=8, title="Titel8" },
                }));

            TourController controller = new TourController(mock.Object) { pagesize = 4 };

            TourInformationModel result = ((ViewResult)controller.SingleTour(6)).ViewData.Model as TourInformationModel;

            Assert.Equal(6, result.id);
            Assert.Equal("Titel6", result.title);

        }



    }
}
