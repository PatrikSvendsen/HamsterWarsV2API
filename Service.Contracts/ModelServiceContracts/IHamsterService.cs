using Shared.DataTransferObjects.Hamster;

namespace Service.Contracts.ModelServiceContracts;

public interface IHamsterService
{
    Task<IEnumerable<HamsterDto>> GetAllHamstersAsync(bool trackChanges);
    Task<HamsterDto> GetHamsterAsync(int hamsterId, bool trackChanges);
    Task<HamsterDto> CreateHamsterAsync(HamsterForCreationDto hamster);
    Task<HamsterDto> GetRandomHamsterAsync(bool trackChanges);
    Task<List<HamsterDto>> Get2RandomHamsterAsync(bool trackChanges);
    Task DeleteHamsterAsync(int id, bool trackChanges);
    Task UpdateHamsterAsync(int id, HamsterToUpdateDto hamsterToUpdateDto, bool trackChanges);
    Task<IEnumerable<HamsterDto>> GetTop5HamstersAsync(bool trackChanges);
    Task<IEnumerable<HamsterDto>> GetBot5HamstersAsync(bool trackChanges);
}
