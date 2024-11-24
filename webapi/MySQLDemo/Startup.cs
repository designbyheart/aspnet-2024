using Microsoft.EntityFrameworkCore;
using MySQLDemo.Data;
using System.Configuration;

namespace MySQLDemo
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(connectionString: _configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
