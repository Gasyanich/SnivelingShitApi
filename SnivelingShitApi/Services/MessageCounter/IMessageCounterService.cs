using System.Collections.Generic;
using System.Threading.Tasks;
using SnivelingShitApi.VkMessages;

namespace SnivelingShitApi.Services.MessageCounter
{
    public interface IMessageCounterService
    {
        Task<List<MessageCountInfo>> GetMessageCountInfosAsync(string message);
        Task<List<MessageCountInfo>> GetDefaultMessageCountInfosAsync();
    }
}