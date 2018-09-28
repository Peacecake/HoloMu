namespace HoloMu.Networking
{
    public class ApiRequest
    {
        public RequestType Type { get; private set; }
        public byte[] File { get; set; }
        public int ExhibitId { get; set; }
        public string URL
        {
            get
            {
                if (ExhibitId != 0) return $"{_baseUrl}/{this.Type.ToString()}/{ExhibitId.ToString()}";
                return $"{_baseUrl}/{this.Type.ToString()}";
            }
            set
            {
                _baseUrl = value;
            }
        }
        public RequestResult Result { get; private set; }

        private string _baseUrl = "";

        public ApiRequest(RequestType type)
        {
            this.Type = type;
        }

        public ApiRequest(RequestType type, byte[] file)
        {
            this.Type = type;
            this.File = file;
        }

        public void HandleResult(bool isSuccessful, string resultText, string error)
        {
            switch (this.Type)
            {
                case RequestType.recognize:
                    this.Result = new ImageRecognitionResult(isSuccessful, error, resultText);
                    break;
                case RequestType.recommend:
                    this.Result = new RecommenderResult(isSuccessful, error, resultText);
                    break;
                default:
                    this.Result = new RequestResult(isSuccessful, error);
                    break;
            }
        }
    }
}
