using Shared.DataTransferObjects.Hamster;

namespace Service.Contracts.ModelServiceContracts;

public interface IHamsterService
{
    /// <summary>
    /// Metod som hämtar alla hamstrar.
    /// </summary>
    /// <returns>En lista av hamstrar</returns>
    Task<IEnumerable<HamsterDto>> GetAllHamstersAsync(bool trackChanges);
    /// <summary>
    /// Metod som hämtar en specifik hamster utifrån id
    /// </summary>
    /// <param name="hamsterId">Id på det objekt som skall hämtas</param>
    /// <returns>Ett objekt där id matchar</returns>
    Task<HamsterDto> GetHamsterAsync(int hamsterId, bool trackChanges);
    /// <summary>
    /// Metod som skapar en hamstrer
    /// </summary>
    /// <param name="hamster">Objekt av en hamster</param>
    Task<HamsterDto> CreateHamsterAsync(HamsterForCreationDto hamster);
    /// <summary>
    /// Metod som hämtar en random hamster.
    /// </summary>
    /// <returns>En random hamster</returns>
    Task<HamsterDto> GetRandomHamsterAsync(bool trackChanges);
    /// <summary>
    /// Metod som hämtar 2 randomiserade hamstrar
    /// </summary>
    Task<List<HamsterDto>> Get2RandomHamsterAsync(bool trackChanges);
    /// <summary>
    /// Metod som tar bort ett objekt.
    /// </summary>
    /// <param name="id">Id på den hamster som skall tas bort</param>
    Task DeleteHamsterAsync(int id, bool trackChanges);
    /// <summary>
    /// Metod för att uppdatera en hamster
    /// </summary>
    /// <param name="id">Id på den hamster som skall uppdateras</param>
    /// <param name="hamsterToUpdateDto">Nya uppdaterade objektet</param>
    Task UpdateHamsterAsync(int id, HamsterToUpdateDto hamsterToUpdateDto, bool trackChanges);
    /// <summary>
    /// Hämtar 5 bästa hamstrarna.
    /// </summary>
    Task<IEnumerable<HamsterDto>> GetTop5HamstersAsync(bool trackChanges);
    /// <summary>
    /// Hämtar de 5 sämsta hamstrarna.
    /// </summary>
    Task<IEnumerable<HamsterDto>> GetBot5HamstersAsync(bool trackChanges);
}
