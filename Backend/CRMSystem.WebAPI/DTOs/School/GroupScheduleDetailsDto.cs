namespace CRMSystem.WebAPI.DTOs.School
{
    public class GroupScheduleDetailsDto
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public string Language { get; set; }
        public List<string> LessonDays { get; set; }
    }
}