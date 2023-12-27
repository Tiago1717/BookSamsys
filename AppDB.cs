namespace AppDB
{
    internal class AppDBContext
    {
        public object Books { get; internal set; }
        public object Authors { get; internal set; }
        public object Book { get; internal set; }

        internal object Entry(object book)
        {
            throw new NotImplementedException();
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}