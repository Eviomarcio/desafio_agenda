namespace Agenda.Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string entityName, object key)
            : base($"{entityName} com identificador '{key}' não foi encontrado.")
        {
        }
    }
}