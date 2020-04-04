using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SnivelingShitApi.DataAccess;
using SnivelingShitApi.Services;
using SnivelingShitApi.Services.MessageCounter;
using SnivelingShitApi.Services.VkApiCreator;
using SnivelingShitApi.Services.VkMessageSender;

namespace SnivelingShitApi
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
            var privateData = File.ReadAllLines(@"./private_data.txt");

            var dbConnectionString = privateData[0];

            var vkLogin = privateData[1];
            var vkPassword = privateData[2];


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<DataContext>(builder => builder.UseNpgsql(dbConnectionString));

            services.AddTransient<IVkApiCreatorService, VkApiCreatorService>(provider =>
                new VkApiCreatorService(vkLogin, vkPassword));

            services.AddTransient<IMessageCounterService, MessageCounterService>();

            services.AddTransient<IVkMessageSenderService, VkMessageSenderService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}