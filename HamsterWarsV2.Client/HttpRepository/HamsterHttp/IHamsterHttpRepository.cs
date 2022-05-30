using Shared.DataTransferObjects.Hamster;

namespace HamsterWarsV2.Client.HttpRepository.HamsterHttp;
public interface IHamsterHttpRepository
{
    /// <summary>
    /// Metod för att hämta alla hamstrar
    /// </summary>
    /// <returns>Komplett lista med alla hamstrar</returns>
    Task<List<HamsterDto>> GetHamsters();
    /// <summary>
    /// Metod för att hämta specific hamster via Id
    /// </summary>
    /// <returns>Ett object där Id matchar en hamster i Db</returns>
    Task<HamsterDto> GetHamster(int id);
    /// <summary>
    /// Metod som tar bort en hamster i db
    /// </summary>
    Task DeleteHamster(int id);
    /// <summary>
    /// Metod för att uppdatera ett object i db
    /// </summary>
    /// <param name="hamster">Det uppdaterade objectet</param>
    Task<HamsterDto> UpdateHamster(HamsterDto hamster);
    /// <summary>
    /// Metod för att skapa en specific hamster.
    /// </summary>
    Task<HamsterDto> CreateHamster(HamsterForCreationDto hamster);
    Task<HamsterDto> GetRandomHamster();

}
