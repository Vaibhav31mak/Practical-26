namespace Practical26.Application.Features.Employees.Handlers
{
    public class CreateEmployeeHandler(ICommandUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly ICommandUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// Handles the employee creation request.
        /// </summary>
        public async Task<int> Handle(CreateEmployeeCommand request
            , CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee.Id;
        }
    }
}
