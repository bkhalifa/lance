namespace Wego.Application.Features.Chat.Queries
{

    public record GetChatMessageListQuery(long profileFromId, long profileToId) : IRequest<List<GetChatMessageModel>>;

    public class GetChatMessageListQueryHandler : IRequestHandler<GetChatMessageListQuery, List<GetChatMessageModel>>
    {
        private readonly IBaseRepository<Message> _messageRepository;

        public GetChatMessageListQueryHandler(IBaseRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<GetChatMessageModel>> Handle(GetChatMessageListQuery request, CancellationToken cancellationToken)
        {
            var code = request.profileFromId >= request.profileToId ? $"{request.profileFromId}-{request.profileToId}" : $"{request.profileToId}-{request.profileFromId}";
            var result = await _messageRepository.FindAsync(x => x.Code == code);

            return result.MapTo<List<GetChatMessageModel>>();
        }
    }
}
