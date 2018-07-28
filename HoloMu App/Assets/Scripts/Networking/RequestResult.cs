namespace HoloMu.Networking
{
    public class RequestResult
    {
        public bool IsSuccessful { get; private set; }
        public string ErrorMessage { get; private set; }

        public RequestResult(bool isSuccessful, string errorMessage)
        {
            this.IsSuccessful = isSuccessful;
            this.ErrorMessage = errorMessage;
        }
    }
}
