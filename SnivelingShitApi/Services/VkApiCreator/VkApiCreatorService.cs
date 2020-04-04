using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace SnivelingShitApi.Services.VkApiCreator
{
    public class VkApiCreatorService : IVkApiCreatorService
    {
        private readonly string _login;
        private readonly string _password;

        public VkApiCreatorService(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public VkApi GetVkApi()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAudioBypass();

            var api = new VkApi(serviceCollection);

            api.Authorize(new ApiAuthParams {Settings = Settings.All, Login = _login, Password = _password});

            return api;
        }
    }
}