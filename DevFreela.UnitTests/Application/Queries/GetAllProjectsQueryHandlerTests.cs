using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome 01", "projeto 01", 1, 2, 2000),
                new Project("Nome 02", "projeto 02", 1, 2, 2000),
                new Project("Nome 03", "projeto 03", 1, 2, 2000),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(x => x.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelAsyncList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert

            Assert.NotNull(projectViewModelAsyncList);
            Assert.NotEmpty(projectViewModelAsyncList);
            Assert.Equal(projects.Count, projectViewModelAsyncList.Count);
            
            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }


    }
}
