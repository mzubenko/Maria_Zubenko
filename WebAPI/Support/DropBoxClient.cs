using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DropboxClient
    {
        private string ACCESS_TOKEN = Support.token;
        private HttpClient _client;

        public DropboxClient()
        {
            _client = new HttpClient();
        }

        public JObject UploadFile(string filePath, string dropboxPath)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Support.UploadPath),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" },
                    { "Dropbox-API-Arg", $"{{\"autorename\":false,\"mode\":\"overwrite\",\"mute\":false,\"path\":\"{dropboxPath}\",\"strict_conflict\":false}}" }
                },
                Content = new StreamContent(new FileStream(filePath, FileMode.Open)),
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = _client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to upload file");
            }
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public JObject GetFileMetadata(string dropboxPath)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Support.GetMetaDataPath),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = _client.SendAsync(request).Result;
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        public JObject DeleteFile(string dropboxPath)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Support.DeletePath),
                Headers = {
                    { "Authorization", $"Bearer {ACCESS_TOKEN}" }
                },
                Content = new StringContent($"{{\"path\": \"{dropboxPath}\"}}", Encoding.UTF8, "application/json")
            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = _client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete file");
            }
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}

