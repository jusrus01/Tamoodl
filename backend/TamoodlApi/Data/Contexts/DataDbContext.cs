using Microsoft.EntityFrameworkCore;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Contexts
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            :
            base(options)
        {
            
        }
        public DbSet<StudentModel> Students { get; set; }
    }
}