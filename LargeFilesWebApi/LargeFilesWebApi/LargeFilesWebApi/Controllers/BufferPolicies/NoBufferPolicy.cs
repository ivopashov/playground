using System.Net.Http;
using System.Web.Http.WebHost;

namespace LargeFilesWebApi.Controllers.BufferPolicies
{
    public class NoBufferPolicy : WebHostBufferPolicySelector
    {
        public override bool UseBufferedOutputStream(HttpResponseMessage response)
        {
            if (response.RequestMessage.RequestUri.LocalPath.Contains("download"))
            {
                return false;
            }

            return base.UseBufferedOutputStream(response);
        }
    }
}