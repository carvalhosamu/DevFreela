using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectStart_Executed_ReturnStartedProject()
        {
            var project = new Project("Nome teste", "Descricao", 1, 2, 10000);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress , project.Status);
            Assert.NotNull(project.StartedAt);
        }

        [Fact]
        public void ProjectConstructor_Created_ReturnNewProject()
        {
            var project = new Project("Nome teste", "Descricao", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);
            Assert.Null(project.FinishedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);
        }
    }
}
