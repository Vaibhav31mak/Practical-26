namespace Practical26.Application.Features.Employees.Handlers
{
    // Handler for soft deleting an employee.
    public class DeleteEmployeeHandler(ICommandUnitOfWork unitOfWork)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly ICommandUnitOfWork _unitOfWork = unitOfWork;
        /// <summary>
        /// Handles the request to delete an employee.
        /// </summary>
        public async Task<bool> Handle(DeleteEmployeeCommand request
            , CancellationToken cancellationToken)
        {
            _unitOfWork.Employees.Delete(request.Id);
            var affectedRows = await _unitOfWork.SaveChangesAsync();

            return affectedRows > 0;
        }
    }
}
