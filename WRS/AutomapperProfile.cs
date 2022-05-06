using AutoMapper;
using WRS.Dtos;
using WRS.Models;
using WRS.ViewModels;

namespace WRS
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DataSource, DataSourceViewModel>().ReverseMap();
            CreateMap<AddDataSourceDto, DataSource>().ReverseMap();
            CreateMap<UpdateDataSourceDto, DataSource>().ReverseMap();

            CreateMap<Report, ReportViewModel>().ReverseMap();
            CreateMap<CreateReportDto, Report>().ReverseMap();
            CreateMap<UpdateReportDto, Report>().ReverseMap();

            CreateMap<Query, QueryViewModel>().ReverseMap();
            CreateMap<CreateQueryDto, Query>().ReverseMap();
            CreateMap<UpdateQueryDto, Query>().ReverseMap();
        }
    }
}
