using AutoMapper;
using Contact.Application.Automapper;
using Contact.Application.Commands.CreateContact;
using Contact.Application.Commands.UpdateContact;
using Contact.Application.Exceptions;
using Contact.Application.Queries.GetContactById;
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
        private readonly Mock<IContactItemRepository> _contactItemRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public ContactItemTest()
        {
            _contactItemRepositoryMock = new Mock<IContactItemRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutomapperProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
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

        [Fact]
        public async void Should_update_contact_successful()
        {
            var fakeContact = ContactItem.Create("fakeName", "fakeLast", "fakeFirm");
            var fakeFirm = "newFirm";

            var logger = new Mock<ILogger<UpdateContactCommandHandler>>();

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(fakeContact.Id))
                .ReturnsAsync(fakeContact);

            _contactItemRepositoryMock.Setup(r => r.UpdateAsync(fakeContact));

            var cmd = new UpdateContactCommand() { Id = fakeContact.Id, FirstName= fakeContact.FirstName, LastName = fakeContact.LastName, Firm = fakeFirm };

            var handler = new UpdateContactCommandHandler(_contactItemRepositoryMock.Object, _unitOfWorkMock.Object, logger.Object, _mapper);

            var sut = await handler.Handle(cmd, CancellationToken.None);

            sut.Should().Be(Unit.Value);
            fakeContact.Firm.Should().Be(fakeFirm);
        }

        [Fact]
        public async void Should_get_contat_by_id_successful()
        {
            var fakeContact = ContactItem.Create("fakeName", "fakeLast", "fakeFirm");

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(It.IsAny<Guid>()))
                .ReturnsAsync(fakeContact);

            var cmd = new GetContactByIdQuery() { ContactItemId = fakeContact.Id };

            var handler = new GetContactByIdQueryHandler(_contactItemRepositoryMock.Object, _mapper);

            var sut = await handler.Handle(cmd, CancellationToken.None);

            sut.FirstName.Should().Be(fakeContact.FirstName);
            sut.LastName.Should().Be(fakeContact.LastName);
            sut.Firm.Should().Be(fakeContact.Firm);
        }

        [Fact]
        public async void Should_get_contact_by_id_throw_exception()
        {
            var fakeContact = ContactItem.Create("fakeName", "fakeLast", "fakeFirm");

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(It.IsAny<Guid>()))
                .ReturnsAsync((ContactItem)null);

            var cmd = new GetContactByIdQuery() { ContactItemId = fakeContact.Id };

            var handler = new GetContactByIdQueryHandler(_contactItemRepositoryMock.Object, _mapper);

            Func<Task> sut = async() => await handler.Handle(cmd, CancellationToken.None);

            sut.Should().ThrowAsync<NotFoundException>();
        }

        private string firsName => "fakeName";
        private string lastName => "fakeLastName";
        private string firm => "fakeFirm";
        private string nullFirm => "";
    }
}
