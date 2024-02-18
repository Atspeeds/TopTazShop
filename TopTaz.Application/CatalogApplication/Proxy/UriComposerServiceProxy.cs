using TopTaz.Application.CatalogApplication.UriComposer;

namespace TopTaz.Application.CatalogApplication.Proxy
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
