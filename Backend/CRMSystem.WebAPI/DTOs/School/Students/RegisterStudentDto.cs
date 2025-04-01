namespace CRMSystem.WebAPI.DTOs.School.Students
{
    public class RegisterStudentDto
    {
        public bool IsParentRegister { get; set; }
        public string ParentFullName { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Grade { get; set; }
        public string ContractNumber { get; set; }
        public DateTime SignDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LanguageName { get; set; }
        public string GroupName { get; set; }
        public List<string> LessonDays { get; set; } = [];
        public string Level { get; set; }
        public int PairNumber { get; set; }
    }
}