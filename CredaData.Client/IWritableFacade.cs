using CredaData.Models;

namespace CredaData.Client
{
    public interface IWritableFacade<TModel> : IFacade<TModel> where TModel : class, IModel
    {
        Task<bool> UpdateAsync(long id, TModel updatedModel, string updatedBy = "System");

        Task<bool> InsertAsync(TModel newModel, string insertedBy = "System");
        Task<long> InsertAsync(TModel newModel);

        Task<bool> DeleteAsync(long id);
        Task<List<TModel>> GetList(ParamModel model);
    }
}
