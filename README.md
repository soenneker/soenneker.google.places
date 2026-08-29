[![](https://img.shields.io/nuget/v/soenneker.google.places.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.places/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.places/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.google.places/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.google.places.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.places/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.places/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.google.places/actions/workflows/codeql.yml)

# Soenneker.Google.Places

A utility library for Google Places API operations.

## Install

```bash
dotnet add package Soenneker.Google.Places
```

## Quick start

```csharp
using Soenneker.Google.Places.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddGooglePlacesUtilAsSingleton();
```

Adds `IGooglePlacesUtil` as a singleton service.

## What you get

- `IGooglePlacesUtil` — A utility library for Google Places API operations.
- `GooglePlacesUtilRegistrar` — A utility library for Google Places API operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IGooglePlacesUtil.GetPlaces(address, additionalFieldTypes, cancellationToken)` | Retrieves a list of place results matching the specified address. | A list of `PlaceResult` objects matching the address, or null if no places are found. |
| `IGooglePlacesUtil.GetPlace(address, additionalFieldTypes, cancellationToken)` | Retrieves a single place result matching the specified address. | A `PlaceResult` object matching the address, or null if no place is found. |
| `IGooglePlacesUtil.GetPlaceId(address, cancellationToken)` | Retrieves the place ID for a given address. | The place ID as a string, or null if no place ID is found. |
| `GooglePlacesUtilRegistrar.AddGooglePlacesUtilAsSingleton(services)` | Adds `IGooglePlacesUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `GooglePlacesUtilRegistrar.AddGooglePlacesUtilAsScoped(services)` | Adds `IGooglePlacesUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
