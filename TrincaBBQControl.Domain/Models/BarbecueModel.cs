using TrincaBBQControl.Domain.Entities;

namespace TrincaBBQControl.Domain.Models
{
    public class BarbecueModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string AdditionalNotes { get; set; }
        public int TotalParticipants { get; set; }
        public decimal TotalContributionAmount { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
