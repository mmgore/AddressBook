namespace Contact.Domain.Exceptions
{
    public class ContactDomainException : Exception
    {
        public ContactDomainException()
        {
        }
        public ContactDomainException(string message): base(message)
        {
        }
        public ContactDomainException(string message, Exception exception): base(message, exception)
        {
        }
    }
}
