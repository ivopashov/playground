using LargeFilesWebApi.Controllers.BufferPolicies;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace LargeFilesWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHostBufferPolicySelector), new NoBufferPolicy());
        }
    }
}
