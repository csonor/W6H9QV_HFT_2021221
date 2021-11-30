using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using W6H9QV_HFT_2021221.Data;
using W6H9QV_HFT_2021221.Logic;
using W6H9QV_HFT_2021221.Repository;

namespace W6H9QV_HFT_2021221.Endpoint
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddTransient<ICountryLogic, CountryLogic>();
			services.AddTransient<ICountyLogic, CountyLogic>();
			services.AddTransient<ICityLogic, CityLogic>();
			services.AddTransient<ICountryRepository, CountryRepository>();
			services.AddTransient<ICountyRepository, CountyRepository>();
			services.AddTransient<ICityRepository, CityRepository>();
			services.AddSingleton<DbContext, CountriesDbContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
