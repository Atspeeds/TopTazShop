using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TopTaz.Infrastrure.ExternalApi.ImageServer
{
    public interface IImageUploadService
    {
        Task<List<string>> Upload(List<IFormFile> files);
    }
    public class ImageUploadService : IImageUploadService
    {
        public async Task<List<string>> Upload(List<IFormFile> files)
        {
            var options = new RestClientOptions("https://localhost:44336")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/Api/Images?apikey=mysecretkey&F", Method.Post);
            request.AlwaysMultipartFormData = true;
            foreach (var item in files)
            {
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    item.CopyToAsync(ms);
                    bytes = ms.ToArray();
                }
                request.AddFile(item.FileName, bytes, item.FileName, item.ContentType);
            }
            RestResponse response = await client.ExecuteAsync(request);
            UploadDto upload = JsonConvert.DeserializeObject<UploadDto>(response.Content);
            return upload.FileNameAddress;

        }
    }


    public class UploadDto
    {
        public bool Status { get; set; }
        public List<string> FileNameAddress { get; set; }
    }
}
