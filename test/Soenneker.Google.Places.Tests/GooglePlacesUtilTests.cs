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

    [Fact]
    public void Default()
    {

    }
}
