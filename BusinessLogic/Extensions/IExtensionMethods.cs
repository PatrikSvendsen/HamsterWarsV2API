namespace BusinessLogic.Extensions;

public interface IExtensionMethods<T> where T : class
{
    IEnumerable<T> RandomGenerator(IList<T> source);
}
