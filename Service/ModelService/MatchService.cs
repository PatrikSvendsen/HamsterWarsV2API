using AutoMapper;
using Contracts;
using Entities.Exceptions.NotFoundException.NotFoundException;
using Entities.Models;
using Service.Contracts.ModelServiceContracts;
using Shared.DataTransferObjects.Match;


namespace Service.ModelService;

internal sealed class MatchService : IMatchService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public MatchService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<MatchDto> CreateMatchAsync(MatchForCreationDto matchForCreationDto, bool trackChanges)
    {
        var matchEntity = _mapper.Map<Match>(matchForCreationDto);

        //TODO Finns ingen spärr om en hamster inte existerer. Match kommer skapas oavsett. 
        // Kanske ska ha en spärr _här_? 

        _repository.Match.CreateMatch(matchEntity);
        await _repository.SaveAsync();

        var matchToReturn = _mapper.Map<MatchDto>(matchEntity);

        return matchToReturn;
    }

    public async Task DeleteMatchAsync(int id, bool trackChanges)
    {
        //TODO Här bör koden ligga för de hamstrar som blir påverkade av deleten.
        // Ska resultaten återställas?

        var matchToDelete = await _repository.Match.GetMatchAsync(id, trackChanges: false);
        if (matchToDelete is null)
        {
            throw new MatchNotFoundException(id);
        }

        _repository.Match.DeleteMatch(matchToDelete);
        await _repository.SaveAsync();
    }

    public async Task<IEnumerable<MatchDto>> GetAllHamsterMatchesAsync(int hamsterId, bool trackChanges)
    {
        var hamsterDb = await _repository.Hamster.GetHamsterAsync(hamsterId, trackChanges: false);
        if (hamsterDb is null)
        {
            throw new HamsterNotFoundException(hamsterId);
        }

        var hamsterMatches = await _repository.Match.GetMatchesAsync(trackChanges: false);
        
        hamsterMatches.Where(x => x.WinnerId == hamsterId);

        if (hamsterMatches.Count() is 0)
        {
            throw new MatchesNotFoundException();
        }

        var hamsterMatch = _mapper.Map<IEnumerable<MatchDto>>(hamsterMatches);
        return hamsterMatch;
    }

    public async Task<MatchDto> GetMatchAsync(int id, bool trackChanges)
    {
        var matchDb = await _repository.Match.GetMatchAsync(id, trackChanges);
        if (matchDb is null)
        {
            throw new MatchNotFoundException(id);
        }

        var match = _mapper.Map<MatchDto>(matchDb);
        return match;
    }

    public async Task<IEnumerable<MatchDto>> GetMatchesAsync(bool trackChanges)
    {
        var matchFromDb = await _repository.Match.GetMatchesAsync(trackChanges);
        if (matchFromDb.Count() is 0) //TODO Går det att göra snyggare?
        {
            throw new MatchesNotFoundException();
        }

        var matchDto = _mapper.Map<IEnumerable<MatchDto>>(matchFromDb);
        return matchDto;
    }
}
