
namespace Practical26.Application.Mappings
{
    public sealed class EmployeeProfile : Profile
    {
        /// <summary>
        /// Configures mappings for employee features.
        /// </summary>
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponseModel>();
            CreateMap<Employee, EmployeeListModel>();

            CreateMap<CreateEmployeeModel, Employee>()
                .ForMember(destination => destination.JoiningDate,
                options => options.MapFrom(_ => DateTime.UtcNow))
                .ForMember(destination => destination.Status,
                options => options.MapFrom(_ => true));

            CreateMap<UpdateEmployeeModel, Employee>();
        }
    }
}
