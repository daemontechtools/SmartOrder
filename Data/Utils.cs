using System.Collections.Concurrent;

namespace SO.Data;

public static class Utils {

    static async Task<IEnumerable<T>> ConcurrentAsyncFilter<T>(
        this IEnumerable<T> source,
        Func<T, Task<bool>> predicate
    ) {
        var results = new ConcurrentQueue<T>();
        var task = source.Select(
            async x => {
                if(await predicate(x))
                    results.Enqueue(x);
            }
        );
        await Task.WhenAll(task);
        return results;
    }
}