using System.Threading.Tasks;

namespace SnivelingShitApi.Services.VkMessageSender
{
    public interface IVkMessageSenderService
    {
        Task SendMessageAsync();
    }
}