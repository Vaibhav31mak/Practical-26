namespace Practical26.Application.Features.Employees.Handlers
{
    public class GetEmployeeByIdHandler
        (IQueryRepository<Employee> queryRepository, IMapper mapper)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponseModel>
    {
        private readonly IQueryRepository<Employee> _queryRepository = queryRepository;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Handles the request to retrieve an employee by identifier.
        /// </summary>
        public async Task<EmployeeResponseModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _queryRepository.GetByIdAsync(request.Id);
            return _mapper.Map<EmployeeResponseModel>(employee);
        }
    }
}