#nullable disable
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TA.UserAccount.Infrastructure.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this._provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in this._provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "TicketingAPP API",
                Version = description.ApiVersion.ToString(),
                Description = "TicketingAPP API for user account management",
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated";
            }

            return info;
        }
    }
}
