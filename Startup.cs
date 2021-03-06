using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Needs.API {
    public class Test {
        public string Id;
        public Test() {
            Id = Guid.NewGuid().ToString();
        }
    }
    public class Startup {
        
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddSingleton<Test>();
            services.AddDbContext<ORM.NeedsDbContext>(opt => opt.UseInMemoryDatabase("NeedsDB"));
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Needs API V1");
            });

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context => {
                    await context.Response.WriteAsync("HOME");
                });
            });
        }
    }
}
