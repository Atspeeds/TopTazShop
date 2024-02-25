using TT.FrameWork.Application.UriComposer;

namespace TT.FrameWork.Application.Proxy
{
    public class UriComposerServiceProxy
    {
        private readonly IUriComposerService _uriComposerService;

        public UriComposerServiceProxy()
        {
            _uriComposerService = new UriComposerService();
        }


        public string GetComposeImageUri(string src)
        {
            return _uriComposerService.ComposeImageUri(src);
        }

    }
}
