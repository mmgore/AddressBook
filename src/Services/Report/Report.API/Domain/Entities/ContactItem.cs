namespace Report.API.Domain.Entities
{
    public class ContactItem : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public IList<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();

    }
}
