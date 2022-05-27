using Shared.DataTransferObjects.Hamster;

namespace Service.Contracts.ModelServiceContracts;

public interface IHamsterService
{
    IEnumerable<HamsterDto> GetAllHamsters(bool trackChanges);
    HamsterDto GetHamster(int hamsterId, bool trackChanges);
}
