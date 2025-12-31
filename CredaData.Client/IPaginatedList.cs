using System.Collections;

namespace CredaData.Client
{
    public interface IPaginatedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IPagedData
    {
    }
}
