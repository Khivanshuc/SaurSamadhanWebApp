using CredaData.Models;
using System.Net.Http.Json;

namespace CredaData.Client
{
    public class WritableFacade<TModel> : Facade<TModel>, IWritableFacade<TModel> where TModel : class, IModel
    {

        public WritableFacade(IWebContextModel webContext) : base(webContext)
        {
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{apiPath}/{id}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> InsertAsync(TModel newModel, string insertedBy = "System")
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(apiPath, newModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(long id, TModel updatedModel, string updatedBy = "System")
        {
            try
            {
                var response = await httpClient.PatchAsJsonAsync(apiPath, updatedModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public async Task<List<TModel>> GetList(ParamModel model)
        {
            try
            {
                var query = $"?DistrictId={model.DistrictId}&StatusName={model.StatusName}";

                var response = await httpClient.GetAsync(apiPath+ query);
                var result = await response.Content.ReadFromJsonAsync<List<TModel>>();
                return result ?? new List<TModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<long> InsertAsync(TModel newModel)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(apiPath, newModel);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Assuming the API returns the newly created model with the ID in the response body
                    var createdModel = await response.Content.ReadFromJsonAsync<TModel>();

                    // Assuming that the TModel has an Id property of type long
                    var newId = (long)createdModel?.GetType().GetProperty("Id")?.GetValue(createdModel);

                    return newId; // Return the new Id
                }

                return 0; // Return null if the response wasn't successful
            }
            catch (Exception)
            {
                return 0; // Return null in case of an exception
            }
        }

    }
}