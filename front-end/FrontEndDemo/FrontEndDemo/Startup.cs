
using Microsoft.EntityFrameworkCore;
using FrontEndDemo.Data;
using System.Configuration;

namespace FrontEndDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(connectionString: _configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
