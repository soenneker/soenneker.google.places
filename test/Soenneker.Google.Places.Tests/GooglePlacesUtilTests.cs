using System.Threading.Tasks;
using FluentAssertions;
using GoogleApi.Entities.Places.Common;
using Soenneker.Facts.Local;
using Soenneker.Google.Places.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Google.Places.Tests;

[Collection("Collection")]
public class GooglePlacesUtilTests : FixturedUnitTest
{
    private readonly IGooglePlacesUtil _util;

    public GooglePlacesUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGooglePlacesUtil>(true);
    }

    //[ManualFact]
    [LocalFact]
    public async Task GetPlace_should_get_place()
    {
        PlaceResult? result = await _util.GetPlace("11049 N 23rd Dr. Ste. 107, Phoenix, AZ. 85029");
        result.Should().NotBeNull();
    }

}