using Soenneker.Google.Places.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Google.Places.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GooglePlacesUtilTests : HostedUnitTest
{
    private readonly IGooglePlacesUtil _util;

    public GooglePlacesUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGooglePlacesUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
