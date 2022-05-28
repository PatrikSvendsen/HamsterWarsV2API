using Shared.DataTransferObjects.Hamster;

namespace Service.Contracts.ModelServiceContracts;

public interface IHamsterService
{
    IEnumerable<MatchDto> GetAllHamsters(bool trackChanges);
    MatchDto GetHamster(int hamsterId, bool trackChanges);
}
