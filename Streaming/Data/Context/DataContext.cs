using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Streaming.Data.Entity;

namespace Streaming.Data.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
          //  var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<users>Users { get; set; }
    }
}