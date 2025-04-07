using CRMSystem.WebAPI.Models;

namespace CRMSystem.WebAPI.Interfaces
{
    public interface IEmailRepository
    {
        Task<Message> AddAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesByReceiverIdAsync(Guid receiverId);
    }
}