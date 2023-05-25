namespace TrincaBBQControl.Domain.Entities
{
    public class Barbecue : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
