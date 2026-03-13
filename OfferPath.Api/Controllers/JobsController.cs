using Microsoft.AspNetCore.Mvc;
using OfferPath.Api.Data;
using OfferPath.Api.Dtos;
using OfferPath.Api.Models;

namespace OfferPath.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jobs = _context.JobApplications.ToList();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = _context.JobApplications.FirstOrDefault(x => x.Id == id);

            if (job == null)
            {
                return NotFound("Job not found.");
            }

            job.ViewCount += 1;
            _context.SaveChanges();

            return Ok(job);
        }

        [HttpPost]
        public IActionResult Create(JobApplicationDto dto)
        {
            var job = new JobApplication
            {
                UserId = 1,
                Company = dto.Company,
                Position = dto.Position,
                Location = dto.Location,
                JobType = dto.JobType,
                Salary = dto.Salary,
                Category = dto.Category,
                ExperienceLevel = dto.ExperienceLevel,
                PostedDate = dto.PostedDate,
                Deadline = dto.Deadline,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                ViewCount = 0
            };

            _context.JobApplications.Add(job);
            _context.SaveChanges();

            return Ok(job);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, JobApplicationDto dto)
        {
            var job = _context.JobApplications.FirstOrDefault(x => x.Id == id);

            if (job == null)
            {
                return NotFound("Job not found.");
            }

            job.Company = dto.Company;
            job.Position = dto.Position;
            job.Location = dto.Location;
            job.JobType = dto.JobType;
            job.Salary = dto.Salary;
            job.Category = dto.Category;
            job.ExperienceLevel = dto.ExperienceLevel;
            job.PostedDate = dto.PostedDate;
            job.Deadline = dto.Deadline;
            job.Description = dto.Description;
            job.ImageUrl = dto.ImageUrl;

            _context.SaveChanges();

            return Ok(job);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var job = _context.JobApplications.FirstOrDefault(x => x.Id == id);

            if (job == null)
            {
                return NotFound("Job not found.");
            }

            _context.JobApplications.Remove(job);
            _context.SaveChanges();

            return Ok("Job deleted successfully.");
        }
    }
}