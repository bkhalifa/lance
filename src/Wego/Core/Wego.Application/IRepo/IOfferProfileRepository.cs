using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wego.Domain.OfferProfile;

namespace Wego.Application.IRepo
{
    public interface IOfferProfileRepository
    {
        Task<IEnumerable<OfferFavoriteModel>> GetAllAsync(long profileId, CancellationToken cancellationToken = default);
        Task<int> AddOfferFavoriteAsync(long offerId, long profileId);
        Task<OfferFavoriteModel> GetOfferFavoriteAsync(long offerId, long profileId, CancellationToken cancellationToken = default);
        Task<int> DeleteOfferFavoriteAsync(long offerId, long profileId);
    }
}
