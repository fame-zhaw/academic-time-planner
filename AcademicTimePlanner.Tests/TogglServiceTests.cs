using AcademicTimePlanner.Services.TogglApiService;
using AcademicTimePlanner.Services.TogglService;
using AcademicTimePlanner.DataMapping.Toggl;
using Moq;

namespace AcademicTimePlanner.Tests;

[TestClass]
public class TogglServiceTests
{
    private Mock<ITogglApiService> _togglApiServiceMock; 
    private TogglService _componentUnderTest;

    [TestInitialize]
    public void Initialize()
    {
        _togglApiServiceMock = new Mock<ITogglApiService>();
        _componentUnderTest = new TogglService(_togglApiServiceMock.Object);
    }

    [TestMethod]
    public async Task GetTogglProjectsReturnsAllTogglProjects()
    {
        var projectName = "Test project";
        var taskName = "Test task";
        var projectIds = new List<long>() { 1, 2 };
        var taskIds = new List<long>() { 3, 4, 5 };


        // Arrange
        var dates = new List<DateTime>()
        {
            new (2022, 01, 01),
            new (2022, 01, 02),
            new (2022, 01, 03),
        };
        
        var togglDetailResponse = new TogglDetailResponse()
        {
            Data = new List<TogglDetailResponseData>()
            {
                new() { Id = 0, ProjectId = projectIds[0], TaskId = taskIds[0], Project = projectName, Task = taskName },
                new() { Id = 1, ProjectId = projectIds[0], TaskId = taskIds[1], Project = projectName, Task = taskName },
                new() { Id = 2, ProjectId = projectIds[1], TaskId = taskIds[2], Project = projectName, Task = taskName }, 
                new() { Id = 3, ProjectId = projectIds[1], TaskId = taskIds[2], Project = projectName, Task = taskName },
            }
        };

        var expectedTogglProjectList = new List<TogglProject>()
        {
            new (projectIds[0], projectName),
            new (projectIds[1], projectName),
        };

        _togglApiServiceMock
            .Setup(mock => mock.GetDetailsSinceAsync(It.IsAny<DateOnly>()))
            .ReturnsAsync(togglDetailResponse);
        
        // Act
        var actualTogglProjectList = await _componentUnderTest.GetTogglProjects(It.IsAny<DateOnly>());
        
        // Asset
        Assert.AreEqual(expectedTogglProjectList.Count, actualTogglProjectList.Count);
        for (var index = 0; index < expectedTogglProjectList.Count; index++)
        {
            Assert.IsTrue(expectedTogglProjectList[index].TogglId == actualTogglProjectList[index].TogglId);
            Assert.IsTrue(expectedTogglProjectList[index].Name == projectName);
        }
    }
}