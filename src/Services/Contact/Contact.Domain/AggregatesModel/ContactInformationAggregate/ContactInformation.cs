using Contact.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.AggregatesModel.ContactInformationAggregate
{
    public class ContactInformation : Entity
    {
        public InformationType InformationType { get; private set; }
        public string Content { get; private set; }
    }
}
