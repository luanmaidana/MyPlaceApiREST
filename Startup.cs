using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Myplace.Data;
using MyPlace.Data;
using MyPlace.Negocios;
using Newtonsoft.Json.Serialization;

namespace MyPlace
{
    public class Startup
    {

        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {        

            services.AddDbContext<MyPlaceDbContext>(options =>
                options.UseNpgsql(connectionString: "Host=localhost;Port=5432;Pooling=true;Database=MyPlace;User Id=postgres;Password=root;"));

            services.AddDefaultIdentity<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MyPlaceDbContext>()
                    .AddDefaultTokenProviders();

            services.AddControllers();
            
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

           
            services.AddScoped<MyPlaceDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddHttpContextAccessor();

            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo{
                    Title = "MyPlace Api",
                    Description = "Esta API está em andamento",
                    Contact = new OpenApiContact() {Name = "Luan Maidana Lima", Email = "luanmaidanalima_@hotmail.com"}                });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
    }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        
        }
    }
}