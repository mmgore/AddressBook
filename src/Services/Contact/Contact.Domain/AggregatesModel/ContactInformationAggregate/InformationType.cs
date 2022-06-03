using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.AggregatesModel.ContactInformationAggregate
{
    public class InformationType
    {
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Location { get; private set; }
    }
}
