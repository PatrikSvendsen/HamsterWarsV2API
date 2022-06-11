using AutoMapper;
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
        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);
        
        if (hamstersDto.Count() is 0)
        {
            throw new HamstersNotFoundException();
        }

        var top5Hamsters = hamstersDto
                            .OrderByDescending(w => w.Wins)
                            .Take(5)
                            .ToList();
        return top5Hamsters;
    }

    public async Task<IEnumerable<HamsterDto>> GetBot5HamstersAsync(bool trackChanges)
    {
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges);
        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);
        if (hamstersDto.Count() is 0)
        {
            throw new HamstersNotFoundException();
        }

        var bot5Hamsters = hamstersDto
                            .OrderByDescending(w => w.Defeats)
                            .Take(5)
                            .ToList();
        return bot5Hamsters;
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

    // Tack Rasmus för hjälpen.
    public async Task<HamsterDto> GetRandomHamsterAsync(bool trackChanges)
    {
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges: false);
        hamsters.ToList();
        int n = rnd.Next(1, hamsters.Count());
        var rndHamster = hamsters.Where(x => x.Id.Equals(n)).FirstOrDefault();

        var hamsterDto = _mapper.Map<HamsterDto>(rndHamster);
        return hamsterDto;
    }

    public async Task<List<HamsterDto>> Get2RandomHamsterAsync(bool trackChanges)
    {
        var list = await _repository.Hamster.GetAllHamstersAsync(trackChanges: false);
        int n = list.Count();
        var hamsterList = _mapper.Map<List<HamsterDto>>(list);

        // Plockat från Stackoverflow/google --https://blog.codinghorror.com/shuffling/
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            HamsterDto value = hamsterList[k];
            hamsterList[k] = hamsterList[n];
            hamsterList[n] = value;
        }

        var twoRandomHamsters = hamsterList
                                    .Take(2)
                                    .ToList();
        return twoRandomHamsters;
    }
}
