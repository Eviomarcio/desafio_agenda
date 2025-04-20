namespace Agenda.Application.DTOs.InputModel
{
    public class AgendaInputModel
    {
        public string Name { get; set; } = string.Empty;
        
        public AgendaInputModel(string name)
        {
            Name = name;
        }
    }
}