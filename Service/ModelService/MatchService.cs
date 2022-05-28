using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

    public MatchDto GetMatch(int matchId, bool trackChanges)
    {
        var matchDb = _repository.Match.GetMatch(matchId, trackChanges);
        if (matchDb is null)
        {
            throw new MatchNotFoundException(matchId);
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
