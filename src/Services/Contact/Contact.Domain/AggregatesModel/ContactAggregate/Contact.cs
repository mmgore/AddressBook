using Contact.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public class Contact : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Firm { get; set; }
        

    }
}
