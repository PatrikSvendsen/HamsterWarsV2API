using Shared.DataTransferObjects.Hamster;

namespace Shared.DataTransferObjects.Match;

public record MatchDtoList (IEnumerable<HamsterDto> hamsters);
