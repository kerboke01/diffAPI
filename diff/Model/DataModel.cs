using Microsoft.EntityFrameworkCore;

namespace diff.Model
{
    public class DataModel : DbContext
    {
        public DataModel(DbContextOptions<DataModel> options) : base(options)
        {

        }


        public DbSet<DataContainer> AllData { get; set; }

    }
}
