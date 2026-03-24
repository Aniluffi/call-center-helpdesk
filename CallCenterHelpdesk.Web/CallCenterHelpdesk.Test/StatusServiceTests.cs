using CallCenterHelpdesk.Data.Enums;
using CallCenterHelpdesk.Data;
using CallCenterHelpdesk.IService.Models.StatusService.Request;
using CallCenterHelpdesk.Service;
using Microsoft.EntityFrameworkCore;

namespace CallCenterHelpdesk.Test
{
    public class StatusServiceTests
    {
        [Fact]
        public async Task GetList_ShouldReturnCorrectNames()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "StatusDb")
                .Options;
            var service = new StatusService(options);

            // Act
            var result = await service.GetList(new StatusGetListRequest());

            // Assert
            var newStatus = result.Items.FirstOrDefault(x => x.Id == (int)StatusRequestEnum.New);
            Assert.NotNull(newStatus);
            Assert.Equal("Новая", newStatus.Name);

            var resolvedStatus = result.Items.FirstOrDefault(x => x.Id == (int)StatusRequestEnum.Resolved);
            Assert.Equal("Завершена", resolvedStatus.Name);
        }
    }
}