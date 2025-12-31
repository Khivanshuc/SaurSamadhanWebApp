using CredaData.Client.Models;
using CredaData.Models;
using System.Linq.Expressions;

namespace CredaData.Client
{
    public interface IFacade<TModel> where TModel : class, IModel
    {
        //
        // Summary:
        //     Get an entity by Id
        //
        // Parameters:
        //   id:
        //     Entity Id
        //
        // Returns:
        //     Entity for given Id
        Task<TModel?> GetAsync(long id);

        //
        // Summary:
        //     Get single entity or default for given filter
        //
        // Parameters:
        //   field:
        //     Field on which equality filter condition will be applied
        //
        //   valueEquals:
        //     value for equality filter
        //
        // Returns:
        //     entity for given filter or null if does not exists
        TModel Get(string field, object valueEquals);

        //
        // Summary:
        //     Get single entity or default for given filter (multiple filters can be part of
        //     same expression only) [ e.g. (a => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Parameters:
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Returns:
        //     entity for given filter or null if does not exists
        TModel Get(Expression<Func<TModel, bool>> filter);

        //
        // Summary:
        //     To get List of all entities exists in given table
        //
        // Returns:
        //     List of all entities
        Task<List<TModel>> ListAllAsync();

        //
        // Summary:
        //     To get List of all entities for given IDs
        //
        // Parameters:
        //   ids:
        //     Id list for which entities to be returned
        //
        // Returns:
        //     List of all entities
        List<TModel> ListAll(params long[] ids);
        Task<List<TModel>> ListAllAsync(params long[] ids);


        //
        // Summary:
        //     get List of all entities exists in given table after applying given filter filed
        //     and value by equating them
        //
        // Parameters:
        //   field:
        //     Field on which equality filter condition will be applied
        //
        //   valueEquals:
        //     value for equality filter
        //
        // Returns:
        //     List of all entities after applying given filter
        Task<List<TModel>> ListAllAsync(string field, object valueEquals);

        //
        // Summary:
        //     get List of all entities exists in given table after applying given filter (multiple
        //     filters can be part of same expression only) [ e.g. (a => (a.b == b1 && a.c ==
        //     c1) || a.d == d1
        //
        // Parameters:
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Returns:
        //     List of all entities after applying given filter
        Task<List<TModel>> ListAllAsync(Expression<Func<TModel, bool>> filter);

        //
        // Summary:
        //     List data in given and paged manner after applying specified filter and sorting
        //     (multiple filters can be part of same expression only) [ e.g. (a => (a.b == b1
        //     && a.c == c1) || a.d == d1
        //
        // Parameters:
        //   pageSize:
        //
        //   pageNumber:
        //
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        //   sortColumnAndOrder:
        //     Sorting for given column would be ascending or specify the order to be descending
        //     [e.g. For column Name and descending sorting the value should be Name DESC ]
        //
        //
        // Returns:
        //     Data for given page number and size
        IPaginatedList<TModel> ListPage(int pageSize, int pageNumber, Expression<Func<TModel, bool>> filter, string sortColumnAndOrder);

        //
        // Summary:
        //     List data in given and paged manner after applying specified filter and sorting
        //     (multiple filters can be part of same expression only) [ e.g. (a => (a.b == b1
        //     && a.c == c1) || a.d == d1
        //
        // Parameters:
        //   pageSize:
        //
        //   pageNumber:
        //
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        //   orderBy:
        //     Field to be used for order by
        //
        //   order:
        //     Sorting order default is Ascending
        //
        // Type parameters:
        //   T:
        //
        // Returns:
        //     Data for given page number and size
        IPaginatedList<TModel> ListPage<T>(int pageSize, int pageNumber, Expression<Func<TModel, bool>> filter, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending);

        //
        // Summary:
        //     List data in given and paged manner after applying specified sorting
        //
        // Parameters:
        //   pageSize:
        //
        //   pageNumber:
        //
        //   orderBy:
        //     Field to be used for order by
        //
        //   order:
        //     Sorting order default is Ascending
        //
        // Type parameters:
        //   T:
        //
        // Returns:
        //     Data for given page number and size
        IPaginatedList<TModel> ListPage<T>(int pageSize, int pageNumber, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending);

        //
        // Summary:
        //     List data in given and paged manner after applying specified filter and sorting
        //
        //
        // Parameters:
        //   pageSize:
        //
        //   pageNumber:
        //
        //   sortColumnAndOrder:
        //     Sorting for given column would be ascending or specify the order to be descending
        //     [e.g. For column Name and descending sorting the value should be Name DESC ]
        //
        //
        // Returns:
        //     Data for given page number and size
        IPaginatedList<TModel> ListPage(int pageSize, int pageNumber, string sortColumnAndOrder);

        //
        // Summary:
        //     List data in given and paged manner after applying specified filter and sorting
        //     by Id desc (multiple filters can be part of same expression only) [ e.g. (a =>
        //     (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Parameters:
        //   pageSize:
        //
        //   pageNumber:
        //
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Returns:
        //     Data for given page number and size order by id desc
        IPaginatedList<TModel> ListPage(int pageSize, int pageNumber, Expression<Func<TModel, bool>> filter);

        //
        // Summary:
        //     List data in given and paged manner after applying specified filter and sorting
        //     by Id desc
        //
        // Parameters:
        //   pageSize:
        //
        //   pageNumber:
        //
        // Returns:
        //     Data for given page number and size order by id desc
        IPaginatedList<TModel> ListPage(int pageSize, int pageNumber);

        //
        // Summary:
        //     List available top records after applying specified filter and sorting by Id
        //     Desc
        //
        // Parameters:
        //   maxRows:
        //     Maximum rows to be returned
        //
        // Returns:
        //     List of top records after applying specified filter and sorting by Id Desc
        List<TModel> ListTop(int maxRows);

        //
        // Summary:
        //     List available top records after applying specified filter and sorting (multiple
        //     filters can be part of same expression only) [ e.g. (a => (a.b == b1 amp;& a.c
        //     == c1) || a.d == d1
        //
        // Parameters:
        //   maxRows:
        //     Maximum rows to be returned
        //
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 amp;& a.c == c1) || a.d == d1
        //
        //   orderBy:
        //     Filed to be used for order by
        //
        //   order:
        //     Sorting order default is Ascending
        //
        // Type parameters:
        //   T:
        //
        // Returns:
        //     List of top records after applying specified filter and sorting
        List<TModel> ListTop<T>(int maxRows, Expression<Func<TModel, bool>> filter, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending);

        //
        // Summary:
        //     List available top records after applying sorting
        //
        // Parameters:
        //   maxRows:
        //     Maximum rows to be returned
        //
        //   orderBy:
        //     Field to be used for order by
        //
        //   order:
        //     Sorting order default is Ascending
        //
        // Type parameters:
        //   T:
        //
        // Returns:
        //     List of top records after applying specified filter and sorting
        List<TModel> ListTop<T>(int maxRows, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending);

        //
        // Summary:
        //     List available top records after applying specified filter and sorting
        //
        // Parameters:
        //   maxRows:
        //     Maximum rows to be returned
        //
        //   sortColumnAndOrder:
        //     Sorting for given column would be ascending or specify the order to be descending
        //     [e.g. For column Name and descending sorting the value should be Name DESC ]
        //
        //
        // Returns:
        //     List of top records after applying specified filter and sorting
        List<TModel> ListTop(int maxRows, string sortColumnAndOrder);

        //
        // Summary:
        //     This is to do keyword search on any text field and returns all results which
        //     have this filed which contains keyword
        //
        // Parameters:
        //   field:
        //     Field to be searched
        //
        //   contains:
        //     keyword to be searched
        //
        // Returns:
        //     records which have which contains keyword
        List<TModel> SearchBy(string field, string contains);

        //
        // Summary:
        //     Check if any record exists which given filter (multiple filters can be part of
        //     same expression only) [ e.g. (a => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Parameters:
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Returns:
        //     If record exists for given condition
        bool Exists(Expression<Func<TModel, bool>> filter);

        //
        // Summary:
        //     Check if any record exists which given filter
        //
        // Parameters:
        //   field:
        //     Field on which equality filter condition will be applied
        //
        //   valueEquals:
        //     value for equality filter
        bool Exists(string field, object valueEquals);

        //
        // Summary:
        //     Provide total number of records in table
        //
        // Returns:
        //     number of records in table
        Task<int> Count();
        //
        // Summary:
        //     Provide total number of records in table satisfying filter (multiple filters
        //     can be part of same expression only) [ e.g. (a => (a.b == b1 && a.c == c1) ||
        //     a.d == d1
        //
        // Parameters:
        //   filter:
        //     filter lambda (multiple filters can be part of same expression only) [ e.g. (a
        //     => (a.b == b1 && a.c == c1) || a.d == d1
        //
        // Returns:
        //     number of records in table satisfying filter
        Task<int> Count(Expression<Func<TModel, bool>> filter);

        //
        // Summary:
        //     Provide total number of records in table satisfying filter
        //
        // Parameters:
        //   field:
        //     Field on which equality filter condition will be applied
        //
        //   valueEquals:
        //     value for equality filter
        int Count(string field, object valueEquals);

        //
        // Summary:
        //     Get List Of AutoCompleteModel for given name and value fields and keywords for
        //     given filter field
        //
        // Parameters:
        //   nameField:
        //
        //   valueField:
        //
        //   filterColumn:
        //
        //   filterValue:
        //     keyword for filtering
        List<AutoCompleteModel> GetNameValues(string nameField, string valueField, string filterColumn = null, string filterValue = null);

        Task<ResponseModel> LoginService(LoginModel loginModel);
        Task<TModel> GetAsync();

        Task<TModel?> GetAsync(string Mobile);
        Task<List<TModel>> GetList(ParamModel model);
        Task<List<TModel>> GetList(long SiteId, long BlockId, string StatusName);
        Task<List<TModel>> GetList(long UserId);
        Task<List<TModel>> GetList(long DistrictId, long BlockId);
        Task<List<TModel>> GetList(long DistrictId, long BlockId, long VillageId, long SIId, long UserId);
        Task<List<TModel>> GetComplaintList(long DistrictId, long BlockId, long SIId, long UserId, long WorkingStatus);
        Task<List<TModel>> GetList(long DistrictId, long BlockId, long VillageId);
        Task<TModel> GetCountAsync();
        Task<TModel?> GetCountAsync(Expression<Func<TModel, bool>> filter);
        Task<TModel?> GetCountInternal(string filter = "");
        Task<List<TModel>> GetListAsync(string AttributeName, long AttributeValue, long UserId);

        Task<List<TModel>> ShowProjectReportList(long ProjectId, long DistrictId, DateTime StartDate, DateTime EndDate, long UserId);
        Task<List<TModel>> ShowProjectCountReport(long UserId, DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus);
        Task<List<TModel>> ShowProjectCountListReport(long ProjectId, long DistrictId, long UserId, DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus);
        Task<List<TModel>> DownloadProjectReportList(long ProjectId, long DistrictId, DateTime StartDate, DateTime EndDate, long UserId);
        Task<List<TModel>> GetDistListForAdminPanel(long UserId);
        Task<List<TModel>> GetList(long DistrictId, long BlockId, long VillageId, long SIId, long UserId, long WorkingStatus);
        Task<List<TModel>> GetList(long LoggedInUser, long DistrictId, long BlockId, long UserId, DateTime StartDate, DateTime EndDate, long FilterStatus);
        Task<List<TModel>> GetUserList(string UserName, long BlockId, long UserId);
        Task<List<TModel>> GetSSYRegLastData();
        Task<List<TModel>> GetGrievanceGlanceCount();
        Task<List<TModel>> GetGrievanceAnalyticsGraphData();
        Task<List<TModel>> GetSSYRegistrationDetail(long AdharNo, long MobileNo);
        Task<List<TModel>> VillageSitesList(long VillageId);
        Task<List<TModel>> GetUserWiseProjectWiseList(long UserId, long ProjectId, int FilterStatus, DateTime StartDate, DateTime EndDate);

        Task<List<TModel>> GetGrievanceGlanceList(long DistrictId, long TotalComplaint, long ResolvedComplaint,
            long ComplaintLess30Days, long PendingDOLessThan30Days, long PendingZOLessThan30Days, long PendingHOLessThan30Days,
            long ComplaintMore30Days, long PendingDOMoreThan30Days, long PendingZOMoreThan30Days, long PendingHOMoreThan30Days,
            long TotalPendingComplaint);
        Task<List<TModel>> GetGrievanceList(long DistrictId, long BlockId, long VillageId, long SIId, long UserId, long WorkingStatus, long filterStatus, DateTime StartDate, DateTime EndDate);
        Task<bool> SendUpdateGrievanceOTP(long GrievanceId);
        Task<List<TModel>> GetForwardedGrievanceList(long UserId, long siId, long distId, long forwardStatus);
        Task<TModel> GetForwardedGrievanceDetail(long GrievanceId);
        Task<TModel> StepBackGrievance(long GrievanceId, string GrievanceStatus);
        Task<long?> DeleteGrievance(long GrievanceId);
    }
}
