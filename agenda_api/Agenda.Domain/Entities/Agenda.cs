namespace Agenda.Domain.Entities
{
    public class Agenda : Base
    {
        public string Name { get; private set; } = string.Empty;
        public IList<Contact> ListContect { get; private set; }
    }
}