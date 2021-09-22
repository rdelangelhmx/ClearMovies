using Infrastructure;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Context;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configSection = configuration.GetSection("Configuration");
            appSettings = configSection.Get<ConfigApp>();
        }

        public IConfiguration Configuration { get; }
        public IConfigurationSection configSection { get; }
        public ConfigApp appSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Configuration
            services.Configure<ConfigApp>(Configuration.GetSection("Configuration"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ConfigApp>>().Value);

            // Add App Injection
            services.AddApplication();
            services.AddPersistence(appSettings);
            services.AddUnitOfWork<MoviesContext>();
            services.AddInfrastructure();

            // Add CORS
            services.AddCors(options =>
            {
                options.AddPolicy(appSettings.Security.Cors, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Add Languaje Support
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SupportedCultures = new[]
                {
                    new System.Globalization.CultureInfo("es-MX")
                };
                options.SupportedUICultures = new[]
                {
                    new System.Globalization.CultureInfo("es-MX")
                };
            });

            // Add Security Site
            var key = Encoding.ASCII.GetBytes(appSettings.Security.SecurityKey);
            services.AddAuthentication(options =>
            {
                // Set jwt authentication
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                // Configure jwt authentication
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings.Security.Issuer,
                    ValidAudience = appSettings.Security.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Set jwt policy
            var defaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .Build();

            services.AddControllers()
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                jsonOptions.JsonSerializerOptions.MaxDepth = 0;
            });

            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(appSettings.Application.Version, new OpenApiInfo
                {
                    Title = appSettings.Application.Name,
                    Version = appSettings.Application.Version,
                    Description = appSettings.Application.Description,
                    TermsOfService = new Uri(appSettings.Application.TermsAndConditions),
                    Contact = new OpenApiContact
                    {
                        Name = appSettings.Application.Company,
                        Email = appSettings.Application.Email,
                        Url = new Uri(appSettings.Application.WebPage),
                    },
                    License = new OpenApiLicense
                    {
                        Name = appSettings.Application.LicenceType,
                        Url = new Uri(appSettings.Application.Licence),
                    }
                });
            });

            services.AddMvc(setup =>
            {
                setup.Filters.Add(new AuthorizeFilter(defaultPolicy));
            })
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            // Add functionality to inject IOptions<T>
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error/index.html");
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = "swagger"; //  string.Empty;
                c.SwaggerEndpoint($"/swagger/{appSettings.Application.Version}/swagger.json", $"{appSettings.Application.Name} {appSettings.Application.Version}");
                // Custom CSS
                c.InjectStylesheet("/swagger-ui/custom.css");
            });

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es-MX"),
                // Formatting numbers, dates, etc.
                SupportedCultures = new[] {
                    new System.Globalization.CultureInfo("es-MX")
                },
                // UI strings that we have localized.
                SupportedUICultures = new[] {
                    new System.Globalization.CultureInfo("es-MX")
                }
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            //app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(appSettings.Security.Cors);
        }
    }
}
