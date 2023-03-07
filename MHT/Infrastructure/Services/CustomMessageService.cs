using Microsoft.Graph;
using MHT.Infrastructure.Interfaces;
using MHT.Common.Constants;

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
                            Content = TextStrings.Teams.TEAMS_MESSAGE_CONTENT
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
                    Subject = TextStrings.Mail.MAIL_SUBJECT,
                    Body = new ItemBody
                    {
                        // TODO: Here should use some CONSTS //
                        Content = TextStrings.Mail.MAIL_CONTENT,
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
