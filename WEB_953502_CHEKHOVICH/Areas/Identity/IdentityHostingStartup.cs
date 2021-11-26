using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WEB_953502_CHEKHOVICH.Areas.Identity.IdentityHostingStartup))]
namespace WEB_953502_CHEKHOVICH.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}