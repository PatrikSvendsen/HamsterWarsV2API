using System.Linq.Expressions;

namespace Contracts;

public interface IRepositoryBase<T>
{
    /// <summary>
    /// Generisk metod för att hitta allt i databasen. 
    /// </summary>
    /// <returns>Om det finns data så returneras allt tillbaka</returns>
    IQueryable<T> FindAll(bool trackChanges);
    /// <summary>
    /// Generisk metod att hitta något i databasen baserat på kriterier.
    /// </summary>
    /// <returns>Om det finns något i databasen som matchar så returneras det.</returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
    bool trackChanges);
    /// <summary>
    /// Generisk metod för att skapa ett nytt objekt i databasen.
    /// </summary>
    /// <param name="entity">Det objekt som skall skapas</param>
    void Create(T entity);
    /// <summary>
    /// Generisk metod för att uppdatera ett objekt i databasen.
    /// </summary>
    /// <param name="entity">Det objekt som skall uppdateras</param>
    void Update(T entity);
    /// <summary>
    /// Generisk metdo för att ta bort ett objekt i databasen.
    /// </summary>
    /// <param name="entity">Det objekt som skall tas bort</param>
    void Delete(T entity);
}
