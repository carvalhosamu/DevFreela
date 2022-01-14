﻿using DevFreela.Application.Commands.CreateProject;
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

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOK_Executed_ReturnProjectId()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand("Title Teste", "Descricao de Teste", 1, 2, 50000);

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            //Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
