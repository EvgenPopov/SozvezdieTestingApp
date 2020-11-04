namespace SozvezdieTestingApp.Models
{
    public interface IDeserializeJson
    {

        public TourInformationModel[] TourInformation { get; }

       public TourInformationModel[] GetInformation();


    }
}
