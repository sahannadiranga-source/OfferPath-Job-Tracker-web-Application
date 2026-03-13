namespace OfferPath.Api.Dtos
{
    public class JobApplicationDto
    {
        public string Company { get; set; } = "";

        public string Position { get; set; } = "";

        public string Location { get; set; } = "";

        public string JobType { get; set; } = "";

        public string Salary { get; set; } = "";

        public string Category { get; set; } = "";

        public string ExperienceLevel { get; set; } = "";

        public DateTime PostedDate { get; set; }

        public DateTime Deadline { get; set; }

        public string Description { get; set; } = "";

        public string ImageUrl { get; set; } = "";
    }
}