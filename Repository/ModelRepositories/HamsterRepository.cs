using Contracts.ModelContracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.ModelRepositories;

internal sealed class HamsterRepository : RepositoryBase<Hamster>, IHamsterRepository
{
    public HamsterRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Hamster>> GetAllHamstersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(h => h.Id)
        .ToListAsync();

    public async Task<Hamster> GetHamsterAsync(int hamsterId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(hamsterId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateHamster(Hamster hamster) => Create(hamster);

    public void DeleteHamster(Hamster hamster) => Delete(hamster);
}
