using System.Net.Http.Json;
using PR3_Lab.Client.Models;
namespace PR3_Lab.Client.Services
{
    public class JobService
    {
        private readonly HttpClient _httpClient;

        public JobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Job>> GetJobsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Job>>("/api/jobs") ?? [];
        }

        public async Task CreateJobAsync(Job job)
        {
            await _httpClient.PostAsJsonAsync("/api/jobs", job);
        }

        public async Task UpdateJobAsync(int id, Job job)
        {
            await _httpClient.PutAsJsonAsync($"/api/jobs/{id}", job);
        }

        public async Task DeleteJobAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/jobs/{id}");
        }
    }
}
