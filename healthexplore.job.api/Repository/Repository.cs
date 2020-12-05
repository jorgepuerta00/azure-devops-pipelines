namespace healthexplore.job.api.Repository
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Configuration;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Models;

    public class Repository<T> : IRepository<T> where T : Job
    {
        private ConnectionString _connectionString;

        public Repository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionString.JobConnectionString);
                using (StreamReader stream = File.OpenText(filePath))
                {
                    string jsonString = await stream.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                }
            }
            catch
            {
                return new List<T>();
            }
        }

        public async Task<IEnumerable<T>> SearchByKeyword(string keyword)
        {
            try
            {
                var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _connectionString.JobConnectionString);
                using (StreamReader stream = File.OpenText(filePath))
                {
                    string jsonString = await stream.ReadToEndAsync();
                    var dataSet = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);

                    var newDataSet = dataSet.Where(j => j.Name.ToLower().Contains(keyword) || j.JobTitle.ToLower().Contains(keyword)).ToList();

                    return newDataSet;
                }
            }
            catch
            {
                return new List<T>();
            }
        }
    }
}