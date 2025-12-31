using CredaData.Client.Models;

namespace CredaData.Client
{
    public interface IPagedData
    {
        int PageSize { get; }

        int PageNumber { get; }

        int PageCount { get; }

        int TotalRecords { get; }

        RecordRange GetRecordRangeFor(int page);
    }
}
