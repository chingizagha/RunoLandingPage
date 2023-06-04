using Microsoft.EntityFrameworkCore;

namespace RunoLandingPage.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<T> table;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll => table.ToList();

        public T Add(T newItem)
        {
            table.Add(newItem);
            return newItem;
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public T Remove(int id)
        {
            T item = GetById(id);
            if(item != null)
            {
                table.Remove(item);
            }
            return item;
        }

        public T Update(T updatedItem)
        {
            var entity = table.Attach(updatedItem);
            entity.State = EntityState.Modified;
            return updatedItem;
        }
    }
}
