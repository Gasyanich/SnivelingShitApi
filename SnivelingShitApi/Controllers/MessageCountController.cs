using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnivelingShitApi.Services.MessageCounter;
using SnivelingShitApi.VkMessages;

namespace SnivelingShitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCountController : ControllerBase
    {
        private readonly IMessageCounterService _messageCountService;

        public MessageCountController(IMessageCounterService messageCountService)
        {
            _messageCountService = messageCountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MessageCountInfo>>> GetMessageCount(ReqMessage message)
        {
            return await _messageCountService.GetMessageCountInfosAsync(message.Message);
        }

        [HttpGet("defaultMessages")]
        public async Task<ActionResult<List<MessageCountInfo>>> GetDefaultMessagesCount()
        {
            return await _messageCountService.GetDefaultMessageCountInfosAsync();
        }
    }
}