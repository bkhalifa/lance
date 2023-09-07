using Wego.Application.IRepository;

namespace Wego.Application.Features.Profile.Queries;


public record GetProfileInfoQuery(long pid);

public class GetProfileInfoQueryHandler
{
    private readonly IProfileRepository _profileRepository;
    public GetProfileInfoQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

}

