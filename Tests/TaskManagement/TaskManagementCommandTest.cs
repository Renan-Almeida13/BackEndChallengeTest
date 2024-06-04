using Domain.Entities.TaskManagement.Commands;
using Domain.Interfaces.TaskManagement;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TaskManagement
{
    public class TaskManagementCommandTest
    {
        [Fact]
        public async void AddTaskManagementComandTest()
        {
            // Arrange
            var iUserMock = new Mock<ITaskManagementRepository>();
            var request = new AddTaskManagementCommand
            {
                UserName = "Test",
                Date = DateTime.Now,
                StartTime = "1997-05-05",
                EndTime = "1997-05-05",
                Subject = "TestSubject",
                Description = "TestDescription"
            };

            var handler = new AddTaskManagementCommandHandler(iUserMock.Object);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Errors);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async void EditTaskManagementComandTest()
        {
            // Arrange
            var iUserMock = new Mock<ITaskManagementRepository>();
            var request = new EditTaskManagementCommand
            {
                Id = 1,
                UserName = "TestUpdate",
                Date = DateTime.Now,
                StartTime = "1997-07-07",
                EndTime = "1997-08-08",
                Subject = "TestSubjectUpdate",
                Description = "TestDescriptionUpdate"
            };

            var handler = new EditTaskManagementCommandHandler(iUserMock.Object);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Errors);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async void RemoveTaskManagementComandTest()
        {
            // Arrange
            var iUserMock = new Mock<ITaskManagementRepository>();
            var request = new RemoveTaskManagementCommand
            {
                Id = 1
            };

            var handler = new RemoveTaskManagementCommandHandler(iUserMock.Object);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Null(response.Errors);
            Assert.NotNull(response.Data);
        }
    }
}
