using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts.ModelServiceContracts;
using Shared.DataTransferObjects.Hamster;

namespace Service.ModelService;

internal sealed class HamsterService : IHamsterService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HamsterService(IRepositoryManager repository, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<HamsterDto> GetAllHamsters(bool trackChanges)
    {
        var hamsters = _repository.Hamster.GetAllHamsters(trackChanges);

        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);

        return hamstersDto;
    }

    public HamsterDto GetHamster(int id, bool trackChanges)
    {
        var hamster = _repository.Hamster.GetHamster(id, trackChanges);
        if (hamster is null)
        {
            throw new HamsterNotFoundException(id);
        }

        var hamsterDto = _mapper.Map<HamsterDto>(hamster);
        
        return hamsterDto;
    }
}
