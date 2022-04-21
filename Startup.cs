using FilmStock.Daos;
using FilmStock.Daos.Implementations;

namespace FilmStock
{
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;
        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
            SetupInMemoryDatabases();
            ConfigureStartup();
        }

        private void SetupInMemoryDatabases()
        {
            
        }

        private void ConfigureStartup()
        {
            _builder.Services.AddControllersWithViews();
            _builder.Services.AddSingleton<IFilmDao, FilmDaoMemory>();

            var app = _builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}