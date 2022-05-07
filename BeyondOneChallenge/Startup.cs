//using BeyondOne.Data;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.EntityFrameworkCore;

//namespace BeyondOneChallenge
//{
//    public class Startup
//    {
//        public IConfiguration Configuration { get; }
//        public IWebHostEnvironment WebHostEnvironment { get; }

//        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
//        {
//            Configuration = configuration;
//            WebHostEnvironment = webHostEnvironment;
//        }
//        public void ConfigureService(IServiceCollection services)
//        {
//            // register dbContexts
//            services.AddDbContext<BeyondOneDbContext>(options =>
//            {
//                options.UseSqlServer(
//                    Configuration.GetConnectionString("BeyondOneDb"),
//                    x => x.MigrationsAssembly($"{nameof(BeyondOne.Data)}.Migrations"));
//            });
//            services.AddControllers();
//            services.AddEndpointsApiExplorer();
//            services.AddSwaggerGen();
//        }

//        /// <summary>
//        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
//        /// </summary>
//        /// <param name="app"></param>
//        /// <param name="env"></param>
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }
//            else
//            {
//                app.UseExceptionHandler("/error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            var isLocalhost = Configuration.GetValue<bool>("IsLocalhost", false);
//            logger.LogInformation($"EnvironmentName: {env.EnvironmentName}");
//            var beyondOneDb = Configuration.GetConnectionString("BeyondOneDb");
//            logger.LogInformation($"BSalesDb: {beyondOneDb}");

//            if (!isLocalhost)
//                app.UseHttpsRedirection();

//            app.UseStaticFiles();
//            app.UseRouting();

//            //app.UseEndpoints(endpoints =>
//            //{
//            //    endpoints.MapControllers();
//            //});
//        }

//    }
//}
