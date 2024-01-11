using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppDB
{
    internal class AppDBContext
    {
        public object Books { get; internal set; }
        public object Authors { get; internal set; }

        public async Task<int> SaveChangesAsync()
        {
            
            Console.WriteLine("Saving changes to the database...");
            await Task.Delay(100);
            return 1;
        }

    }
}