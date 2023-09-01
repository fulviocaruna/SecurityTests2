using Azure.Identity;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SecurityTests.Services;

namespace SecurityTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


			// Storing secrets in Azure
			/*
			builder.Configuration.AddAzureAppConfiguration(options =>
			{
				options.Connect("...")
				.ConfigureKeyVault(vault =>
				{
					vault.SetCredential(new DefaultAzureCredential());
				});
			});
			*/

			// Add services to the container.
			// builder.Services.AddControllersWithViews();

			builder.Services.AddControllersWithViews(options => {
				options.Filters.Add(
				new AutoValidateAntiforgeryTokenAttribute());
			});

			// Add Razor pages support
			builder.Services.AddRazorPages();

            // Add session support
            builder.Services.AddDistributedMemoryCache();
			builder.Services.AddSession(options => {
				options.Cookie.IsEssential = true;
				options.Cookie.HttpOnly = true;
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				options.IdleTimeout = TimeSpan.FromMinutes(5);
				options.Cookie.SameSite = SameSiteMode.Strict;
			});

			// Setting anti forgery names and options
			builder.Services.AddAntiforgery(options => {
				// options.FormFieldName = "__AntiXsrfToken_Pipaxa";
				// options.HeaderName = "X-Anti-Xsrf-Token-Pipaxa";
				options.Cookie.SameSite = SameSiteMode.Strict;
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				options.Cookie.HttpOnly = true;
				options.SuppressXFrameOptionsHeader = true;
			});

			// Add Strict transport security support
			builder.Services.AddHsts(options =>
			{
				options.IncludeSubDomains = true;
				options.MaxAge = TimeSpan.FromDays(365);
				options.Preload = true;
			});

			// Setting CORS
			builder.Services.AddCors(options =>
			{
				/*
options.AddDefaultPolicy(
builder =>
{
	builder.WithOrigins("https://localhost:7108");
});
*/
				/*
				options.AddPolicy(
				"CORS API Endpoint",
				builder =>
				{
					builder.WithOrigins("https://localhost:7159");
				});
				*/
			});


			// Data Protection API configuration
			builder.Services.AddDataProtection()
			.PersistKeysToFileSystem(new DirectoryInfo("C:\\keys"));

			// Mitigating reconnaissance
			/*
			builder.WebHost.UseKestrel(options =>
			{
				options.AddServerHeader = false;
			});
			*/

			// Health checks midleware
			/*
builder.Services
.AddHealthChecks()
.AddCheck("Changing health states", () =>
{
    return (DateTime.Now.Second % 3) switch
    {
        0 => HealthCheckResult.Healthy(),
        1 => HealthCheckResult.Degraded(),
        _ => HealthCheckResult.Unhealthy(),
    };
});
*/
			/*
builder.Services
.AddHealthChecks()
.AddCheck<ChangingHealthStates>("Changing health states");
*/

			builder.Services
			.AddHealthChecks()
			.AddUrlGroup(new Uri("https://localhost:7151/"),    
			// new Uri("https://www.manning.com/"),
			timeout: TimeSpan.FromSeconds(3));

			builder.Services
.AddHealthChecksUI()
.AddInMemoryStorage();

			var app = builder.Build();

			app.Use(async (context, next) =>
			{
				context.Response.Headers.Add("Referrer-Policy", "no-referrer");
				context.Response.Headers.Add("Feature-Policy", "storage-access 'none'; fullscreen 'none'");

				await next.Invoke();
			});

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				// app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				// app.UseHsts();
				// app.UseStatusCodePagesWithReExecute("/Error/{0}");
				app.UseStatusCodePagesWithRedirects("/Error/{0}");
				app.UseExceptionHandler("/apierror");
			}
			else
			{
				app.UseDeveloperExceptionPage();

			}

			app.UseHsts();

			app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

			app.MapHealthChecks("/health")
				.RequireHost("localhost");

			app.MapHealthChecks(
"/health-ui",
new HealthCheckOptions()
{
	ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
	Predicate = _ => true
}).RequireHost("localhost");

			app.MapHealthChecksUI();


			app.UseSession();

            app.Run();
        }
    }
}