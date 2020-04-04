using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SnivelingShitApi.Services.VkApiCreator;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model.RequestParams;

namespace SnivelingShitApi.Services.VkMessageSender
{
    public class VkMessageSenderService : IVkMessageSenderService
    {
        private readonly VkApi _api;
        private const long MyId = 38303320;
        private const long YouId = 52743297;

        private readonly string[] _messages =
        {
            "Обнимаю!",
            "Целую!",
            "Почти люблю"
        };

        public VkMessageSenderService(IVkApiCreatorService vkApiCreatorService)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAudioBypass();

            _api = vkApiCreatorService.GetVkApi();
        }

        public async Task SendMessageAsync()
        {
            var rnd = new Random();
            var rndMessage = _messages[rnd.Next(_messages.Length)];
            await _api.Messages.SendAsync(new MessagesSendParams
                {UserId = YouId, Message = rndMessage, RandomId = rnd.Next(int.MaxValue - 1)});
        }
    }
}