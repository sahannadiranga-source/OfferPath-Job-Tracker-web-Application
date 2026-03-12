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
                Status = dto.Status,
                AppliedDate = dto.AppliedDate,
                Notes = dto.Notes
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
            job.Status = dto.Status;
            job.AppliedDate = dto.AppliedDate;
            job.Notes = dto.Notes;

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