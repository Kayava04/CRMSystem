namespace CRMSystem.WebAPI.DTOs.School
{
    public class GroupInfoDto
    {
        public string GroupName { get; set; }
        public string Language { get; set; }
        public int Level { get; set; }
        public int PairNumber { get; set; }
        public List<string> LessonDays { get; set; }
    }
}