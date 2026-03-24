using CallCenterHelpdesk.Data;
using CallCenterHelpdesk.Data.Enums;
using CallCenterHelpdesk.IService.Models.RequestService.Request;
using CallCenterHelpdesk.Service;
using Microsoft.EntityFrameworkCore;

namespace CallCenterHelpdesk.Test
{
    public class RequestServiceTests
    {
        private DbContextOptions<DataContext> GetOptions()
        {
            // Создаем уникальное имя базы для каждого теста, чтобы они не влияли друг на друга
            return new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task Create_ShouldAddNewRequestToDatabase()
        {
            // Arrange (Подготовка)
            var options = GetOptions();
            var service = new RequestService(options);
            var requestDto = new RequestCreateRequest
            {
                Title = "Проблема с интернетом",
                Discription = "Не работает роутер",
                PersonContact = "test@mail.com"
            };

            // Act (Действие)
            var requestId = await service.Create(requestDto);

            // Assert (Проверка)
            using var db = new DataContext(options);
            var dbRequest = await db.Requests.FindAsync(requestId);

            Assert.NotNull(dbRequest);
            Assert.Equal(requestDto.Title, dbRequest.Title);
            Assert.Equal(StatusRequestEnum.New, dbRequest.Status); // Проверяем статус по умолчанию
        }

        [Fact]
        public async Task GetList_ShouldFilterByStatus()
        {
            // Arrange
            var options = GetOptions();
            using (var db = new DataContext(options))
            {
                // Наполняем базу тестовыми данными
                await db.Requests.AddRangeAsync(
                    new Data.Models.Request { Id = Guid.NewGuid(), Title = "R1", Status = StatusRequestEnum.New, PersonContact = "1" },
                    new Data.Models.Request { Id = Guid.NewGuid(), Title = "R2", Status = StatusRequestEnum.Resolved, PersonContact = "2" }
                );
                await db.SaveChangesAsync();
            }
            var service = new RequestService(options);

            // Act: запрашиваем только "Завершенные"
            var result = await service.GetList(new RequestGetListRequest
            {
                Statuses = new List<StatusRequestEnum> { StatusRequestEnum.Resolved }
            });

            // Assert
            Assert.Single(result.Requests);
            Assert.Equal(StatusRequestEnum.Resolved, result.Requests.First().Status);
        }

        [Fact]
        public async Task Update_ShouldChangeStatusAndTitle()
        {
            // Arrange
            var options = GetOptions();
            var requestId = Guid.NewGuid();
            using (var db = new DataContext(options))
            {
                await db.Requests.AddAsync(new Data.Models.Request
                {
                    Id = requestId,
                    Title = "Старый заголовок",
                    Status = StatusRequestEnum.New,
                    PersonContact = "old@mail.com"
                });
                await db.SaveChangesAsync();
            }
            var service = new RequestService(options);
            var updateDto = new RequestUpdateRequest
            {
                Id = requestId,
                Title = "Новый заголовок",
                Status = StatusRequestEnum.InProgress,
                PersonContact = "new@mail.com",
                Discription = "Описание"
            };

            // Act
            var isSuccess = await service.Update(updateDto);

            // Assert
            Assert.True(isSuccess);
            using var dbCheck = new DataContext(options);
            var updated = await dbCheck.Requests.FindAsync(requestId);
            Assert.Equal("Новый заголовок", updated.Title);
            Assert.Equal(StatusRequestEnum.InProgress, updated.Status);
        }

        [Fact]
        public async Task Delete_ShouldRemoveRequest()
        {
            // Arrange
            var options = GetOptions();
            var requestId = Guid.NewGuid();
            using (var db = new DataContext(options))
            {
                await db.Requests.AddAsync(new Data.Models.Request { Id = requestId, Title = "To Delete", PersonContact = "1" });
                await db.SaveChangesAsync();
            }
            var service = new RequestService(options);

            // Act
            await service.Delete(new RequestDeleteRequest { Id = requestId });

            // Assert
            using var dbCheck = new DataContext(options);
            var deleted = await dbCheck.Requests.FindAsync(requestId);
            Assert.Null(deleted);
        }
    }
}
