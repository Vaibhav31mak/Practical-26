namespace Practical26.Application.Features.Employees.Handlers
{
    public class UpdateEmployeeHandler(ICommandUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly ICommandUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// Handles the request to update an employee.
        /// </summary>
        public async Task<int> Handle(UpdateEmployeeCommand request
            , CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>((UpdateEmployeeModel)request);
            employee.Id = request.Id;
            employee.Status = request.Status;

            _unitOfWork.Employees.Update(employee);
            var affectedRows = await _unitOfWork.SaveChangesAsync();

            return affectedRows == 0 ? 0 : employee.Id;
        }
    }
}
