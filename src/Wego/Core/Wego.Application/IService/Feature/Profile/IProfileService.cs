﻿using Wego.Application.Features.Profile.Commands;
using Wego.Application.Models.Profile;
using Wego.Domain.Profile;

namespace Wego.Application.IService.Feature.Profile;

public interface IProfileService
{
    Task<ImageProfileResponse> SaveImageAsync(ImageProfileModelCommand model, CancellationToken cancellationtoken);
    Task<ImageProfileResponse> GetImageByIdAsync(long profileId, CancellationToken ct);
    Task<ProfileInfoResponse> GetProfileInfo(string suID, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken);
    Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken);
    Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken);
}
