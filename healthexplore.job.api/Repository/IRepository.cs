namespace healthexplore.job.api.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> SearchByKeyword(string keyword);

        public Task<IEnumerable<T>> GetAll();
    }
}