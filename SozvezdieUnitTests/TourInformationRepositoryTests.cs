using SozvezdieTestingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SozvezdieUnitTests
{
   public class TourInformationRepositoryTests
    {

        [Fact]
        public void Can_Deserialize_Json()
        { 
            var Info = new TourInforationRepository().GetInformation();

            Assert.Equal(56, Info[56].id);

        }

    }
}
