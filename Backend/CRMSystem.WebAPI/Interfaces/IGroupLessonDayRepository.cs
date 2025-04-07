using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Interfaces
{
    public interface IGroupLessonDayRepository
    {
        Task<GroupLessonDay?> GetByIdAsync(Guid groupId, Guid lessonDayId);
        Task<IEnumerable<GroupLessonDay>> GetAllAsync();
        Task<GroupLessonDay> AddAsync(GroupLessonDay entity);
        Task DeleteAsync(Guid groupId, Guid lessonDayId);
    }
}