using AutoMapper;
using Cursos.Dominio.Interfaces.Repositorios;
using Cursos.Dominio.Interfaces.Services;
using Cursos.Infra.Data;
using Cursos.Infra.Repositories;
using Cursos.Servicos;
using Cursos.Servicos.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursosApiDdd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);






            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CursosApiDdd", Version = "v1" });
            });
            services.AddControllers();

            services.AddDbContext<Context>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));
            //Injections repositorios

            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<ICursoRepositorio, CursoRepositorio>();
            services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();
            services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
            //injection services
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<ICursoService, CursoService>();
            services.AddTransient<ITurmaService, TurmaService>();
            services.AddTransient<IProfessorService, ProfessorService>();



            //context
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CursosApiDdd v1"));
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
