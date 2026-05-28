namespace Practical26.Application.Features.Employees.Handlers
{
    public class GetAllEmployeesHandler(IQueryRepository<Employee> queryRepository, IMapper mapper)
        : IRequestHandler<GetAllEmployeesQuery, IReadOnlyList<EmployeeListModel>>
    {
        private readonly IQueryRepository<Employee> _queryRepository = queryRepository;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Handles the request to retrieve all employees.
        /// </summary>
        public async Task<IReadOnlyList<EmployeeListModel>> Handle(GetAllEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var employees = await _queryRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<EmployeeListModel>>(employees);
        }
    }
}
