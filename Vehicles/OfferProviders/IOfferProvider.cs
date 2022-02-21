using System.Collections.Generic;

namespace Vehicles.OfferProviders;

public interface IOfferProvider : IEnumerable<decimal>
{
    decimal GetOffer();
}
