using GoogleApi.Entities.Places.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;

namespace Soenneker.Google.Places.Abstract;

/// <summary>
/// Provides Find Place and Place Details lookups through the Google Places API.
/// </summary>
public interface IGooglePlacesUtil
{
    /// <summary>
    /// Gets details for a place ID.
    /// </summary>
    /// <param name="placeId">Identifier of the place to target.</param>
    /// <param name="additionalFieldTypes">Optional fields to request in addition to name, geometry, and place ID.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The place details, or <see langword="null"/> when Google reports no matching place.</returns>
    ValueTask<PlaceResult?> GetDetails(string placeId, GoogleApi.Entities.Places.Details.Request.Enums.FieldTypes? additionalFieldTypes = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of place results matching the specified address.
    /// </summary>
    /// <param name="address">The address to search for places.</param>
    /// <param name="additionalFieldTypes">Optional fields to request in addition to name, geometry, and place ID.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The candidates in Google response order, or an empty list when no place matches.</returns>
    ValueTask<List<PlaceResult>> GetPlaces(string address, FieldTypes? additionalFieldTypes = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a single place result matching the specified address.
    /// </summary>
    /// <param name="address">The address to search for the place.</param>
    /// <param name="additionalFieldTypes">Optional fields to request in addition to name, geometry, and place ID.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>A <see cref="PlaceResult"/> object matching the address, or null if no place is found.</returns>
    ValueTask<PlaceResult?> GetPlace(string address, FieldTypes? additionalFieldTypes = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the place ID for a given address.
    /// </summary>
    /// <param name="address">The address to search for the place ID.</param>
    /// <param name="cancellationToken">Token used to cancel the request.</param>
    /// <returns>The place ID as a string, or null if no place ID is found.</returns>
    ValueTask<string?> GetPlaceId(string address, CancellationToken cancellationToken = default);
}
