using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using U4WM55_HFT_2021221.Models;
using U4WM55_HFT_2021221.Repository;
using U4WM55_HFT_2021221.Logic;



namespace U4WM55_HFT_2021221.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddTransient<DbContext, MakeupCompDbContext>();

            services.AddTransient<ICompetitionsRepository, CompetitionRepository>();
            services.AddTransient<IMUAsRepository, MUAsRepository>();
            services.AddTransient<ILooksRepository, LooksRepository>();
            services.AddTransient<IConnectorRepository, ConnectorRepository>();

            services.AddTransient<IParticipantLogic, ParticipantLogic>();
            services.AddTransient<IJuryLogic, JuryLogic>();
            services.AddTransient<IStatisticsLogic, StatisticsLogic>();
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
