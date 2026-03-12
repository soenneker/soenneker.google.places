using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.Places.Abstract;

namespace Soenneker.Google.Places.Registrars;

/// <summary>
/// A utility library for Google Places API operations
/// </summary>
public static class GooglePlacesUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGooglePlacesUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGooglePlacesUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IGooglePlacesUtil, GooglePlacesUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IGooglePlacesUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGooglePlacesUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IGooglePlacesUtil, GooglePlacesUtil>();
        return services;
    }
}