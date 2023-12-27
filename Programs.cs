
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Programs {
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddCors(o => o.Addpo1icy("Mypo1icy", builder =>
        {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

        builder.Withorigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .Allowcredentials();
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<BookService>();
            services.AddScoped<AuthorService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });






            services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));


            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}






