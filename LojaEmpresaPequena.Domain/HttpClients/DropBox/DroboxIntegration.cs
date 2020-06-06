using LojaEmpresaPequena.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.HttpClients.DropBox
{
    public class DroboxIntegration
    {

        private readonly ImageHandler _imageHandler;

        public DroboxIntegration()
        {
            _imageHandler = new ImageHandler();
        }

        public async Task<DropbBoxResponseSave> SendImage(IFormFile image, string pasta)
        {
            var path = $"/dudteste/lojinha/{pasta}/{image.FileName}";

            var bytesImage = _imageHandler.GetBytesFromImage(image);

            var dropBoxModel = new DropBoxUploadModel { Path = path, Mode = "add", AutoRename = true, Mute = false, Strict_Conflict = false };

            var content = new ByteArrayContent(bytesImage);
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/upload"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Add("Dropbox-API-Arg", JsonConvert.SerializeObject(dropBoxModel).ToLower());
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("Content-type", "application/octet-stream");
                message = await _httpClient.SendAsync(request);
            }
            var responseJson = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DropbBoxResponseSave>(responseJson);
        }


        public async Task<string> DeleteForlderOrArq(string pasta)
        {
            var path = $"/dudteste/lojinha/{pasta}/";


            var dropBoxModel = new DropBoxBaseModel { Path = path };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower());
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://api.dropboxapi.com/2/files/delete_v2"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                message = await _httpClient.SendAsync(request);
            }
            return await message.Content.ReadAsStringAsync();
        }


        public async Task<DropbBoxTemporaryLinkModel> GetTemporaryLink(string pathArquivo)
        {
            //var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxBaseModel { Path = pathArquivo };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower(), Encoding.UTF8, "application/json");
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://api.dropboxapi.com/2/files/get_temporary_link"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("Content-type", "application/json");
                message = await _httpClient.SendAsync(request);
            }
            var responseJson = await message.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<DropbBoxTemporaryLinkModel>(responseJson);
            return model;
        }


        public async Task<string> GetThumbNail(string pathArquivo)
        {
            var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxBaseModel { Path = path };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower());
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/get_thumbnail_v2"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                message = await _httpClient.SendAsync(request);
            }
            return await message.Content.ReadAsStringAsync();
        }

        public async Task<string> Download(string pathArquivo)
        {
            var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxBaseModel { Path = path };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower());
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/download"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                message = await _httpClient.SendAsync(request);
            }
            return await message.Content.ReadAsStringAsync();
        }

        public class DropBoxUploadModel : DropBoxBaseModel
        {
            public string Mode { get; set; }
            public bool AutoRename { get; set; }
            public bool Mute { get; set; }
            public bool Strict_Conflict { get; set; }
        }

        public class DropBoxBaseModel
        {
            public string Path { get; set; }

        }

        public class DropbBoxResponseSave
        {
            public string Name { get; set; }
            public string Path_lower { get; set; }
            public string Path_display { get; set; }
            public string Id { get; set; }
            public string Rev { get; set; }
            public int Size { get; set; }
            public bool Is_downloadable { get; set; }
        }

        public class DropbBoxTemporaryLinkModel
        {
            public string Link { get; set; }
        }
    }
}
