namespace RunoLandingPage.Models
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; }
        T GetById(int id);
        T Add(T newItem);
        T Update(T updatedItem);
        T Remove(int id);
    }
}
