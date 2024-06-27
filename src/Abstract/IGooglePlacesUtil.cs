using GoogleApi.Entities.Places.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Google.Places.Abstract;

/// <summary>
/// A utility library for Google Places API operations
/// </summary>
public interface IGooglePlacesUtil
{
    ValueTask<PlaceResult?> GetDetails(string placeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of place results matching the specified address.
    /// </summary>
    /// <param name="address">The address to search for places.</param>
    /// <param name="cancellationToken">Optional. A cancellation token to cancel the operation.</param>
    /// <returns>A list of <see cref="PlaceResult"/> objects matching the address, or null if no places are found.</returns>
    ValueTask<List<PlaceResult>?> GetPlaces(string address, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a single place result matching the specified address.
    /// </summary>
    /// <param name="address">The address to search for the place.</param>
    /// <param name="cancellationToken">Optional. A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="PlaceResult"/> object matching the address, or null if no place is found.</returns>
    ValueTask<PlaceResult?> GetPlace(string address, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the place ID for a given address.
    /// </summary>
    /// <param name="address">The address to search for the place ID.</param>
    /// <param name="cancellationToken">Optional. A cancellation token to cancel the operation.</param>
    /// <returns>The place ID as a string, or null if no place ID is found.</returns>
    ValueTask<string?> GetPlaceId(string address, CancellationToken cancellationToken = default);
}