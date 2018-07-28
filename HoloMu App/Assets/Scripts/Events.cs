using HoloMu.Networking;

namespace HoloMu
{
    public delegate void ApiRequestResultHandler(object sender, ApiRequest request);
    public delegate void PhotoCaptureHandler(object sender, byte[] file);
}
