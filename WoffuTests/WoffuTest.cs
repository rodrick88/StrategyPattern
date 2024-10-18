using Xunit;
using System.Collections.Generic;

namespace WoffuTests
{
    public class WoffuTest
    {
        [Fact]
        public void Foo()
        {
            IList<Allocation> allocations = new List<Allocation> { new Allocation { Name = "Vacation", DaysToExpiration = 5, Availability = 5 } };
            WoffuProgam app = new WoffuProgam(allocations);
            app.UpdateAvailability();
            Assert.Equal(5.1m, allocations[0].Availability);
        }       
    }
}
