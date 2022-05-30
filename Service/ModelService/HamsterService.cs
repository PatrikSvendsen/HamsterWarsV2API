using AutoMapper;
using BusinessLogic.Extensions;
using Contracts;
using Entities.Exceptions.NotFoundException.NotFoundException;
using Entities.Models;
using Service.Contracts.ModelServiceContracts;
using Shared.DataTransferObjects.Hamster;

namespace Service.ModelService;

internal sealed class HamsterService : IHamsterService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    //private readonly IExtensionMethods<Hamster> _extensions;
    private static Random rnd = new Random();

    public HamsterService(IRepositoryManager repository, ILoggerManager logger,
        IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<HamsterDto> CreateHamsterAsync(HamsterForCreationDto hamster)
    {
        var hamsterEntity = _mapper.Map<Hamster>(hamster);

        _repository.Hamster.CreateHamster(hamsterEntity);
        await _repository.SaveAsync();

        var hamsterToReturn = _mapper.Map<HamsterDto>(hamsterEntity);

        return hamsterToReturn;
    }

    public async Task<IEnumerable<HamsterDto>> GetAllHamstersAsync(bool trackChanges)
    {
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges);

        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);

        return hamstersDto;
    }

    public async Task<IEnumerable<HamsterDto>> GetTop5HamstersAsync(bool trackChanges)
    {
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges);
        
        //TODO Kontrollera om denna fungerar korrekt
        hamsters.OrderByDescending(h => h.Wins).Take(5);

        if (hamsters.Count() is 0)
        {
            throw new HamstersNotFoundException();
        }

        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);

        return hamstersDto;
    }

    public async Task<IEnumerable<HamsterDto>> GetBot5HamstersAsync(bool trackChanges)
    {
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges);
        
        //TODO Kontrollera om denna fungerar korrekt
        hamsters.OrderByDescending(d => d.Defeats).Take(5);

        //TODO Tanken är att den ska kasta en throw om det inte finns några hamstrar med förluster
        if (hamsters.Where(d => d.Defeats == 0).Count() is 0)
        {
            throw new HamstersNotFoundException();
        }

        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);
        return hamstersDto;
    }

    public async Task<HamsterDto> GetHamsterAsync(int id, bool trackChanges)
    {
        var hamster = await _repository.Hamster.GetHamsterAsync(id, trackChanges);
        if (hamster is null)
        {
            throw new HamsterNotFoundException(id);
        }

        var hamsterDto = _mapper.Map<HamsterDto>(hamster);

        return hamsterDto;
    }

    public async Task DeleteHamsterAsync(int id, bool trackChanges)
    {
        var hamsterToDelete = await _repository.Hamster.GetHamsterAsync(id, trackChanges);
        if (hamsterToDelete is null)
        {
            throw new HamsterNotFoundException(id);
        }

        _repository.Hamster.DeleteHamster(hamsterToDelete);
        await _repository.SaveAsync();
    }

    public async Task UpdateHamsterAsync(int id, HamsterToUpdateDto hamsterToUpdateDto, bool trackChanges)
    {
        var hamster = await _repository.Hamster.GetHamsterAsync(id, trackChanges);
        if (hamster is null)
        {
            throw new HamsterNotFoundException(id);
        }

        _mapper.Map(hamsterToUpdateDto, hamster);
        await _repository.SaveAsync();
    }

    //TODO Problem att få den att fungera, mappingprofile vill inte fungera. Kommer ut som
    // en lista av hamsters men vill inte göra om till Dto.
    public async Task<HamsterDto> GetRandomHamsterAsync(bool trackChanges)
    {
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges: false);
        
        hamsters.ToList();

        int n = rnd.Next(1, hamsters.Count());
        var rndHamster = hamsters.Where(x => x.Id.Equals(n)).FirstOrDefault();

        var hamsterDto = _mapper.Map<HamsterDto>(rndHamster);

        return hamsterDto;
    }
}
