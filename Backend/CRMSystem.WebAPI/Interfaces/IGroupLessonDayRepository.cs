using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Interfaces
{
    public interface IGroupLessonDayRepository
    {
        Task<IEnumerable<GroupLessonDay>> GetAllAsync();
        Task<GroupLessonDay?> GetByIdsAsync(Guid groupId, Guid lessonDayId);
        Task<GroupLessonDay> AddAsync(GroupLessonDay entity);
        Task DeleteAsync(Guid groupId, Guid lessonDayId);
    }
}