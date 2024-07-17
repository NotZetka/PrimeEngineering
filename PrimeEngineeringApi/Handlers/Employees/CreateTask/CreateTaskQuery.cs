using MediatR;
using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Handlers.Employees.CreateTask
{
    public class CreateTaskQuery : IRequest<CreateTaskQueryResponse>
    {
        public string Header { get; set; }
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
    }
}
