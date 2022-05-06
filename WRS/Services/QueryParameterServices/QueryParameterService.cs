using AutoMapper;
using WRS.Dtos;
using WRS.Models;
using WRS.ViewModels;

namespace WRS.Services.QueryParameterServices
{
    public class QueryParameterService : IQueryParameterService
    {
        private readonly WRSDbContext _db;
        private readonly IMapper _mapper;
        public QueryParameterService(WRSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> AddParameter(AddQueryParameterDto dto)
        {
            QueryParameter parameter = _mapper.Map<QueryParameter>(dto);
            await _db.QueryParameters.AddAsync(parameter);
            _db.SaveChanges();
            return parameter.Id;
        }

        public async Task<List<QueryParameterViewModel>> GetAllParameters()
        {
            var parameters = _db.QueryParameters.Where(x => !x.IsDelete).ToList();
            return _mapper.Map<List<QueryParameterViewModel>>(parameters);
        }

        public async Task<int> DeleteParameter(int Id)
        {
            var parameter = _db.QueryParameters.FirstOrDefault(x => x.Id == Id && !x.IsDelete);
            parameter.IsDelete = true;
            _db.Update(parameter);
            await _db.SaveChangesAsync();
            return parameter.Id;
        }


    }
}
