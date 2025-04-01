using CRMSystem.WebAPI.DTOs.School.Contacts;
using CRMSystem.WebAPI.DTOs.School.Contracts;
using CRMSystem.WebAPI.DTOs.School.Groups;
using CRMSystem.WebAPI.DTOs.School.Languages;
using CRMSystem.WebAPI.DTOs.School.LessonDays;
using CRMSystem.WebAPI.DTOs.School.Persons;
using CRMSystem.WebAPI.DTOs.School.StudentGroups;

namespace CRMSystem.WebAPI.DTOs.School.Students
{
    public class RegisterStudentResultDto
    {
        public PersonDto Parent { get; set; }
        public PersonDto Person { get; set; }
        public StudentDto Student { get; set; }
        public ContractDto Contract { get; set; }
        public ContactDto Contact { get; set; }
        public StudentGroupDto StudentGroup { get; set; }
        public GroupDto Group { get; set; }
        public LanguageDto Language { get; set; }
        public List<LessonDayDto> LessonDays { get; set; } = [];
    }
}