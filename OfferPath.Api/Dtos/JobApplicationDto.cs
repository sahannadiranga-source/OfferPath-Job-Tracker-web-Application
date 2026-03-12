namespace OfferPath.Api.Dtos
{
    public class JobApplicationDto
    {
        public string Company { get; set; } = "";
        public string Position { get; set; } = "";
        public string Location { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime AppliedDate { get; set; }
        public string Notes { get; set; } = "";
    }
}