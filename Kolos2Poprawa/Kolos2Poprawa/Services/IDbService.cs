using Kolos2Poprawa.DTOs;

namespace Kolos2Poprawa.Services;

public interface IDbService
{
    Task<CharacterItemsDto> GetCharacterItems(int id);
}