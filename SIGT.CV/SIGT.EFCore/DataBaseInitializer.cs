using Microsoft.EntityFrameworkCore;
using SIGT.Entities;
using SIGT.Infrastructure;

namespace SIGT.EFCore
{
    public class DataBaseInitializer : IDataBaseInitializer
    {
        private readonly SigtContext context;
        public DataBaseInitializer(SigtContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            using (context)
            {
                // turn off timeout for initial seeding
                context.Database.SetCommandTimeout(System.TimeSpan.FromDays(1));
                // check data base version and migrate / seed if needed
                context.Database.Migrate();
            }
        }
    }
}
