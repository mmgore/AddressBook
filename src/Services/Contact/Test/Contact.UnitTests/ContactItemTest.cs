using AutoMapper;
using Contact.Application.Automapper;
using Contact.Application.Commands.CreateContact;
using Contact.Application.Commands.CreateContactInfo;
using Contact.Application.Commands.DeleteContact;
using Contact.Application.Commands.UpdateContact;
using Contact.Application.Exceptions;
using Contact.Application.Queries.GetContactById;
using Contact.Application.Validations;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.Exceptions;
using Contact.Domain.SeedWork;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Contact.UnitTests
{
    public class ContactItemTest
    {
        private readonly Mock<IContactItemRepository> _contactItemRepositoryMock;
        private readonly Mock<IContactInformationRepository> _contactInformationRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;

        public ContactItemTest()
        {
            _contactItemRepositoryMock = new Mock<IContactItemRepository>();
            _contactInformationRepositoryMock = new Mock<IContactInformationRepository>();
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

        [Theory]
        [InlineData("", false)]
        [InlineData("fakeName", true)]
        public void Validate_create_contact_command(string name, bool expected)
        {
            CreateContactCommandValidator validator = new CreateContactCommandValidator();

            var fakeContact = fakeContactItem;
            var cmd = new CreateContactCommand() { FirstName = name, LastName = fakeContact.LastName, Firm = fakeContact.Firm, PhoneNumber = fakeContactInfo.PhoneNumber, EmailAddress = fakeContactInfo.EmailAddress, Location = fakeContactInfo.Location, Content = fakeContactInfo.Content };

            var sut = validator.Validate(cmd);
            sut.IsValid.Should().Be(expected);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("fakeNumber", true)]
        public void Validate_create_contact_info_command(string phoneNumber, bool expected)
        {
            CreateContactInfoCommandValidator validator = new CreateContactInfoCommandValidator();

            var fakeContactInformation = fakeContactInfo;
            var cmd = new CreateContactInfoCommand() { PhoneNumber = phoneNumber, EmailAddress = fakeContactInformation.EmailAddress, Location = fakeContactInformation.Location, Content = fakeContactInformation.Content };

            var sut = validator.Validate(cmd);
            sut.IsValid.Should().Be(expected);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("fakeName", true)]
        public void Validate_update_contact_command(string name, bool expected)
        {
            UpdateContactCommandValidator validator = new UpdateContactCommandValidator();

            var fakeContact = fakeContactItem;
            var cmd = new UpdateContactCommand() { FirstName = name, LastName = fakeContact.LastName, Firm = fakeContact.Firm};

            var sut = validator.Validate(cmd);
            sut.IsValid.Should().Be(expected);
        }

        [Fact]
        public async void Should_update_contact_successful()
        {
            var fakeContact = fakeContactItem;
            var fakeFirm = "newFirm";

            var logger = new Mock<ILogger<UpdateContactCommandHandler>>();

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(fakeContact.Id))
                .ReturnsAsync(fakeContact);

            _contactItemRepositoryMock.Setup(r => r.UpdateAsync(fakeContact));

            var cmd = new UpdateContactCommand() { Id = fakeContact.Id, FirstName = fakeContact.FirstName, LastName = fakeContact.LastName, Firm = fakeFirm };

            var handler = new UpdateContactCommandHandler(_contactItemRepositoryMock.Object, _unitOfWorkMock.Object, logger.Object, _mapper);

            var sut = await handler.Handle(cmd, CancellationToken.None);

            sut.Should().Be(Unit.Value);
            fakeContact.Firm.Should().Be(fakeFirm);
        }

        [Fact]
        public async void Should_get_contat_by_id_successful()
        {
            var fakeContact = fakeContactItem;

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
            var fakeContact = fakeContactItem;

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(It.IsAny<Guid>()))
                .ReturnsAsync((ContactItem)null);

            var cmd = new GetContactByIdQuery() { ContactItemId = fakeContact.Id };

            var handler = new GetContactByIdQueryHandler(_contactItemRepositoryMock.Object, _mapper);

            Func<Task> sut = async () => await handler.Handle(cmd, CancellationToken.None);

            sut.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async void Should_create_contact_successful()
        {
            var fakeContact = fakeContactItem;

            _contactItemRepositoryMock.Setup(r => r.InsertAsync(fakeContact));
            _contactInformationRepositoryMock.Setup(r => r.InsertAsync(fakeContactInfo));
            var logger = new Mock<ILogger<CreateContactCommandHandler>>();

            var cmd = new CreateContactCommand() { FirstName = fakeContact.FirstName, LastName = fakeContact.LastName, Firm = fakeContact.Firm, PhoneNumber = fakeContactInfo.PhoneNumber, EmailAddress = fakeContactInfo.EmailAddress, Location = fakeContactInfo.Location, Content = fakeContactInfo.Content };

            var handler = new CreateContactCommandHandler(_contactItemRepositoryMock.Object, _contactInformationRepositoryMock.Object, _unitOfWorkMock.Object, logger.Object);

            var sut = await handler.Handle(cmd, CancellationToken.None);

            sut.Should().Be(Unit.Value);
        }
        [Fact]
        public async void Should_delete_contact_item_successful()
        {
            var fakeContact = fakeContactItem;

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(fakeContact.Id))
               .ReturnsAsync(fakeContact);

            _contactItemRepositoryMock.Setup(r => r.DeleteAsync(fakeContact));

            var cmd = new DeleteContactCommand(fakeContact.Id);
            var handler = new DeleteContactCommandHandler(_contactItemRepositoryMock.Object, _unitOfWorkMock.Object);

            var sut = await handler.Handle(cmd, CancellationToken.None);

            sut.Should().Be(Unit.Value);
        }
        [Fact]
        public async void Should_delete_contact_item_throw_exception()
        {
            var fakeContact = fakeContactItem;

            _contactItemRepositoryMock.Setup(r => r.GetContactItemById(fakeContact.Id))
               .ReturnsAsync((ContactItem)null);

            var cmd = new DeleteContactCommand(fakeContact.Id);
            var handler = new DeleteContactCommandHandler(_contactItemRepositoryMock.Object, _unitOfWorkMock.Object);

            Func<Task> sut = async () => await handler.Handle(cmd, CancellationToken.None);

            sut.Should().ThrowAsync<NotFoundException>();
        }
        
        private ContactItem fakeContactItem => ContactItem.Create(firsName, lastName, firm);
        private ContactInformation fakeContactInfo => ContactInformation.Create(fakeContactItem.Id, phoneNumber, email, location, content);
        private string firsName => "fakeName";
        private string lastName => "fakeLastName";
        private string firm => "fakeFirm";
        private string phoneNumber => "fakeNumber";
        private string email => "fakeMail";
        private string location => "fakeLocation";
        private string content => "fakeContent";
        private string nullFirm => "";
    }
}
