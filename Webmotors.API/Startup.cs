using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Webmotors.Domain.Entities;
using Webmotors.Infra.DBContext;
using Webmotors.Service.DTOs.Anuncio;

namespace Webmotors.API
{
    public class Startup
    {
        public static readonly LoggerFactory _sqlLogger =
            new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextWebmotors>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DbContextWebmotors"),
                                                sqlServerOptions => sqlServerOptions.CommandTimeout(600))
                                  .UseLoggerFactory(_sqlLogger));

            Register.RegisterDependencies(services);

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Webmotors API", Version = "v1" });
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnuncioDTO, Anuncio>();
                cfg.CreateMap<Anuncio, AnuncioDTO>();
                cfg.CreateMap<TbAnuncioWebmotors, Anuncio>();
                cfg.CreateMap<Anuncio, TbAnuncioWebmotors>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            logger.AddLog4Net();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Webmotors API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(options => options.AllowAnyOrigin());
        }
    }
}
