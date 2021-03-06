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

        _repository.Match.CreateMatch(matchEntity);
        await _repository.SaveAsync();

        var matchToReturn = _mapper.Map<MatchDto>(matchEntity);
        return matchToReturn;
    }

    public async Task DeleteMatchAsync(int id, bool trackChanges)
    {
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

        var allMatches = hamsterMatches.Where(h => h.WinnerId == hamsterId).ToList();
        if (allMatches is null)
        {
            throw new MatchesNotFoundException();
        }

        var hamsterMatch = _mapper.Map<IEnumerable<MatchDto>>(allMatches);
        return hamsterMatch;
    }

    public async Task<MatchDto> GetMatchAsync(int id, bool trackChanges)
    {
        var matchDb = await _repository.Match.GetMatchAsync(id, trackChanges);
        if (matchDb is null)
        {
            throw new MatchNotFoundException(id);
        }
        var hamsters = await _repository.Hamster.GetAllHamstersAsync(trackChanges);

        matchDb.Hamsters = hamsters
            .Where(e => e.Id == matchDb.WinnerId)
            .Where(f => f.Id == matchDb.LoserId)
            .ToList();

        var match = _mapper.Map<MatchDto>(matchDb);
        return match;
    }

    public async Task<IEnumerable<MatchDto>> GetMatchesAsync(bool trackChanges)
    {
        var matchFromDb = await _repository.Match.GetMatchesAsync(trackChanges);
        if (matchFromDb is null)
        {
            throw new MatchesNotFoundException();
        }

        var matchDto = _mapper.Map<IEnumerable<MatchDto>>(matchFromDb);
        return matchDto;
    }
}
