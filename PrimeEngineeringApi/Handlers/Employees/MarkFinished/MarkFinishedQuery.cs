using MediatR;

namespace PrimeEngineeringApi.Handlers.Employees.MarkFinished
{
    public class MarkFinishedQuery : IRequest<MarkFinishedQueryResponse>
    {
        public int TaskId { get; set; }
    }
}
