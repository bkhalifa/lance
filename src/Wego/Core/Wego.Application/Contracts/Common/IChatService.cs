using System;
using Wego.Application.Models.Chat;


namespace Wego.Application.Contracts.Common
{
  public interface IChatService
    {
        Task AddUserConnectionId(int profielId, string connectionId);
        Task<string> GetConnectionIdByProfileId(int profileId);
        Task<List<CandidateModel>> GetOnlineUsers();
        Task SaveMesssage(MessageModel message);
        string GetPrivateGroupName(int profileFromId, int profileToId);
        Task<List<MessageModel>> GetMessageByProfileId(int profileFromId, int profileToId);
    }
}
