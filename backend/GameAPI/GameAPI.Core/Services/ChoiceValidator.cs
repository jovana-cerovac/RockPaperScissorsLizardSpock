using GameAPI.Core.Constants;
using GameAPI.Core.Domain;
using GameAPI.Core.Exceptions;
using GameAPI.Core.Services.Abstractions;

namespace GameAPI.Core.Services;

public class ChoiceValidator : IChoiceValidator
{
    public void ValidateChoiceId(int id)
    {
        if (!Enum.IsDefined(typeof(ChoiceType), id))
        {
            throw new BadRequestException(
                $"Invalid Choice ID value {id}. Choice ID must be between {ChoiceConstants.MinChoiceId} and {ChoiceConstants.MaxChoiceId}.");
        }
    }
}