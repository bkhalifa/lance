using System;
using Wego.HubApi.Models;

namespace Wego.HubApi.Services
{
    public interface IChatService
    {
        Task AddUserConnectionId(int profielId, string connectionId);
        Task<string> GetConnectionIdByProfileId(int profileId);
        Task SaveMesssage(ChatMessageModel message);
        string GetPrivateGroupName(int profileFromId, int profileToId);
        Task<List<ChatMessageModel>> GetMessageByProfileId(int profileFromId, int profileToId);
    }
}
