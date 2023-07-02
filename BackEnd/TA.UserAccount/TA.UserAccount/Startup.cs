using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.ObjectModel;
using TA.Framework.Application.Infrastructure.ApiVersioning;
using TA.Framework.Application.Model;
using TA.UserAccount.Infrastructure.Swagger;

namespace TA.UserAccount
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(v =>
            {
                v.DefaultApiVersion = new ApiVersion(1, 0);
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.ErrorResponses = new ApiVersioningErrorResponseProvider();
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValue>();
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Using the Authorization header with the Bearer schema.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearer",
                    },
                };

                options.AddSecurityDefinition("bearer", securitySchema);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securitySchema, new[] { "bearer" } },
                });
            });

            // Add Authorization Here

            // Add Bootstrapper Here
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(option => { option.RouteTemplate = "api-docs/{documentName}/docs.json"; });
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "api-docs";
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/api-docs/{description.GroupName}/docs.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseExceptionHandler("/error");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private Task BuildAuthErrorResponse(HttpResponse response, int statusCode, string errorMessage)
        {
            var errorMessages = new Collection<string>();
            errorMessages.Add(errorMessage);

            var responseObj = new ApiErrorModel
            {
                ErrorMessages = errorMessages.ToArray(),
            };

            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            return response.WriteAsync(JsonConvert.SerializeObject(responseObj).ToString());
        }
    }
}
