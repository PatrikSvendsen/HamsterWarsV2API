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

    public HamsterDto CreateHamster(HamsterForCreationDto hamster)
    {
        var hamsterEntity = _mapper.Map<Hamster>(hamster);

        _repository.Hamster.CreateHamster(hamsterEntity);
        _repository.Save();

        var hamsterToReturn = _mapper.Map<HamsterDto>(hamsterEntity);

        return hamsterToReturn;
    }

    public IEnumerable<HamsterDto> GetAllHamsters(bool trackChanges)
    {
        var hamsters = _repository.Hamster.GetAllHamsters(trackChanges);

        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);

        return hamstersDto;
    }

    public IEnumerable<HamsterDto> GetTop5Hamsters(bool trackChanges)
    {
        var hamsters = _repository.Hamster.GetAllHamsters(trackChanges)
            .OrderByDescending(h => h.Wins)
            .Take(5);

        var hamstersDto = _mapper.Map<IEnumerable<HamsterDto>>(hamsters);

        return hamstersDto;
    }

    public IEnumerable<HamsterDto> GetBot5Hamsters(bool trackChanges)
    {
        throw new NotImplementedException();
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

    public void DeleteHamster(int id, bool trackChanges)
    {
        var hamsterToDelete = _repository.Hamster.GetHamster(id, trackChanges);
        if (hamsterToDelete is null)
        {
            throw new HamsterNotFoundException(id);
        }

        _repository.Hamster.DeleteHamster(hamsterToDelete);
        _repository.Save();
    }

    public void UpdateHamster(int id, HamsterToUpdateDto hamsterToUpdateDto, bool trackChanges)
    {
        var hamster = _repository.Hamster.GetHamster(id, trackChanges);
        if (hamster is null)
        {
            throw new HamsterNotFoundException(id);
        }

        _mapper.Map(hamsterToUpdateDto, hamster);
        _repository.Save();
    }

    //TODO Problem att få den att fungera, mappingprofile vill inte fungera. Kommer ut som
    // en lista av hamsters men vill inte göra om till Dto.
    public HamsterDto GetRandomHamster(bool trackChanges)
    {
        var hamsters = _repository.Hamster.GetAllHamsters(trackChanges: false).ToList();
        //var randomHamster = _extensions.RandomGenerator(hamsters);

        int n = hamsters.Count();
        // Plockat från Stackoverflow/google --https://blog.codinghorror.com/shuffling/
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            Hamster value = hamsters[k];
            hamsters[k] = hamsters[n];
            hamsters[n] = value;
        }

        var randomHamster = hamsters.Take(1).ToList();

        var hamsterDto = _mapper.Map<HamsterDto>(randomHamster);

        return hamsterDto;
    }
}
