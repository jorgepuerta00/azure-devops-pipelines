namespace healthexplore.filters.api.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        public Task<T> GetAll();
    }
}