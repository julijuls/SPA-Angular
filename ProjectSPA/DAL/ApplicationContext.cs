using Microsoft.EntityFrameworkCore;
using ProjectSPA.DAL.Models;


namespace ProjectSPA.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WeatherHistory> WeatherHistory { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
            // создаем базу данных при первом обращении
        }
    }
}
