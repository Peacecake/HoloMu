namespace HoloMu
{
    public class Error
    {
        public ErrorType Type { get; private set; }
        public string Message { get; private set; }

        public Error(ErrorType type, string message)
        {
            this.Type = type;
            this.Message = message;
        }
    }
}
