using Entities.Models;

namespace Contracts.ModelContracts;

public interface IHamsterRepository
{
    IEnumerable<Hamster> GetAllHamsters(bool trackChanges);
    Hamster GetHamster(int hamsterId, bool trackChanges);
}
