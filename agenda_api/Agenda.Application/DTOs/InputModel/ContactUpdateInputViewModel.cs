namespace Agenda.Application.DTOs.InputModel
{
    public class ContactUpdateInputViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int IdAgenda { get; set; }

        public ContactUpdateInputViewModel(int id, string name, string email, string phone, int idAgenda)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            IdAgenda = idAgenda;
        }
    }
}