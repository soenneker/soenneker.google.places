[![](https://img.shields.io/nuget/v/soenneker.google.places.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.places/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.places/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.google.places/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.google.places.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.places/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.places/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.google.places/actions/workflows/codeql.yml)

# Soenneker.Google.Places

A DI-ready wrapper for Google Places Find Place and Place Details requests.

## Install

```bash
dotnet add package Soenneker.Google.Places
```

## Configuration

```json
{
  "Google": {
    "Places": {
      "ApiKey": "<Google Places API key>"
    }
  }
}
```

## Register

```csharp
using Soenneker.Google.Places.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddGooglePlacesUtilAsScoped();
```

Singleton registration is also available through `AddGooglePlacesUtilAsSingleton()`; the implementation is stateless after reading its API key.

## Find a place and load details

```csharp
PlaceResult? candidate = await places.GetPlace(
    "1600 Amphitheatre Parkway, Mountain View, CA",
    cancellationToken: cancellationToken);

if (candidate?.PlaceId is { } placeId)
{
    PlaceResult? details = await places.GetDetails(
        placeId,
        cancellationToken: cancellationToken);
}
```

Name, geometry, and place ID are always requested. Supply `additionalFieldTypes` when the response must include other billable fields.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `GetPlaces(address, additionalFieldTypes)` | Runs a text Find Place request. | Returns candidates in response order, or an empty list for no match. |
| `GetPlace(address, additionalFieldTypes)` | Returns the first Find Place candidate. | `null` for no match; it is not an exact-match guarantee. |
| `GetPlaceId(address)` | Returns the first candidate's place ID. | `null` for no match. |
| `GetDetails(placeId, additionalFieldTypes)` | Loads details for an existing place ID. | `null` when Google reports that the place was not found. |

## Practical notes

- Quota, authentication, permission, invalid-request, and other non-success statuses throw `InvalidOperationException`; they are not reported as empty results.
- Transport failures propagate from the underlying Google API client, and cancellation is forwarded to each request.
