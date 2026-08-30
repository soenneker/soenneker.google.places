using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.Places.Abstract;

namespace Soenneker.Google.Places.Registrars;

/// <summary>
/// Registers the Google Places lookup utility.
/// </summary>
public static class GooglePlacesUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGooglePlacesUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGooglePlacesUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IGooglePlacesUtil, GooglePlacesUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IGooglePlacesUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGooglePlacesUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IGooglePlacesUtil, GooglePlacesUtil>();
        return services;
    }
}
