using Autofac;
using DesignPatterns_5_Singleton.Example3;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SingletonNoTestabilityIssuesTest
    {
        [Test]
        public void ConfigurePopulationTest()
        {
            var rf = new ConfigurebleRecordFinder(new DummyDatabase());
            var names = new[] { "alpha", "gamma" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            cb.RegisterType<ConfigurebleRecordFinder>();
            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurebleRecordFinder>();
            }
        }
    }
}