using Entities.Models;

namespace Contracts.ModelContracts;

public interface IHamsterRepository
{
    Task<IEnumerable<Hamster>> GetAllHamstersAsync(bool trackChanges);
    Task<Hamster> GetHamsterAsync(int hamsterId, bool trackChanges);
    void CreateHamster(Hamster hamster);
    void DeleteHamster(Hamster hamster);
}
