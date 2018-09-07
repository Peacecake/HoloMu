using HoloMu.Networking;

namespace HoloMu
{
    public delegate void ApiRequestResultHandler(object sender, ApiRequest request);
    public delegate void PhotoCaptureHandler(object sender, int instanceId, byte[] file);
    public delegate void InfoPanelDestroyHandler(object sender);
    public delegate void ErrorHandler(object sender, Error error);
}
