using MediatR;
using Wego.Application.Contracts.Persistence;
using Wego.Application.Extensions;
using Wego.Domain.Entities;

namespace Wego.Application.Features.Chat.Queries
{

    public record GetChatUserListQuery() : IRequest<List<GetChatUserModel>>;

    public class GetCategoriesListQueryHandler : IRequestHandler<GetChatUserListQuery, List<GetChatUserModel>>
    {
        private readonly IBaseRepository<Candidate> _candidateRepository;


        public GetCategoriesListQueryHandler(IBaseRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<List<GetChatUserModel>> Handle(GetChatUserListQuery request, CancellationToken cancellationToken)
        {
            var result = await _candidateRepository.GetAllAsync(cancellationToken: cancellationToken);
            return result.MapTo<List<GetChatUserModel>>();
        }
    }
}
