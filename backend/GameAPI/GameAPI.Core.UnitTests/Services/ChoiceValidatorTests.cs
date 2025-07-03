using GameAPI.Core.Exceptions;
using GameAPI.Core.Services;

namespace GameAPI.Core.UnitTests.Services;

public class ChoiceValidatorTests
{
    private readonly ChoiceValidator _validator = new();

    [Fact]
    public void ValidateChoiceId_WithValidId_DoesNotThrowException()
    {
        // Arrange
        const int validChoiceId = 1;

        // Act & Assert
        _validator.ValidateChoiceId(validChoiceId);
    }

    [Fact]
    public void ValidateChoiceId_WithInvalidId_ThrowsBadRequestException()
    {
        // Arrange
        const int invalidChoiceId = 999;

        // Act & Assert
        Assert.Throws<BadRequestException>(() => _validator.ValidateChoiceId(invalidChoiceId));
    }
}