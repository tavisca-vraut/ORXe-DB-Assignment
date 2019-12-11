using Xunit;
using FluentAssertions;

using DatabaseAssignment.Core;
using MongoDB.Bson;

namespace DatabaseAssignment.Tests
{
    public class ExtensionMethodsFixtures
    {
        [Fact]
        public void StringToRegion_ShouldReturnRegionInstance_Test()
        {
            var testRegionString = "1|some name|long name|-23.54|56|sub-classification";

            var actualOutput = testRegionString.ToRegion();

            actualOutput.Id.Should().Be(1);
            actualOutput.Name.Should().Be("some name");
            actualOutput.LongName.Should().Be("long name");
            actualOutput.Latitude.Should().Be(-23.54f);
            actualOutput.Longitude.Should().Be(56);
            actualOutput.SubClassification.Should().Be("sub-classification");
        }

        [Fact]
        public void RegionToBson_Test()
        {
            var testRegionString = "1|some name|long name|23|56|sub-classification";

            var region = testRegionString.ToRegion();

            var expectedOutput = new BsonDocument
            {
                { "id", region.Id},
                { "name", region.Name },
                { "longName", region.LongName },
                { "latitude", region.Latitude },
                { "longitude", region.Longitude },
                { "subClassification", region.SubClassification }
            };

            region.ToBson().Should().BeEquivalentTo(expectedOutput);
        }
    }
}
