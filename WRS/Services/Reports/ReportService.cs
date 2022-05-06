using AutoMapper;
using WRS.Dtos;
using WRS.Models;
using WRS.ViewModels;

namespace WRS.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly WRSDbContext _db;
        private readonly IMapper _mapper;
        public ReportService(WRSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ReportViewModel>> GetAllReports()
        {
            var reports = _db.Reports.Where(x => !x.IsDelete).ToList();
            return _mapper.Map<List<ReportViewModel>>(reports);
        }

        public async Task<int> CreateReport(CreateReportDto dto)
        {

            Report report = _mapper.Map<Report>(dto);
            await _db.Reports.AddAsync(report);
            _db.SaveChanges();
            return report.Id;
        }

        public async Task<int> DeleteReport(int Id)
        {
            var report = _db.Reports.FirstOrDefault(x => x.Id == Id && !x.IsDelete);
            report.IsDelete = true;
            _db.Update(report);
            await _db.SaveChangesAsync();
            return report.Id;
        }

        public async Task<int> UpdateReport(UpdateReportDto dto)
        {
            var report = await _db.Reports.FindAsync(dto.Id);
            var updatedReport = _mapper.Map<UpdateReportDto, Report>(dto, report);

            _db.Reports.Update(updatedReport);
            _db.SaveChanges();
            return updatedReport.Id;
        }

        public async Task<ReportViewModel> GetReport(int Id)
        {
            var report = _db.Reports.SingleOrDefault(x => x.Id == Id && !x.IsDelete);

            return _mapper.Map<ReportViewModel>(report);
        }
    }
}
