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
    /// <summary>
    /// Metod för att hämta en random hamster.
    /// </summary>
    /// <returns>Komplett lista med alla hamstrar</returns>
    Task<HamsterDto> GetRandomHamster();
    /// <summary>
    /// Metod för att hämta 2 random hamstrar.
    /// </summary>
    /// <returns>Komplett lista med alla hamstrar</returns>
    Task<List<HamsterDto>> Get2RandomHamsters();
    /// <summary>
    /// Metod för att hämta de top 5 bästa hamstrarna.
    /// </summary>
    /// <returns>Komplett lista med alla hamstrar</returns>
    Task<List<HamsterDto>> GetTop5Hamsters();
    /// <summary>
    /// Metod för att hämta de 5 sästa hamstrarna.
    /// </summary>
    /// <returns>Komplett lista med alla hamstrar</returns>
    Task<List<HamsterDto>> GetBot5Hamsters();
    

}
