using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebsiteFirstDraft.Components;
using WebsiteFirstDraft.Data.Models;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace WebsiteFirstDraft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext with In-Memory Database for testing purposes
            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseInMemoryDatabase("FitnessSaviourMockDb"));

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped<DietQuestionnaireState>();
            builder.Services.AddScoped<ExerciseQuestionnaireState>();
            builder.Services.AddScoped<AuthService>();

            // Register UserSessionService as a singleton service because it holds user-specific data.
            builder.Services.AddSingleton<UserSessionService>();
            builder.Services.AddSingleton<UISettingsService>();
            builder.Services.AddScoped<WorkoutSplitGeneratorState>();

            builder.Services.AddBootstrapBlazor();
            builder.Services.AddBlazorBootstrap();

            var app = builder.Build();

            // Seed the database with mock data
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DatabaseSeeder.SeedDatabase(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();
            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
