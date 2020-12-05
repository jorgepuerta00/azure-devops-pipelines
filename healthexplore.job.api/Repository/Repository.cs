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
    using Newtonsoft.Json.Linq;

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
                    var json = JToken.Parse(jsonString);

                    listValuesFound = new List<ResultSearch>();
                    int indexRoot = 0;

                    foreach (var root in json)
                    {
                        var children = root.Children();
                        Fetch(children, keyword, root, indexRoot);
                        indexRoot++;
                    }

                    return new List<T>();
                }
            }
            catch
            {
                return new List<T>();
            }
        }

        static List<ResultSearch> listValuesFound;

        private static void Fetch(IEnumerable<JToken> children, string valueToFind, JToken root, int indexRoot)
        {
            foreach (var child in children)
            {
                var childTemp = child.Children();

                if (child.HasValues)
                {
                    Fetch(childTemp, valueToFind, root, indexRoot);
                }
                else
                {
                    var valueWithoutChildren = child.ToObject(typeof(object));

                    if (valueWithoutChildren.ToString().ToUpper().Contains(valueToFind.ToUpper()))
                    {
                        bool indexExist = listValuesFound.Any(obj => obj.Index == indexRoot);
                        
                        if (!indexExist)
                        {
                            listValuesFound.Add(new ResultSearch() { Result = root, Index = indexRoot });
                            return;
                        }
                    }
                }
            }
        }

        public class ResultSearch
        {
            public JToken Result { get; set; }
            public int Index { get; set; }
        }
    }
}