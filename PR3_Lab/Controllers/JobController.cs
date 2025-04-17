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
        public IActionResult Create([FromBody] Job job)
        {
            dbContext.Jobs.Add(job);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = job.Id }, job);
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
        public IActionResult Update([FromRoute] int id, [FromBody] Job updatedJob)
        {
            var job = dbContext.Jobs.FirstOrDefault(x => x.Id == id);
            if (job == null) return NotFound();

            job.Title = updatedJob.Title;
            job.Description = updatedJob.Description;
            job.Status = updatedJob.Status;

            dbContext.SaveChanges();
            return Ok();
        }
    }
}
