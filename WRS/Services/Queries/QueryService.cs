using AutoMapper;
using WRS.Dtos;
using WRS.Models;
using WRS.ViewModels;

namespace WRS.Services.Queries
{
    public class QueryService : IQueryService
    {
        private readonly WRSDbContext _db;
        private readonly IMapper _mapper;
        public QueryService(WRSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> CreateQuery(CreateQueryDto dto)
        {

            Query query = _mapper.Map<Query>(dto);
            await _db.Queries.AddAsync(query);
            _db.SaveChanges();
            return query.Id;
        }

        public async Task<List<QueryViewModel>> GetAllQueries()
        {
            var queries = _db.Queries.Where(x => !x.IsDelete).ToList();
            return _mapper.Map<List<QueryViewModel>>(queries);
        }
        public async Task<int> DeleteQuery(int Id)
        {
            var query = _db.Queries.FirstOrDefault(x => x.Id == Id && !x.IsDelete);
            query.IsDelete = true;
            _db.Update(query);
            await _db.SaveChangesAsync();
            return query.Id;
        }

        public async Task<int> UpdateQuery(UpdateQueryDto dto)
        {
            var query = await _db.Queries.FindAsync(dto.Id);
            var updatedQuery = _mapper.Map<UpdateQueryDto, Query>(dto, query);

            _db.Queries.Update(updatedQuery);
            await _db.SaveChangesAsync();
            return updatedQuery.Id;
        }

        public async Task<QueryViewModel> GetQuery(int Id)
        {
            var query = _db.Queries.SingleOrDefault(x => x.Id == Id && !x.IsDelete);

            return _mapper.Map<QueryViewModel>(query);
        }
    }
}
