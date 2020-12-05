namespace healthexplore.job.api.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class JobDetail
    {
        [JsonProperty("job_id")]
        public int JobId { get; set; }

        [JsonProperty("required_skills")]
        public List<string> RequiredSkills { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("zip")]
        public int Zip { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("nurse_patient_ratio")]
        public string NursePatientRatio { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("work_schedule")]
        public string WorkSchedule { get; set; }

        [JsonProperty("hospital_id")]
        public int HospitalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("required_credentials")]
        public List<string> RequiredCredentials { get; set; }

        [JsonProperty("department")]
        public List<string> Department { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("experience")]
        public string Experience { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("hours")]
        public List<int> Hours { get; set; }

        [JsonProperty("salary_range")]
        public List<double> SalaryRange { get; set; }

        [JsonProperty("job_type")]
        public string JobType { get; set; }
    }

    public class Job
    {
        [JsonProperty("total_jobs_in_hospital")]
        public int TotalJobsInHospital { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("items")]
        public List<JobDetail> Jobs { get; set; }
    }
}