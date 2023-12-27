using FluentAssertions;
using TestTask.Domain.Entity;
using Xunit;

namespace TestTask.UnitTests.TestTask.Domain.Tests.Entity;

public class EntityServiceTests
{
    [Fact]
    public async Task Create()
    {
        // Arrange
        var entityService = new EntityService();
        var entity = new global::TestTask.Domain.Entity.Entity();
        // Act
        var result = await entityService.Create(entity);
        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public async Task GetById()
    {
        // Arrange
        var entityService = new EntityService();
        var entity = new global::TestTask.Domain.Entity.Entity();
        entity.Amount = new Random().Next(0, 100);
        var created = await entityService.Create(entity);
        // Act
        var result = await entityService.GetById(entity.Id);
        // Assert
        result.OperationDate.Should().Be(entity.OperationDate);
        result.Amount.Should().Be(entity.Amount);
    }
}
