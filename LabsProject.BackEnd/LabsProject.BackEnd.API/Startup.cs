using LabsProject.BackEnd.Domain.Handlers;
using LabsProject.BackEnd.Domain.Queries;
using LabsProject.BackEnd.Domain.Repositories;
using LabsProject.BackEnd.Infrastructure.Context;
using LabsProject.BackEnd.Infrastructure.Repositories;
using LabsProject.BackEnd.Services.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace LabsProject.BackEnd.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LabsProject.BackEnd.API", Version = "v1" });
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            var connection = Configuration.GetConnectionString("connectionString");

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connection));

            services.AddTransient<AssociateLabsWithTestsConfigurationTestsHandler, AssociateLabsWithTestsConfigurationTestsHandler>();
            services.AddTransient<AssociateLabsWithTestsHandler, AssociateLabsWithTestsHandler>();
            services.AddTransient<LaboratoriesHandler, LaboratoriesHandler>();
            services.AddTransient<TestsHandler, TestsHandler>();
            services.AddTransient<IAssociateLabsWithTestsRepository, AssociateLabsWithTestsRepository>();
            services.AddTransient<ILaboratoriesRepository, LaboratoriesRepository>();
            services.AddTransient<ITestsRepository, TestsRepository>();
            services.AddTransient<IAssociateLabsWithTestsQueries>(provider => new AssociateLabsWithTestsQueries(connection));
            services.AddTransient<ITestsQueries>(provider => new TestsQueries(connection));
            services.AddTransient<ILaboratoriesQueries>(provider => new LaboratoriesQueries(connection));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LabsProject.BackEnd.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
