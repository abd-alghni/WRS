using WRS.Dtos;
using WRS.ViewModels;

namespace WRS.Services.Queries
{
    public interface IQueryService
    {
        Task<List<QueryViewModel>> GetAllQueries();
        Task<int> CreateQuery(CreateQueryDto dto);
        Task<int> DeleteQuery(int Id);
        Task<int> UpdateQuery(UpdateQueryDto dto);
        Task<QueryViewModel> GetQuery(int Id);
    }
}
