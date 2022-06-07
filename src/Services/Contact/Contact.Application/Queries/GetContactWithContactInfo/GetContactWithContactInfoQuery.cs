using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Queries.GetContactWithContactInfo
{
    public class GetContactWithContactInfoQuery : IRequest<GetContactWithContactInfoViewModel>
    {
        public Guid Id { get; private set; }
        public GetContactWithContactInfoQuery(Guid id)
        {
            Id = id;
        }
    }
    
    public class GetContactWithContactInfoDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public List<ContactInfoDto> ContactInfos { get; set; }
    }

    public class ContactInfoDto
    {
        public Guid ContactId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }

    public class GetContactWithContactInfoViewModel
    {
        public IEnumerable<GetContactWithContactInfoDto> ContactInfos { get; set; }
    }
}
