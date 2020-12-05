namespace healthexplore.filters.api.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Configuration;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    public class Repository<T> : IRepository<T> where T : class
    {
        private ConnectionString _connectionString;

        public Repository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<T> GetAll()
        {
            try
            {
                var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionString.FiltersConnectionString);
                using (StreamReader stream = File.OpenText(filePath))
                {
                    string jsonString = await stream.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}