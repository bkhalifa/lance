using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wego.Domain.Common;
using Wego.Domain.Offers;

namespace Wego.Application.IRepo
{
    public interface IOfferRepository
    {
        Task<IEnumerable<OfferSearchModel>> GetOffersByFilterAsync(OfferFilterParam filter, CancellationToken cancellationToken = default);
        Task<OfferModel> GetOffersByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
