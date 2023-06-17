using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyContactManagerData
{
    public class MyContactManagerDbContext : DbContext 
    {
        private static IConfigurationRoot _configuration; //will allow to use a builder to get data config string

        public MyContactManagerDbContext()  //scaffold
        {

        }
                                                                     //leverage connection strings from appsettings
        public MyContactManagerDbContext(DbContextOptions options) : base(options)
        {

        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//to bring in connection string
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
            var cnstr = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(cnstr);
                
         }
    }
}