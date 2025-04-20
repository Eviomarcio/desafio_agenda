namespace Agenda.Application.DTOs.ViewModel
{
    public class AgendaViewModel
    {
        public string Name { get; set; }
        public List<ContactViewModel>  Contacts { get; set; } = new List<ContactViewModel>();
        
        public AgendaViewModel(string name, List<ContactViewModel> contacts)
        {
            Name = name;
            Contacts = contacts;
        }
    }
}