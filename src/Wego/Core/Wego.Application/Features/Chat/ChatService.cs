
using Wego.Application.Contracts.Common;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Exceptions;
using Wego.Application.Extensions;
using Wego.Application.Models.Chat;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Chat
{
    public class ChatService : IChatService
    {

        private readonly IBaseRepository<Candidate> _candidateRepository;
        private readonly IBaseRepository<Message> _messageRepository;
        public ChatService(IBaseRepository<Candidate> candidateRepository, IBaseRepository<Message> messageRepository)
        {
            _candidateRepository = candidateRepository;
            _messageRepository= messageRepository;
        }


        public async Task AddUserConnectionId(int profielId, string connectionId)
        {
            var user = await _candidateRepository.FirstOrDefaultAsync(x => x.ProfileId == profielId);
            if (user == null) throw new UserNotFoundException(profielId.ToString());

            user.ConnectionId = connectionId;
            await _candidateRepository.UpdateAsync(user);

        }

        public async Task<string> GetConnectionIdByProfileId(int profileId)
        {
            var result = await _candidateRepository.FirstOrDefaultAsync(x=> x.ProfileId == profileId);
            return result.ConnectionId;
        }

        public async Task SaveMesssage(MessageModel message)      
        {
            var param = message.MapTo<Message>();
            param.CreationDate = DateTime.UtcNow;
            param.Code = GetPrivateGroupName(message.ProfileFromId, message.ProfileToId);
            await _messageRepository.AddAsync(param);
        }


        public async Task<List<CandidateModel>> GetOnlineUsers()
        {
            var result = await _candidateRepository.GetAllAsync();

            return result.MapTo<List<CandidateModel>>();
        }

        public async Task<List<MessageModel>> GetMessageByProfileId(int profileFromId, int profileToId)
        {
            var code = GetPrivateGroupName(profileFromId, profileToId);
            var result = await _messageRepository.FindAsync(x=> x.Code == code);

            return result.MapTo<List<MessageModel>>();
        }

        public string GetPrivateGroupName(int profileFromId, int profileToId)
        {
            // from: john, to: david  "david-john"
            return profileFromId >= profileToId ? $"{profileFromId}-{profileToId}" : $"{profileToId}-{profileFromId}";
        }
    }
}
