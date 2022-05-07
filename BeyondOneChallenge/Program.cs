using BeyondOneChallenge;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BeyondOne.Data.BeyondOneDbContext>(options =>
{
    //Create the configuration to read from appsettings.json
    var configuration = new ConfigurationBuilder().AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")).Build();
    options.UseSqlServer(configuration.GetConnectionString("BeyondOneDb"), x => x.MigrationsAssembly("BeyondOne.Data.Migrations"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//#if DEBUG
//                webBuilder.UseEnvironment(Environments.Development);
//#endif
//                webBuilder.ConfigureAppConfiguration((context, configBuilder) =>
//            {
//                configBuilder.AddJsonFile($"appsettings.json", true, true)
//                             .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true)
//                             .AddEnvironmentVariables();
//            });
//                webBuilder.UseStartup<Startup>();
//            });
//}