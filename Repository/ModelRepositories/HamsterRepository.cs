using Contracts.ModelContracts;
using Entities.Models;

namespace Repository.ModelRepositories;

internal sealed class HamsterRepository : RepositoryBase<Hamster>, IHamsterRepository
{
    public HamsterRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Hamster> GetAllHamsters(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(h => h.FavFood)
        .ToList();

    public Hamster GetHamster(int hamsterId, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(hamsterId), trackChanges)
        .SingleOrDefault();
}
