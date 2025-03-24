namespace CRMSystem.WebAPI.Models
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }
        public string Position { get; private set; }

        private Employee(Guid id, Guid personId, string position)
        {
            Id = id;
            PersonId = personId;
            Position = position;
        }

        public static Employee Create(Guid id, Guid personId, string position) =>
            new(id, personId, position);
    }
}