using WRS.Dtos;
using WRS.ViewModels;

namespace WRS.Services.DataSources
{
    public interface IDataSourceService
    {
        Task<List<DataSourceViewModel>> GetAllDataSources();
        Task<int> AddDataSource(AddDataSourceDto dto);
        Task<int> DeleteDataSource(int Id);
        Task<int> UpdateDataSource(UpdateDataSourceDto dto);
        Task<DataSourceViewModel> GetDataSource(int Id);
    }
}
