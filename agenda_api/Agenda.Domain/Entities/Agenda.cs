namespace Agenda.Domain.Entities
{
    public class Agenda : Base
    {
        public string Name { get; private set; } = string.Empty;
        public IList<Contact> ListContact { get; private set; } = new List<Contact>();

        public Agenda(string name, IList<Contact> listContact)
        {
            Name = name;
            ListContact = listContact;
        }
    }
}