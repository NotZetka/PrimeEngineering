using MediatR;
using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Handlers.Employees.EditTask
{
    public class EditTaskQuery : IRequest<EditTaskQueryResponse>
    {
        public int TaskId { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }

        public Priority? Priority { get; set; }

    }
}
