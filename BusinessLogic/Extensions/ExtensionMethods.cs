namespace BusinessLogic.Extensions;

internal sealed class ExtensionMethods<T> : IExtensionMethods<T> where T : class
{
    private static Random rnd = new Random();

    public IEnumerable<T> RandomGenerator(IList<T> source)
    {
        int n = source.Count();
        var list = source.ToList();

        // Plockat från Stackoverflow/google --https://blog.codinghorror.com/shuffling/
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }
}
