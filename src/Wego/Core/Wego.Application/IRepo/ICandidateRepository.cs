﻿using Wego.Domain.OfferProfile;
using Wego.Domain.Profile;

namespace Wego.Application.IRepo
{
    public interface ICandidateRepository
    {
        Task<int> AddAsync(CandidateModel candidate, CancellationToken cancellationToken);
        Task<int> SetConnected(long profileId, bool isConnected, CancellationToken cancellationToken);
    }
}
