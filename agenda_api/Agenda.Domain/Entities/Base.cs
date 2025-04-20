namespace Agenda.Domain.Entities
{
    public class Base
    {
        public int Id { get; private set; }
        protected Base() { }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}