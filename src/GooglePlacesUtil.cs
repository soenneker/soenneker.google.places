using System.Collections.Generic;
using System.Linq;
using Soenneker.Google.Places.Abstract;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using GoogleApi.Entities.Places.Search.Find.Response;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.Task;
using System.Threading;
using Soenneker.Extensions.ValueTask;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;

namespace Soenneker.Google.Places;

/// <inheritdoc cref="IGooglePlacesUtil"/>
public class GooglePlacesUtil : IGooglePlacesUtil
{
    private readonly string _apiKey;

    public GooglePlacesUtil(IConfiguration config)
    {
        _apiKey = config.GetValueStrict<string>("Google:Places:ApiKey");
    }

    public async ValueTask<PlaceResult?> GetDetails(string placeId, CancellationToken cancellationToken = default)
    {
        var request = new PlacesDetailsRequest
        {
            PlaceId = placeId,
            Key = _apiKey,
            Fields = GoogleApi.Entities.Places.Details.Request.Enums.FieldTypes.Name
        };

        PlacesDetailsResponse? response = await GooglePlaces.Details.QueryAsync(request, cancellationToken).NoSync();

        if (response is not {Status: Status.Ok})
            return null;

        return response.Result;
    }

    public async ValueTask<List<PlaceResult>?> GetPlaces(string address, CancellationToken cancellationToken = default)
    {
        var request = new PlacesFindSearchRequest
        {
            Key = _apiKey,
            Input = address,
            Type = InputType.TextQuery
        };

        PlacesFindSearchResponse? response = await GooglePlaces.Search.FindSearch.QueryAsync(request, cancellationToken).NoSync();

        if (response is not {Status: Status.Ok})
            return null;

        List<PlaceResult> places = response.Candidates.ToList();

        return places;
    }

    public async ValueTask<PlaceResult?> GetPlace(string address, CancellationToken cancellationToken = default)
    {
        List<PlaceResult>? places = await GetPlaces(address, cancellationToken).NoSync();

        return places?.FirstOrDefault();
    }

    public async ValueTask<string?> GetPlaceId(string address, CancellationToken cancellationToken = default)
    {
        PlaceResult? place = await GetPlace(address, cancellationToken).NoSync();

        return place?.PlaceId;
    }
}