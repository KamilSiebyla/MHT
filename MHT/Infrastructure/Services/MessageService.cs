using Microsoft.Graph;
using MHT.Infrastructure.Interfaces;

namespace MHT.Infrastructure.Services
{
    public class CustomMessageService : ICustomMessageService
    {
        private readonly GraphServiceClient _graphClient;

        public CustomMessageService(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }

        public async Task SendTeamsMessageAsync(User coworker)
        {
            if (_graphClient == null) return;

            try
            {
                var userChats = await _graphClient
                    .Me
                    .Chats
                    .Request()
                    .Expand("members")
                    .Select(c => new
                    {
                        c.Id,
                        c.Topic,
                        c.ChatType,
                        c.LastUpdatedDateTime,
                        c.Members
                    })
                    .GetAsync();

                var chat = userChats.Any() ? userChats.FirstOrDefault(
                    c => c.Members.Any(
                        u => u.DisplayName == coworker.DisplayName)) : null;

                if (chat != null)
                {
                    var message = new ChatMessage
                    {
                        Body = new ItemBody
                        {
                            // TODO: Need to place it in the CONSTS //
                            Content = "Hello, do you have a minute by chance?"
                        }
                    };

                    await _graphClient.Me.Chats[chat.Id]
                                .Messages
                                .Request()
                                .AddAsync(message);
                }
            }
            catch(Exception exception)
            {
                throw new Exception($"Exception when sending teams message: { exception.Message }");
            }
        }

        public async Task SendOutlookMessageAsync(User coworker)
        {
            if (_graphClient == null) return;

            try
            {
                var message = new Message
                {
                    ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = coworker.Mail
                        }
                    }
                },
                    // TODO: Here should use some CONSTS //
                    Subject = "Quick thing to discuss.",
                    Body = new ItemBody
                    {
                        // TODO: Here should use some CONSTS //
                        Content = "Hello, do you have a minute? I would be glad.",
                        ContentType = BodyType.Html
                    },
                };

                await _graphClient
                    .Me
                    .SendMail(message, true)
                    .Request()
                    .PostAsync();
            }
            catch(Exception exception)
            {
                throw new Exception($"Exception when sending outlook message: {exception.Message}");
            }
        }
    }
}
