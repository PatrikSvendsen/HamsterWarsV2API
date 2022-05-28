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

    public MatchDto CreateMatch(MatchForCreationDto matchForCreationDto, bool trackChanges)
    {
        var matchEntity = _mapper.Map<Match>(matchForCreationDto);

        //TODO Finns ingen spärr om en hamster inte existerer. Match kommer skapas oavsett. 
        // Kanske ska ha en spärr _här_? 

        _repository.Match.CreateMatch(matchEntity);
        _repository.Save();

        var matchToReturn = _mapper.Map<MatchDto>(matchEntity);

        return matchToReturn;
    }

    public void DeleteMatch(int id, bool trackChanges)
    {
        //TODO Här bör koden ligga för de hamstrar som blir påverkade av deleten.
        // Ska resultaten återställas?

        var matchToDelete = _repository.Match.GetMatch(id, trackChanges: false);
        if (matchToDelete is null)
        {
            throw new MatchNotFoundException(id);
        }
        _repository.Match.DeleteMatch(matchToDelete);
        _repository.Save();
    }

    public MatchDto GetMatch(int id, bool trackChanges)
    {
        var matchDb = _repository.Match.GetMatch(id, trackChanges);
        if (matchDb is null)
        {
            throw new MatchNotFoundException(id);
        }
        var match = _mapper.Map<MatchDto>(matchDb);
        return match;
    }

    public IEnumerable<MatchDto> GetMatches(bool trackChanges)
    {
        var matchFromDb = _repository.Match.GetMatches(trackChanges);

        if (matchFromDb.Count() is 0) //TODO Går det att göra snyggare?
        {
            throw new MatchesNotFoundException();
        }

        var matchDto = _mapper.Map<IEnumerable<MatchDto>>(matchFromDb);

        return matchDto;
    }
}
