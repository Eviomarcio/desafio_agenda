namespace Agenda.Application.DTOs.ViewModel
{
    public class ContactListViewModel
    {
        public string Name { get; set; }
        public List<ContactViewModel>  Contacts { get; set; } = new List<ContactViewModel>();

        public ContactListViewModel(string name, List<ContactViewModel> contacts)
        {
            Name = name;
            Contacts = contacts;
        }
    }
}