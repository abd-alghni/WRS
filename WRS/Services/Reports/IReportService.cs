using WRS.Dtos;
using WRS.ViewModels;

namespace WRS.Services.Reports
{
    public interface IReportService
    {
        Task<List<ReportViewModel>> GetAllReports();
        Task<int> CreateReport(CreateReportDto dto);
        Task<int> DeleteReport(int Id);
        Task<int> UpdateReport(UpdateReportDto dto);
        Task<ReportViewModel> GetReport(int Id);
    }
}
