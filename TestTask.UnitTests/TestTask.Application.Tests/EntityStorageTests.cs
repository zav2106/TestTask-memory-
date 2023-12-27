using FluentAssertions;
using TestTask.Application.Services;
using TestTask.Domain.BusinessObjects;
using Xunit;

namespace TestTask.UnitTests.TestTask.Application.Tests;

public class EntityStorageTests
{
    [Fact]
    public async Task Create()
    {
        // Arrange
        var entityStorage = new EntityStorage();
        var entity = new Entity();
        // Act
        entityStorage.Add(entity);
        var result = entityStorage.GetById(entity.Id);
        // Assert
        result.OperationDate.Should().Be(entity.OperationDate);
        result.Amount.Should().Be(entity.Amount);
    }
}
