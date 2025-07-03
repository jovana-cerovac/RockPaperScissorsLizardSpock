using ChoiceAPI.Core.Contracts;
using ChoiceAPI.Core.Domain;
using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services;
using ChoiceAPI.Core.Services.Abstractions;
using NSubstitute;

namespace ChoiceAPI.Core.UnitTests.Services;

public class ChoiceServiceTests
{
    private readonly IChoiceRepository _choiceRepository;
    private readonly IRandomNumberService _randomNumberService;
    private readonly ChoiceService _choiceService;

    public ChoiceServiceTests()
    {
        _choiceRepository = Substitute.For<IChoiceRepository>();
        _randomNumberService = Substitute.For<IRandomNumberService>();
        _choiceService = new ChoiceService(_choiceRepository, _randomNumberService);
    }

    [Fact]
    public async Task GetAll_ReturnsAllChoices()
    {
        // Arrange
        var choices = new List<Choice>
        {
            new RockChoice(),
            new ScissorsChoice()
        };
        _choiceRepository.GetAllChoicesAsync().Returns(choices);

        // Act
        var result = (await _choiceService.GetAllChoicesAsync()).ToList();

        // Assert
        Assert.Equal(choices.Count, result.Count);
        Assert.All(result, r => Assert.IsType<ChoiceResponse>(r));
    }
}