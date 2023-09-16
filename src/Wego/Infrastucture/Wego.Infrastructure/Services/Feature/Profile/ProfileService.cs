﻿using Wego.Application.Contracts.Context;
using Wego.Application.Extensions;
using Wego.Application.Features.Profile.Commands;
using Wego.Application.IRepository;
using Wego.Application.IService.Feature.Profile;
using Wego.Application.Models.Profile;
using Wego.Domain.Profile;

namespace Wego.Infrastructure.Services.Feature.Profile;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly ICurrentContext _currentContext;
    public ProfileService(IProfileRepository profileRepository, ICurrentContext currentContext)
    {
        _profileRepository = profileRepository;
        _currentContext = currentContext;
    }
    public async Task<ImageProfileResponse> SaveImageAsync(ImageProfileModelCommand model, CancellationToken cancellationtoken = default)
    {
        var image = await _profileRepository.GetImageByProfileIdAsync(model.ProfileId, cancellationtoken);


        if (image is null)
        {
            var id = await _profileRepository.CreateImageAsync(model, cancellationtoken).ConfigureAwait(false);
            return new ImageProfileResponse(id, model.ContentType, model.Base64);
        }

         await _profileRepository.UpdateImageAsync(model, cancellationtoken).ConfigureAwait(false);
        
        return new ImageProfileResponse(image.Id, model.ContentType, model.Base64);
    }

    public async Task<ImageProfileResponse> GetImageByIdAsync(long fileId, CancellationToken cancellationtoken = default)
    {
        var result = await _profileRepository.GetImageByIdAsync(fileId, cancellationtoken).ConfigureAwait(false);
        return result;
    }

    public async Task<ProfileInfoResponse> GetProfileInfo(string suID, CancellationToken cancellationtoken = default)
    {

        ArgumentNullException.ThrowIfNull(suID);

        var result = await _profileRepository.GetProfileAsync(suID.Trim(), cancellationtoken).ConfigureAwait(false);


        if (result is not null && result.Email == _currentContext.Identity.Email && _currentContext.Identity.UserId == result.UserId)
        {
            return result.MapTo<ProfileInfoResponse>();
        }

        return await Task.FromResult<ProfileInfoResponse>(default);

    }

    public async Task<ProfileModel> GetProfileByEmailAsync(string email, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(email);
        return await _profileRepository.GetProfileByEmailAsync(email, cancellationtoken).ConfigureAwait(false);
    }

    public async Task<long> AddProfileInfoAsync(ProfileModel profile, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(profile);

        var existUSId = await _profileRepository.CheckProfileIfExistByUsIdAsync(profile.UsId, cancellationtoken);
        if (string.IsNullOrEmpty(existUSId)) { return await _profileRepository.AddProfileInfoAsync(profile, cancellationtoken).ConfigureAwait(false); }
        profile.SetUsId();

        return await _profileRepository.AddProfileInfoAsync(profile, cancellationtoken).ConfigureAwait(false);
    }

    public async Task<ProfileModel> GetProfileByUserIdAsync(string userId, CancellationToken cancellationtoken = default)
    {
        ArgumentNullException.ThrowIfNull(userId);
        return await _profileRepository.GetProfileByUserIdAsync(userId, cancellationtoken);
    }
}
