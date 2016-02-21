using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace LargeFilesWebApi.Controllers
{
    
    public class FileController : ApiController
    {
        [HttpGet]
        [Route("api/download")]
        public async Task<HttpResponseMessage> DownloadFile(int id)
        {
            try
            {
                var client = new HttpClient();
                var requestUrl = "http://my-store-provider/" + id;
                var responseWithHeadersOnly = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                responseWithHeadersOnly.EnsureSuccessStatusCode();

                Stream streamToReadFrom = await responseWithHeadersOnly.Content.ReadAsStreamAsync();

                var buffer = new byte[65536];
                var result = Request.CreateResponse();
                int bytesRead = 0;

                result.Content = new PushStreamContent((stream, content, context) =>
                {
                    while ((bytesRead = streamToReadFrom.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }

                    stream.Close();
                    streamToReadFrom.Close();
                });

                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = "my-file-name";
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return result;
            }
            catch (Exception e)
            {
                //handle exception
                var errorResponse = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return errorResponse;
            }
        }

    }
}
