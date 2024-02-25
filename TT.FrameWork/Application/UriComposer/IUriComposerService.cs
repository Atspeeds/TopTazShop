namespace TT.FrameWork.Application.UriComposer
{
    public interface IUriComposerService
    {
        string ComposeImageUri(string src);
    }

    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string src)
        {
            return "http://localhost:43908/" + src.Replace("\\", "//"); 
        }
    }
}
