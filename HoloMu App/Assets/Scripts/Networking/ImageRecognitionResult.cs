using HoloMu.Persistance;

namespace HoloMu.Networking
{
    public class ImageRecognitionResult : RequestResult
    {
        public Exhibit Exhibit { get; private set; }

        public ImageRecognitionResult(bool isSuccessful, string errorMessage, string resultText) : base(isSuccessful, errorMessage)
        {
            if (isSuccessful)
            {
                XMLParser parser = new XMLParser();
                this.Exhibit = parser.ParseExhibit(resultText);
            }
        }
    }
}
