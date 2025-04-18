namespace Agenda.Domain.Entities
{
    public class Contact : Base
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public int IdAgenda { get; private set; }
    }
}