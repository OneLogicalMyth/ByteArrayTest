using System.Net;
using System.Text;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotChocolate.Types;
using ByteArrayTest.Data;
using ByteArrayTest.GraphQL;

namespace ByteArrayTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApiDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ByteArrayTestDB")));

            services
                .AddGraphQLServer()
                // query
                .AddType<Query>()
                // scalars
                .AddType(new UuidType('D'))
                .AddType<ByteArrayType>()
                // add filtering and sorting
                .AddFiltering()
                .AddSorting();
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
                endpoints.MapGraphQL();
            });
        }
    }
}