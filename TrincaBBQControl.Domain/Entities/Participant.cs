namespace TrincaBBQControl.Domain.Entities
{
    public class Participant : BaseEntity
    {
        public string Name { get; set; }
        public decimal ContributionAmount { get; set; }
        public decimal SuggestedContribution { get; set; }
        public bool IncludesBeverage { get; set; }
        public int BarbecueId { get; set; }

    }
}
