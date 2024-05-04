using BS.Application;
using BS.Infrastructure;

namespace BS.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddPresentation();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            app.UseExceptionHandler("/error");
            app.MapControllers();
            app.Run();
        }
    }
}
