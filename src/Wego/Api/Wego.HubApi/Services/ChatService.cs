
using Microsoft.EntityFrameworkCore;
using Wego.HubApi.Extensions;
using Wego.HubApi.Models;
using Wego.HubApi.Persistence;

namespace Wego.HubApi.Services
{
    public class ChatService : IChatService
    {

        private readonly PortoDbContext _dbContext;
        public ChatService(PortoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddUserConnectionId(int profielId, string connectionId)
        {
            var user = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.ProfileId == profielId);
            if (user != null)
            {
                user.ConnectionId = connectionId;
                _dbContext.Candidates.Update(user);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<string> GetConnectionIdByProfileId(int profileId)
        {
            var result = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.ProfileId == profileId);
            return result.ConnectionId;
        }

        public async Task SaveMesssage(ChatMessageModel message)
        {
            var param = message.MapTo<Message>();
            param.CreationDate = DateTime.UtcNow;
            param.Code = GetPrivateGroupName(message.ProfileFromId, message.ProfileToId);
            _dbContext.Messages.Add(param);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ChatMessageModel>> GetMessageByProfileId(int profileFromId, int profileToId)
        {
            var code = GetPrivateGroupName(profileFromId, profileToId);
            var result = await _dbContext.Messages.Where(x => x.Code == code).ToListAsync();

            return result.MapTo<List<ChatMessageModel>>();
        }

        public string GetPrivateGroupName(int profileFromId, int profileToId)
        {
            // from: john, to: david  "david-john"
            return profileFromId >= profileToId ? $"{profileFromId}-{profileToId}" : $"{profileToId}-{profileFromId}";
        }
    }
}
