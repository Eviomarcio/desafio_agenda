namespace Agenda.Application.DTOs.InputModel
{
    public class ContactListInputModel
    {
        public string Name { get; set; } = string.Empty;
        
        public ContactListInputModel(string name)
        {
            Name = name;
        }
    }
}