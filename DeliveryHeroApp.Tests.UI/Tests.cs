using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DeliveryHeroApp.Tests.UI
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.Tap(q => q.Button("ViewRouteBtn"));
            app.WaitForElement("RouteListView");

            app.Screenshot("After tapping on 'View route'");

            Assert.False(app.Query("ViewRouteBtn").Any());
        }
    }
}
