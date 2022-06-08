namespace Report.API.Domain.Entities
{
    public class ContactInformation : Entity
    {
        public Guid ContactItemId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
        public int Count { get; set; }
    }
}
