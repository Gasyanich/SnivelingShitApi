using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnivelingShitApi.Services.VkMessageSender;

namespace SnivelingShitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VkMessageSendController : ControllerBase
    {
        private readonly IVkMessageSenderService _messageSenderService;

        public VkMessageSendController(IVkMessageSenderService messageSenderService)
        {
            _messageSenderService = messageSenderService;
        }

        [HttpGet]
        public async Task<ActionResult> SendMessage()
        {
            await _messageSenderService.SendMessageAsync();

            return Ok();
        }
    }
}