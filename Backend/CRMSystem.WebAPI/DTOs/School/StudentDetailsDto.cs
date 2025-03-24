namespace CRMSystem.WebAPI.DTOs.School
{
    public class StudentDetailsDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? ParentFullName { get; set; }
        public int? Grade { get; set; }
        public List<GroupInfoDto> Groups { get; set; }
        public List<ContractInfoDto> Contracts { get; set; }
    }
}