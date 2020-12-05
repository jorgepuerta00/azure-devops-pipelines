namespace healthexplore.filters.api.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Filters
    {
        [JsonProperty("job_type")]
        public List<JobType> JobType { get; set; }

        [JsonProperty("work_schedule")]
        public List<WorkSchedule> WorkSchedule { get; set; }

        [JsonProperty("experience")]
        public List<Experience> Experience { get; set; }

        [JsonProperty("department")]
        public List<Department> Department { get; set; }
    }

    public class JobType : BaseEntity { }
    public class WorkSchedule : BaseEntity { }
    public class Experience : BaseEntity { }
    public class Department : BaseEntity { }
}