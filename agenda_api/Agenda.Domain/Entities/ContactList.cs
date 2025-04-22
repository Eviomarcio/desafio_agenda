namespace Agenda.Domain.Entities
{
    public class ContactList : Base
    {
        public string Name { get; private set; } = string.Empty;
        public IList<Contact> ListContact { get; private set; } = new List<Contact>();

        private ContactList() { }

        public ContactList(string name, IList<Contact> listContact)
        {
            Name = name;
            ListContact = listContact;
        }
    }
}