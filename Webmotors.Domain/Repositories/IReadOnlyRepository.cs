using System.Collections.Generic;

namespace Webmotors.Domain.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> List(IDictionary<string, object> keys);
        T Get(IDictionary<string, object> keys);
    }
}
