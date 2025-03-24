namespace CRMSystem.WebAPI.Models
{
    public class Student
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }
        public Guid? ParentId { get; private set; }
        public int? Grade { get; private set; }

        private Student(Guid id, Guid personId, Guid? parentId, int? grade)
        {
            Id = id;
            PersonId = personId;
            ParentId = parentId;
            Grade = grade;
        }

        public static Student Create(Guid id, Guid personId, Guid? parentId, int? grade) =>
            new(id, personId, parentId, grade);
    }
}