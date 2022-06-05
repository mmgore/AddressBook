using AutoMapper;
using Contact.Application.Commands.CreateContact;
using Contact.Application.Commands.UpdateContact;
using Contact.Application.Validations;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.Exceptions;
using Contact.Domain.SeedWork;
using Contact.Infrastructure.Repositories;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Contact.UnitTests
{
    public class ContactItemTest
    {
        [Fact]
        public void Create_contact_item_success()
        {
            var sut = ContactItem.Create(firsName, lastName, firm);

            sut.Should().NotBeNull();
        }
        [Fact]
        public void Create_contact_item_failure()
        {
            Action sut = () => ContactItem.Create(firsName, lastName, nullFirm);

            sut.Should().Throw<ContactDomainException>()
                .WithMessage("Firm cannot be null");
        }


        private string firsName => "fakeName";
        private string lastName => "fakeLastName";
        private string firm => "fakeFirm";
        private string nullFirm => "";
    }
}
