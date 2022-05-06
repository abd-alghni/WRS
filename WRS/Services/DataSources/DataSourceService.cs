using AutoMapper;
using WRS.Dtos;
using WRS.Models;
using WRS.ViewModels;

namespace WRS.Services.DataSources
{
    public class DataSourceService : IDataSourceService
    {
            private readonly WRSDbContext _db;
            private readonly IMapper _mapper;
            public DataSourceService(WRSDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }
        public async Task<int> AddDataSource(AddDataSourceDto dto)
        {

            DataSource dataSource = _mapper.Map<DataSource>(dto);
            await _db.DataSources.AddAsync(dataSource);
            _db.SaveChanges();
            return dataSource.Id;
        }

        public async Task<List<DataSourceViewModel>> GetAllDataSources()
        {
            var dataSource = _db.DataSources.Where(x => !x.IsDelete).ToList();
            return _mapper.Map<List<DataSourceViewModel>>(dataSource);
        }

        public async Task<int> DeleteDataSource(int Id)
            {
                var dataSource = _db.DataSources.FirstOrDefault(x => x.Id == Id && !x.IsDelete);
                dataSource.IsDelete = true;
                 _db.UpdateRange(dataSource);
                await _db.SaveChangesAsync();
                return dataSource.Id;
            }

            public async Task<int> UpdateDataSource(UpdateDataSourceDto dto)
            {
            var dataSource = await _db.DataSources.FindAsync(dto.Id);
            var updatedDataSource = _mapper.Map<UpdateDataSourceDto,DataSource>(dto, dataSource);

            _db.DataSources.Update(updatedDataSource);
            await _db.SaveChangesAsync();
            return updatedDataSource.Id;
        }

            public async Task<DataSourceViewModel> GetDataSource(int Id)
            {
            var dataSource = _db.DataSources.SingleOrDefault(x => x.Id == Id && !x.IsDelete);
            
            return _mapper.Map<DataSourceViewModel>(dataSource);
        }

    }

}
