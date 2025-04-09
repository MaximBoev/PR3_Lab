using Microsoft.AspNetCore.Mvc;
using PR3_Lab.Enums;
using PR3_Lab.Models;
using PR3_Lab.Persistence;

namespace PR3_Lab.Controllers
{
    [ApiController]
    [Route("/api/jobs")]
    public class JobController(AppDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dbContext.Jobs.ToList());
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            dbContext.Jobs.Add(job);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var job = dbContext.Jobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                dbContext.Jobs.Remove(job);
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, string title, string description, JobStatus status)
        {
            var job = dbContext.Jobs.FirstOrDefault(x => x.Id == id);
            if (job != null)
            {
                job.Title = title;
                job.Description = description;
                job.Status = status;
            }
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
