using WRS.Dtos;
using WRS.ViewModels;

namespace WRS.Services.QueryParameterServices
{
    public interface IQueryParameterService
    {
        Task<int> AddParameter(AddQueryParameterDto dto);
        Task<List<QueryParameterViewModel>> GetAllParameters();
        Task<int> DeleteParameter(int Id);
    }
}
