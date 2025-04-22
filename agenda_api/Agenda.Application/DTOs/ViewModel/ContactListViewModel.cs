namespace Agenda.Application.DTOs.ViewModel
{
    public class ContactListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ContactViewModel> Contacts { get; set; } = new List<ContactViewModel>();

        public ContactListViewModel(int id, string name, List<ContactViewModel> contacts) 
        : this(name, contacts)
        {
            Id = id;
        }

        public ContactListViewModel(string name, List<ContactViewModel> contacts)
        {
            Name = name;
            Contacts = contacts;
        }
    }
}