using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnivelingShitApi.Services.VkApiCreator;
using SnivelingShitApi.VkMessages;
using VkNet;
using VkNet.Model.RequestParams;

namespace SnivelingShitApi.Services.MessageCounter
{
    public class MessageCounterService : IMessageCounterService
    {
        private readonly VkApi _api;
        private const long MyId = 38303320;

        private readonly string[] _defaultMessages =
        {
            "Почти люблю",
            "Обнимаю",
            "Целую",
            "Выходи за меня",
        };

        public MessageCounterService(IVkApiCreatorService vkApiCreatorService)
        {
            _api = vkApiCreatorService.GetVkApi();
        }

        public async Task<List<MessageCountInfo>> GetDefaultMessageCountInfosAsync()
        {
            var defaultMessageCountInfos = new List<MessageCountInfo>();

            foreach (var defaultMessage in _defaultMessages)
            {
                var msgi = await GetMessageCountInfosAsync(defaultMessage);
                defaultMessageCountInfos.AddRange(msgi);
            }

            return defaultMessageCountInfos;
        }

        public async Task<List<MessageCountInfo>> GetMessageCountInfosAsync(string message)
        {
            uint offset = 0;
            var isMessagesEnd = false;

            var messageCountInfos = new List<MessageCountInfo>();

            while (!isMessagesEnd)
            {
                var searchResult = await _api.Messages.SearchAsync(new MessagesSearchParams
                {
                    PeerId = 52743297,
                    Count = 100,
                    Query = message,
                    Offset = offset
                });

                var messages = searchResult.Items
                    .Where(msg => msg.Text.Contains(message, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (!messages.Any())
                    break;

                var newOffset = uint.Parse(messages.Last().ConversationMessageId.ToString());

                if (offset == newOffset)
                    break;

                offset = newOffset;

                messageCountInfos.AddRange(messages
                    .GroupBy(msg => msg.FromId)
                    .Select(msg => new MessageCountInfo
                        {Author = msg.Key == MyId ? "I" : "A", Count = msg.Count(), Message = message}));

                await Task.Delay(TimeSpan.FromSeconds(2.5));
            }

            return messageCountInfos.OrderBy(info => info.Author).ToList();
        }
    }
}