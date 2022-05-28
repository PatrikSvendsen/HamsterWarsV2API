using Shared.DataTransferObjects.Hamster;

namespace Service.Contracts.ModelServiceContracts;

public interface IHamsterService
{
    IEnumerable<HamsterDto> GetAllHamsters(bool trackChanges);
    HamsterDto GetHamster(int hamsterId, bool trackChanges);
    HamsterDto CreateHamster(HamsterForCreationDto hamster);
    HamsterDto GetRandomHamster(bool trackChanges);
}
