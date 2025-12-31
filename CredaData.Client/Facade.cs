using CredaData.Client.Models;
using CredaData.Models;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;
namespace CredaData.Client
{
    public partial class Facade<TModel> : IFacade<TModel> where TModel : class, IModel
    {
        protected readonly string apiPath;
        protected readonly HttpClient httpClient;
        protected readonly CookieContainer cookieContainer;
        protected readonly HttpClientHandler handler;

        public Facade(IWebContextModel webContext)
        {
            var apiRelativePath = typeof(TModel).GetAttributeValue<ApiMetadataAttribute, string>(a => a.ApiPath);
            apiPath = $"{webContext.ApiBaseUrl}/{apiRelativePath}";
            cookieContainer = webContext.CookieContainer;
            handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer,
                UseCookies = true,
            };
            //handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            //handler.ServerCertificateCustomValidationCallback =
            //    (httpRequestMessage, cert, cetChain, policyErrors) =>
            //    {
            //        return true;
            //    };
            httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", webContext.AuthApiKey);
            httpClient.DefaultRequestHeaders.Add("X-Device-Key", webContext.DeviceUniqueId);
        }

        public async Task<ResponseModel> LoginService(LoginModel loginModel)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(apiPath, loginModel);
                var result = await response.Content.ReadFromJsonAsync<ResponseModel>();
                if (string.IsNullOrWhiteSpace(result?.ErrorMessage))
                {
                    httpClient.DefaultRequestHeaders.Add("X-Api-Key", result?.Apikey);
                    httpClient.DefaultRequestHeaders.Add("X-Device-Key", loginModel.DeviceUniqueKey);
                }

                return result ?? new ResponseModel();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> ListAllAsync()
        {
            return await listAllAsyncInternal();
        }

        public async Task<List<TModel>> ListAllAsync(Expression<Func<TModel, bool>> filter)
        {
            return await listAllAsyncInternal(filter.ConvertToODataFilter());
        }
        private async Task<List<TModel>> listAllAsyncInternal(string filter = "")
        {
            try
            {
                var url = $"{apiPath}?$filter={filter}&XApiKey=";
                var response = await httpClient.GetAsync($"{apiPath}?$filter={filter}&XApiKey=");
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetDistListForAdminPanel(long UserId)
        {
            try
            {
                var url = $"{apiPath}/AdminPanelDistrictList?UserId={UserId}";
                var response = await httpClient.GetAsync(url);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TModel?> GetAsync(string mobile)
        {
            try
            {
                var url = $"{apiPath}/mobile={mobile}";
                var response = await httpClient.GetAsync($"{apiPath}/mobile={mobile}");
                var gridPresets = await response.Content.ReadFromJsonAsync<TModel>();
                return gridPresets;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetListAsync(string AttributeName, long AttributeValue, long UserId)
        {
            try
            {
                var url = $"{apiPath}?{AttributeName}={AttributeValue}&UserId={UserId}";
                var response = await httpClient.GetAsync(url);

                // Check if the response is null or not successful
                if (response == null || !response.IsSuccessStatusCode)
                {
                    return new List<TModel>();
                }

                // Attempt to read the content and deserialize
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();

                // Return the deserialized result or an empty list if result is null
                return result ?? new List<TModel>();
            }
            catch (Exception)
            {
                return new List<TModel>(); // Return an empty list in case of an exception
            }
        }

        public async Task<List<TModel>> GetList(ParamModel model)
        {
            try
            {
                var query = $"?DistrictId={model.DistrictId}&StatusName={model.StatusName}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetList(long model)
        {
            try
            {
                var query = $"?UserId={model}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> VillageSitesList(long VillageId)
        {
            try
            {
                var query = $"/VillageSites?VillageId={VillageId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetList(long SiteId, long BlockId, string StatusName)
        {
            try
            {
                var query = $"?SiteId={SiteId}&BlockId={BlockId}&StatusName={StatusName}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetUserWiseProjectWiseList(long UserId, long ProjectId, int FilterStatus, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                var query = $"?UserId={UserId}&ProjectId={ProjectId}&FilterStatus={FilterStatus}&StartDate={StartDate:yyyy-MM-dd}&EndDate={EndDate:yyyy-MM-dd}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetSSYRegLastData()
        {
            try
            {
                var query = $"/getSSYRegLastData";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetList(long DistrictId, long BlockId)
        {
            try
            {
                var query = $"?DistrictId={DistrictId}&BlockId={BlockId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetUserList(string UserName, long DistrictId, long UserId)
        {
            try
            {
                var query = $"?UserName={UserName}&DistrictId={DistrictId}&UserId={UserId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetList(long DistrictId, long BlockId, long VillageId, long SIId, long UserId)
        {
            try
            {
                var query = $"?DistrictId={DistrictId}&BlockId={BlockId}&VillageId={VillageId}&SIId={SIId}&UserId={UserId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetGrievanceGlanceList(long DistrictId, long TotalComplaint, long ResolvedComplaint,
            long ComplaintLess30Days, long PendingDOLessThan30Days, long PendingZOLessThan30Days, long PendingHOLessThan30Days,
            long ComplaintMore30Days, long PendingDOMoreThan30Days, long PendingZOMoreThan30Days, long PendingHOMoreThan30Days,
            long TotalPendingComplaint)
        {
            try
            {
                var query = $"?DistrictId={DistrictId}&TotalComplaint={TotalComplaint}&ResolvedComplaint={ResolvedComplaint}&" +
                    $"ComplaintLess30Days={ComplaintLess30Days}&PendingDOLessThan30Days={PendingDOLessThan30Days}&PendingZOLessThan30Days={PendingZOLessThan30Days}&PendingHOLessThan30Days={PendingHOLessThan30Days}&" +
                    $"ComplaintMore30Days={ComplaintMore30Days}&PendingDOMoreThan30Days={PendingDOMoreThan30Days}&PendingZOMoreThan30Days={PendingZOMoreThan30Days}&PendingHOMoreThan30Days={PendingHOMoreThan30Days}&" +
                    $"TotalPendingComplaint={TotalPendingComplaint}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetGrievanceAnalyticsGraphData()
        {
            try
            {
                var query = $"/admin/GrievanceAnalytics";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetComplaintList(long DistrictId, long BlockId, long SIId, long UserId, long WorkingStatus)
        {
            try
            {
                var query = $"?DistrictId={DistrictId}&BlockId={BlockId}&&SIId={SIId}&UserId={UserId}&WorkingStatus={WorkingStatus}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetList(long DistrictId, long BlockId, long VillageId, long SIId, long UserId, long WorkingStatus)
        {
            try
            {
                var query = $"?DistrictId={DistrictId}&BlockId={BlockId}&VillageId={VillageId}&SIId={SIId}&UserId={UserId}&WorkingStatus={WorkingStatus}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetList(long LoggedInUser, long DistrictId, long BlockId, long UserId, DateTime StartDate, DateTime EndDate, long FilterStatus)
        {
            try
            {
                string formattedStartDate = StartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = EndDate.ToString("yyyy-MM-dd");
                var query = $"?LoggedInUser={LoggedInUser}&DistrictId={DistrictId}&BlockId={BlockId}&UserId={UserId}&StartDate={formattedStartDate}&EndDate={formattedEndDate}&FilterStatus={FilterStatus}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetGrievanceList(long DistrictId, long BlockId, long VillageId, long SIId, long UserId, long WorkingStatus, long filterStatus, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                string formattedStartDate = StartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = EndDate.ToString("yyyy-MM-dd");
                var query = $"?DistrictId={DistrictId}&BlockId={BlockId}&VillageId={VillageId}&SIId={SIId}&UserId={UserId}&WorkingStatus={WorkingStatus}&filterStatus={filterStatus}&StartDate={formattedStartDate}&EndDate={formattedEndDate}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> GetForwardedGrievanceList(long UserId, long siId, long distId, long forwardStatus)
        {
            try
            {
                var query = $"?UserId={UserId}&SiId={siId}&DistId={distId}&Status={forwardStatus}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> ShowProjectReportList(long ProjectId, long DistrictId, DateTime StartDate, DateTime EndDate, long UserId)
        {
            try
            {
                // Convert StartDate and EndDate to the desired format (yyyy-MM-dd)
                string formattedStartDate = StartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = EndDate.ToString("yyyy-MM-dd");

                // Build the query string with formatted dates
                var query = $"Project/ShowProjectReport/?ProjectId={ProjectId}&DistrictId={DistrictId}&StartDate={formattedStartDate}&EndDate={formattedEndDate}&UserId={UserId}";
                var url = apiPath + query;

                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> ShowProjectCountReport(long UserId, DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus)
        {
            try
            {
                // Convert StartDate and EndDate to the desired format (yyyy-MM-dd)
                string formattedStartDate = StartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = EndDate.ToString("yyyy-MM-dd");

                // Build the query string with formatted dates
                var query = $"Project/DistrictBasedAllProjectCountAdmin/?UserId={UserId}&StartDate={formattedStartDate}&EndDate={formattedEndDate}&filterStatus={filterStatus}&WorkingStatus={WorkingStatus}";
                var url = apiPath + query;

                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TModel>> ShowProjectCountListReport(long ProjectId, long DistrictId, long UserId, DateTime StartDate, DateTime EndDate, long filterStatus, long WorkingStatus)
        {
            try
            {
                // Convert StartDate and EndDate to the desired format (yyyy-MM-dd)
                string formattedStartDate = StartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = EndDate.ToString("yyyy-MM-dd");

                // Build the query string with formatted dates
                var query = $"Project/DistrictBasedAllProjectCountListAdmin/?ProjectId={ProjectId}&DistrictId={DistrictId}&UserId={UserId}&StartDate={formattedStartDate}&EndDate={formattedEndDate}&filterStatus={filterStatus}&WorkingStatus={WorkingStatus}";
                var url = apiPath + query;

                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> DownloadProjectReportList(long ProjectId, long DistrictId, DateTime StartDate, DateTime EndDate, long UserId)
        {
            try
            {
                // Convert StartDate and EndDate to the desired format (yyyy-MM-dd)
                string formattedStartDate = StartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = EndDate.ToString("yyyy-MM-dd");

                // Build the query string with formatted dates
                var query = $"Project/DownloadProjectReport/?ProjectId={ProjectId}&DistrictId={DistrictId}&StartDate={formattedStartDate}&EndDate={formattedEndDate}&UserId={UserId}";
                var url = apiPath + query;

                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetList(long DistrictId, long BlockId, long VillageId)
        {
            try
            {
                var query = $"?DistrictId={DistrictId}&BlockId={BlockId}&VillageId={VillageId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetGrievanceGlanceCount()
        {
            try
            {
                var query = $"";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TModel>> GetSSYRegistrationDetail(long AdharNo, long MobileNo)
        {
            try
            {
                var query = $"?AdharNo={AdharNo}&MobileNo={MobileNo}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(apiPath + query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TModel?> GetAsync(long id)
        {
            try
            {
                var url = $"{apiPath}/{id}";
                var response = await httpClient.GetAsync($"{apiPath}/{id}");
                var gridPresets = await response.Content.ReadFromJsonAsync<TModel>();
                return gridPresets;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<TModel> GetCountAsync()
        {
            return await GetCountInternal();
        }
        public async Task<TModel?> GetCountAsync(Expression<Func<TModel, bool>> filter)
        {
            return await GetCountInternal(filter.ConvertToODataFilter());
        }
        public async Task<TModel?> GetCountInternal(string filter = "")
        {
            try
            {
                var url = $"{apiPath}/?$filter={filter}&XApiKey=";
                var response = await httpClient.GetAsync($"{apiPath}/?$filter={filter}&XApiKey=");
                var gridPresets = await response.Content.ReadFromJsonAsync<TModel>();
                return gridPresets;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<TModel>> ListAllAsync(params long[] ids)
        {
            try
            {
                var response = await httpClient.GetAsync($"{apiPath}/{ids.FirstOrDefault()}");
                var gridPresets = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return gridPresets ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TModel> GetAsync()
        {
            try
            {
                var response = await httpClient.GetAsync($"{apiPath}");
                var gridPresets = await response.Content.ReadFromJsonAsync<TModel>();
                return gridPresets;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> Count()
        {
            try
            {
                var url = $"{apiPath}/count?$filter";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var count = await response.Content.ReadFromJsonAsync<int>();
                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<int> Count(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                var filtervalue = filter.ConvertToODataFilter();
                var url = $"{apiPath}/count?$filter={filtervalue}&XApiKey=";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Assuming the response is a simple integer
                var count = await response.Content.ReadFromJsonAsync<int>();
                return count;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                return 0; // Return 0 or throw a custom exception
            }
        }

        public int Count(string field, object valueEquals)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string field, object valueEquals)
        {
            throw new NotImplementedException();
        }

        public TModel Get(string field, object valueEquals)
        {
            throw new NotImplementedException();
        }

        public TModel Get(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<AutoCompleteModel> GetNameValues(string nameField, string valueField, string filterColumn = null, string filterValue = null)
        {
            throw new NotImplementedException();
        }
        //private async Task<List<TModel>> listAllAsyncInternal(string filter = "")
        //{
        //    try
        //    {
        //        var url = $"{apiPath}?$filter={filter}&XApiKey=";
        //        var response = await httpClient.GetAsync($"{apiPath}?$filter={filter}&XApiKey=");
        //        var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
        //        return result ?? new List<TModel>();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public async Task<List<TModel>> ListAllAsync(string field, object valueEquals)
        {
            try
            {
                var url = $"{apiPath}?$filter={field} eq '{valueEquals}'&XApiKey=";
                var response = await httpClient.GetAsync(url);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public Task<List<TModel>> ListAllAsync(Func<TModel, bool> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public IPaginatedList<TModel> ListPage(int pageSize, int pageNumber, Expression<Func<TModel, bool>> filter, string sortColumnAndOrder)
        {
            throw new NotImplementedException();
        }

        public IPaginatedList<TModel> ListPage<T>(int pageSize, int pageNumber, Expression<Func<TModel, bool>> filter, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending)
        {
            throw new NotImplementedException();
        }

        public IPaginatedList<TModel> ListPage<T>(int pageSize, int pageNumber, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending)
        {
            throw new NotImplementedException();
        }

        public IPaginatedList<TModel> ListPage(int pageSize, int pageNumber, string sortColumnAndOrder)
        {
            throw new NotImplementedException();
        }

        public IPaginatedList<TModel> ListPage(int pageSize, int pageNumber, Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IPaginatedList<TModel> ListPage(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public List<TModel> ListTop(int maxRows)
        {
            throw new NotImplementedException();
        }

        public List<TModel> ListTop<T>(int maxRows, Expression<Func<TModel, bool>> filter, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending)
        {
            throw new NotImplementedException();
        }

        public List<TModel> ListTop<T>(int maxRows, Expression<Func<TModel, T>> orderBy, SortOrder order = SortOrder.Ascending)
        {
            throw new NotImplementedException();
        }

        public List<TModel> ListTop(int maxRows, string sortColumnAndOrder)
        {
            throw new NotImplementedException();
        }

        public List<TModel> SearchBy(string field, string contains)
        {
            throw new NotImplementedException();
        }

        public List<TModel> ListAll(params long[] ids)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> SendUpdateGrievanceOTP(long GrievanceId)
        {
            try
            {
                var query = $"/SendUpdateGrievanceOTP?GrievanceId={GrievanceId}";
                var url = apiPath + query;

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Optionally log the error or handle the failure
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return false;
            }
        }
        public async Task<TModel> GetForwardedGrievanceDetail(long GrievanceId)
        {
            try
            {
                var query = $"?GrievanceId={GrievanceId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(url);
                var gridPresets = await response.Content.ReadFromJsonAsync<TModel>();
                return gridPresets;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<TModel> StepBackGrievance(long GrievanceId, string GrievanceStatus)
        {
            try
            {
                var query = $"/admin/StepBackGrievance?GrievanceId={GrievanceId}&GrievanceStatus={GrievanceStatus}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(url);
                var gridPresets = await response.Content.ReadFromJsonAsync<TModel>();
                return gridPresets;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<long?> DeleteGrievance(long GrievanceId)
        {
            try
            {
                var query = $"/admin/DeleteGrievance?GrievanceId={GrievanceId}";
                var url = apiPath + query;
                var response = await httpClient.GetAsync(url);

                // Read raw response as string
                var raw = await response.Content.ReadAsStringAsync();

                // Try parse it to long
                if (long.TryParse(raw, out var result))
                {
                    return result;
                }

                // Parsing failed, return null or handle error as needed
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
