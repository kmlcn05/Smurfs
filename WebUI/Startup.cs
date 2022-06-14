using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace WebUI
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
    }
    public class Startup
    {
    }
}
