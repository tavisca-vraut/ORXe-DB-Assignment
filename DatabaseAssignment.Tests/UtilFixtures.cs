using Xunit;
using FluentAssertions;

using DatabaseAssignment.Core;

namespace DatabaseAssignment.Tests
{
    public class CoreFixtures
    {
        [Fact]
        public void GetDbConfigFileLocation_ShouldReturn_AppropriateFilePath()
        {
            var expectedResult = @"C:\Vighnesh_Docs\VisualStudioProjects\C#\Database-Assignment\DatabaseAssignment.Core\dbconfig.json";
            Util.GetDbConfigFileLocation().Should().Be(expectedResult);
        }
        [Fact]
        public void GetConnectionString_ShouldReturnAppropriateString_Test()
        {
            var expectedResult = @"mongodb+srv://vraut:<userPassword>@orxe-db-assignment-qen6i.mongodb.net/test?retryWrites=true&w=majority";
            
            Util.GetConnectionString().Should().Be(expectedResult);
        }
    }
}
