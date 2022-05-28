using Shared.DataTransferObjects.Hamster;

namespace Service.Contracts.ModelServiceContracts;

public interface IHamsterService
{
    IEnumerable<HamsterDto> GetAllHamsters(bool trackChanges);
    HamsterDto GetHamster(int hamsterId, bool trackChanges);
    HamsterDto CreateHamster(HamsterForCreationDto hamster);
    HamsterDto GetRandomHamster(bool trackChanges);
    void DeleteHamster(int id, bool trackChanges);
    void UpdateHamster(int id, HamsterToUpdateDto hamsterToUpdateDto, bool trackChanges);

    IEnumerable<HamsterDto> GetTop5Hamsters(bool trackChanges);
    IEnumerable<HamsterDto> GetBot5Hamsters(bool trackChanges);

}
